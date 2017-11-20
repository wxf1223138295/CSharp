using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace 深拷贝
{
    public class FuncClone
    {
        //利用反射实现深拷贝
        public static T DeepCopyWithReflection<T>(T obj)
        {
            Type type = obj.GetType();

            // 如果是字符串或值类型则直接返回
            if (obj is string || type.IsValueType) return obj;

            if (type.IsArray)
            {
                Type elementType = Type.GetType(type.FullName.Replace("[]", string.Empty));
                var array = obj as Array;
                Array copied = Array.CreateInstance(elementType, array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    copied.SetValue(DeepCopyWithReflection(array.GetValue(i)), i);
                }

                return (T)Convert.ChangeType(copied, obj.GetType());
            }

            object retval = Activator.CreateInstance(obj.GetType());

            PropertyInfo[] properties = obj.GetType().GetProperties(
                BindingFlags.Public | BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Static);
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(obj, null);
                if (propertyValue == null)
                    continue;
                property.SetValue(retval, DeepCopyWithReflection(propertyValue), null);
            }

            return (T)retval;
        }
        /// <summary>
        /// 深复制对象的实例到新的对象,自定义类必须声明可序列化[Serializable]
        /// </summary>
        /// <param name="Obj">原始实体</param>
        /// <returns></returns>
        public static T Clone<T>(T Obj) where T : class
        {
            object result = null;
            var memoryStream = new System.IO.MemoryStream();
            var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            try
            {
                if (Obj != null)
                {
                    formatter.Serialize(memoryStream, Obj);
                    //memoryStream.Position = 0;
                    memoryStream.Seek(0,System.IO.SeekOrigin.Begin);
                    result = formatter.Deserialize(memoryStream);
                }
            }
            catch (Exception e)
            {
                 
            }
            finally
            {
                memoryStream.Close();
            }
            return result as T;
        }
        // 利用DataContractSerializer序列化和反序列化实现
        public static T DeepCopy<T>(T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(T));
                ser.WriteObject(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                retval = ser.ReadObject(ms);
                ms.Close();
            }
            return (T)retval;
        }
        // 利用XML序列化和反序列化实现
        public static T DeepCopyWithXmlSerializer<T>(T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                xml.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                retval = xml.Deserialize(ms);
                ms.Close();
            }

            return (T)retval;
        }


        /// <summary>
        /// 通过类型相同的属性赋值,可以是继承相同的接口或实体的子类
        /// </summary>
        /// <param name="result">需要赋值的对象</param>
        /// <param name="resource">来源对象</param>
        public static void CopyByType<T>(T result, T resource)
            where T : class
        {
            if (result == null || resource == null) return;
            var properties = GetPropertyList(typeof(T));
            CopyByProperties(result, resource, properties.ToArray());
        }

        /// <summary>
        /// 获取类型的所有公共属性
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static List<PropertyInfo> GetPropertyList(Type type)
        {
            var _properties = type.GetProperties().ToList();
            if (type.IsInterface)
            {
                var faces = type.GetInterfaces();
                foreach (var face in faces)
                    _properties.AddRange(GetPropertyList(face));
            }
            return _properties;
        }
        private static void CopyByProperties(object result, object resource, PropertyInfo[] properties)
        {
            if (result == null || resource == null) return;
            foreach (var p in properties)
            {
                if (p.CanRead && p.CanWrite)
                    p.SetValue(result, p.GetValue(resource, null), null);
            }
        }

        /// <summary>
        /// 复制对象的实例到新的对象
        /// </summary>
        /// <param name="GoldObj">目标实体</param>
        /// <param name="CopyObj">复制实体</param>
        /// <returns></returns>
        public static bool CloneEntity<T>(T GoldObj, T CopyObj) where T : new()
        {
            if (CopyObj == null)
            {
                GoldObj = new T();
                return true;
            }
            if (GoldObj == null) { GoldObj = new T(); }
            try { CopyByProperties(GoldObj, CopyObj, typeof(T).GetProperties()); }
            catch { return false; }
            return true;
        }
    }
}
