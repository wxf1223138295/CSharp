using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using System.Reflection.Emit;

namespace WinformControl
{
    /// <summary>
    /// Table转换实体处理
    /// </summary>
    public class FgFuncTable2Entity
    {
        private delegate T Load<T>(DataRow DrRecord);
        private static readonly MethodInfo mGetValueMet = typeof(DataRow).GetMethod("get_Item", new Type[] { typeof(int) });
        private static readonly MethodInfo mIsDBNullMet = typeof(DataRow).GetMethod("IsNull", new Type[] { typeof(int) });
        private static Dictionary<Type, Delegate> mRowMapMets = new Dictionary<Type, Delegate>();
        private static Dictionary<Type, MethodInfo> mConvertMets = new Dictionary<Type, MethodInfo>()
       {
           {typeof(int),typeof(Convert).GetMethod("ToInt32",new Type[]{typeof(object)})},
           {typeof(Int16),typeof(Convert).GetMethod("ToInt16",new Type[]{typeof(object)})},
           {typeof(Int64),typeof(Convert).GetMethod("ToInt64",new Type[]{typeof(object)})},
           {typeof(DateTime),typeof(Convert).GetMethod("ToDateTime",new Type[]{typeof(object)})},
           {typeof(decimal),typeof(Convert).GetMethod("ToDecimal",new Type[]{typeof(object)})},
           {typeof(double),typeof(Convert).GetMethod("ToDouble",new Type[]{typeof(object)})},
           {typeof(Boolean),typeof(Convert).GetMethod("ToBoolean",new Type[]{typeof(object)})},
           {typeof(char),typeof(Convert).GetMethod("ToChar",new Type[]{typeof(object)})},
           {typeof(string),typeof(Convert).GetMethod("ToString",new Type[]{typeof(object)})}
       };

        internal static TEnum ToEnum<TEnum, TUnder>(object obj)
        {
            return (TEnum)Convert.ChangeType(obj, typeof(TUnder));
        }

        internal static T ToIntCuInt<T>(object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(int));
        }

        internal static T ToIntCuDecimal<T>(object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(decimal));
        }

        /// <summary>
        /// DataTable转换成对象的List集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="_tab">DataTable</param>
        /// <returns></returns>
        public static List<T> DataTableToListPro<T>(DataTable _tab) where T : new()
        {
            List<T> _ResultList = new List<T>();
            if (_tab == null) return _ResultList;

            Load<T> _RowMap = null;

            if (!mRowMapMets.ContainsKey(typeof(T)))
            {
                DynamicMethod _Method = new DynamicMethod("DyEntity_" + typeof(T).Name, typeof(T), new Type[] { typeof(DataRow) }, typeof(T), true);
                ILGenerator _Generator = _Method.GetILGenerator();
                LocalBuilder _Result = _Generator.DeclareLocal(typeof(T));
                _Generator.Emit(OpCodes.Newobj, typeof(T).GetConstructor(Type.EmptyTypes));
                _Generator.Emit(OpCodes.Stloc, _Result);
                for (int i = 0; i < _tab.Columns.Count; i++)
                {
                    PropertyInfo propertyInfo = typeof(T).GetProperties().ToList().Find(p => p.Name.ToLower().Equals(_tab.Columns[i].ColumnName.ToLower()));
                    Label endIfLabel = _Generator.DefineLabel();
                    if (propertyInfo != null && propertyInfo.GetSetMethod() != null)
                    {
                        _Generator.Emit(OpCodes.Ldarg_0);
                        _Generator.Emit(OpCodes.Ldc_I4, i);
                        _Generator.Emit(OpCodes.Callvirt, mIsDBNullMet);
                        _Generator.Emit(OpCodes.Brtrue, endIfLabel);
                        _Generator.Emit(OpCodes.Ldloc, _Result);
                        _Generator.Emit(OpCodes.Ldarg_0);
                        _Generator.Emit(OpCodes.Ldc_I4, i);
                        _Generator.Emit(OpCodes.Callvirt, mGetValueMet);
                        if (propertyInfo.PropertyType.IsValueType || propertyInfo.PropertyType == typeof(string))
                            if (propertyInfo.PropertyType.IsEnum)
                                _Generator.Emit(OpCodes.Call, typeof(FgFuncTable2Entity).GetMethod("ToEnum", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(propertyInfo.PropertyType, Enum.GetUnderlyingType(propertyInfo.PropertyType)));
                            else if (propertyInfo.PropertyType == typeof(int?))
                                _Generator.Emit(OpCodes.Call, typeof(FgFuncTable2Entity).GetMethod("ToIntCuInt", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(propertyInfo.PropertyType));
                            else if (propertyInfo.PropertyType == typeof(decimal?))
                                _Generator.Emit(OpCodes.Call, typeof(FgFuncTable2Entity).GetMethod("ToIntCuDecimal", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(propertyInfo.PropertyType));
                            else
                                _Generator.Emit(OpCodes.Call, mConvertMets[propertyInfo.PropertyType]);
                        else
                            _Generator.Emit(OpCodes.Castclass, propertyInfo.PropertyType);
                        _Generator.Emit(OpCodes.Callvirt, propertyInfo.GetSetMethod());
                        _Generator.MarkLabel(endIfLabel);
                    }
                }
                _Generator.Emit(OpCodes.Ldloc, _Result);
                _Generator.Emit(OpCodes.Ret);
                _RowMap = (Load<T>)_Method.CreateDelegate(typeof(Load<T>));
            }
            else
                _RowMap = (Load<T>)mRowMapMets[typeof(T)];

            foreach (DataRow info in _tab.Rows)
                _ResultList.Add(_RowMap(info));
            return _ResultList;
        }

        /// <summary>
        /// DataTable转换成对象的List集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="_tab">DataTable</param>
        /// <returns></returns>
        public static List<T> DataTableToList<T>(DataTable _tab) where T : new()
        {
            List<T> _list = new List<T>();
            if (_tab == null) return _list;

            System.Reflection.PropertyInfo[] _infos = typeof(T).GetProperties();
            foreach (DataRow _row in _tab.Rows)
            {
                T _t = new T();
                foreach (PropertyInfo property in _infos)
                    if (property.CanWrite && _tab.Columns.Contains(property.Name))
                        DataRowToEntity<T>(property, _row, _t);
                _list.Add(_t);
            }
            return _list;
        }

        /// <summary>
        /// DataTable转换成对象的List集合
        /// </summary>
        /// <typeparam name="Parent"></typeparam>
        /// <typeparam name="Child"></typeparam>
        /// <param name="_tab"></param>
        /// <returns></returns>
        public static List<Parent> DataTableToList<Parent, Child>(DataTable _tab)
            where Parent : new()
            where Child : new()
        {
            List<Parent> _list = new List<Parent>();
            if (_tab == null) return _list;

            foreach (DataRow _row in _tab.Rows)
                _list.Add(DataRowToEntity<Parent, Child>(_row));
            return _list;
        }

        /// <summary>
        /// DataTable转换成对象的List集合
        /// </summary>
        /// <typeparam name="Parent"></typeparam>
        /// <typeparam name="ChildParent"></typeparam>
        /// <typeparam name="Child"></typeparam>
        /// <param name="_tab"></param>
        /// <returns></returns>
        public static List<Parent> DataTableToList<Parent, ChildParent, Child>(DataTable _tab)
            where Parent : new()
            where ChildParent : new()
            where Child : new()
        {
            List<Parent> _list = new List<Parent>();
            if (_tab == null) return _list;

            System.Reflection.PropertyInfo[] _infos = typeof(Parent).GetProperties();
            foreach (DataRow _row in _tab.Rows)
            {
                Parent _t = new Parent();
                foreach (System.Reflection.PropertyInfo property in _infos)
                    if (property.CanWrite && property.PropertyType.Name == typeof(ChildParent).Name)
                        property.SetValue(_t, DataRowToEntity<ChildParent, Child>(_row), null);
                    else if (property.CanWrite && _tab.Columns.Contains(property.Name))
                        DataRowToEntity<Parent>(property, _row, _t);
                _list.Add(_t);
            }
            return _list;
        }

        /// <summary>
        /// DataTable转换成对象的List集合
        /// </summary>
        /// <typeparam name="Parent"></typeparam>
        /// <typeparam name="Child1"></typeparam>
        /// <typeparam name="Child2"></typeparam>
        /// <param name="_tab"></param>
        /// <returns></returns>
        public static List<Parent> DataTableToList2Child<Parent, Child1, Child2>(DataTable _tab)
            where Parent : new()
            where Child1 : new()
            where Child2 : new()
        {
            List<Parent> _list = new List<Parent>();
            if (_tab == null) return _list;

            System.Reflection.PropertyInfo[] _infos = typeof(Parent).GetProperties();
            foreach (DataRow _row in _tab.Rows)
            {
                Parent _t = new Parent();
                foreach (System.Reflection.PropertyInfo property in _infos)
                    if (property.CanWrite && property.PropertyType.Name == typeof(Child1).Name)
                        property.SetValue(_t, DataRowToEntity<Child1>(_row), null);
                    else if (property.CanWrite && property.PropertyType.Name == typeof(Child2).Name)
                        property.SetValue(_t, DataRowToEntity<Child2>(_row), null);
                    else if (property.CanWrite && _row.Table.Columns.Contains(property.Name))
                        DataRowToEntity<Parent>(property, _row, _t);
                _list.Add(_t);
            }
            return _list;
        }

        /// <summary>
        /// 把DataRow转换成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_row"></param>
        /// <returns></returns>
        public static T DataRowToEntity<T>(DataRow _row) where T : new()
        {
            T _t = new T();
            foreach (System.Reflection.PropertyInfo property in typeof(T).GetProperties())
                if (property.CanWrite && _row.Table.Columns.Contains(property.Name))
                    DataRowToEntity<T>(property, _row, _t);
            return _t;
        }

        /// <summary>
        /// 把DataRow转换成实体
        /// </summary>
        /// <typeparam name="Parent"></typeparam>
        /// <typeparam name="Child"></typeparam>
        /// <param name="_row"></param>
        /// <returns></returns>
        public static Parent DataRowToEntity<Parent, Child>(DataRow _row)
            where Parent : new()
            where Child : new()
        {
            Parent _t = new Parent();
            foreach (System.Reflection.PropertyInfo property in typeof(Parent).GetProperties())
                if (property.CanWrite && property.PropertyType.Name == typeof(Child).Name)
                    property.SetValue(_t, DataRowToEntity<Child>(_row), null);
                else if (property.CanWrite && _row.Table.Columns.Contains(property.Name))
                    DataRowToEntity<Parent>(property, _row, _t);
            return _t;
        }

        /// <summary>
        /// 把DataRow转换成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <param name="_row"></param>
        /// <param name="_t"></param>
        /// <returns></returns>
        public static T DataRowToEntity<T>(System.Reflection.PropertyInfo property, DataRow _row, T _t) where T : new()
        {
            if (_row[property.Name] is DBNull) return _t;
            try
            {
                var type = property.PropertyType;
                if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    var nc = new NullableConverter(type);
                    if (nc.UnderlyingType == _row.Table.Columns[property.Name].DataType)
                    {
                        property.SetValue(_t, _row[property.Name], null);
                        return _t;
                    }
                    type = nc.UnderlyingType;
                }
                else
                {
                    if (type != typeof(string) && type == _row.Table.Columns[property.Name].DataType)
                    {
                        property.SetValue(_t, _row[property.Name], null);
                        return _t;
                    }
                }
                if (type == typeof(bool))
                    property.SetValue(_t, FgFuncStr.NullToInt(_row[property.Name]) == 1, null);
                else if (type.IsEnum)
                    property.SetValue(_t, Enum.Parse(type, _row[property.Name].ToString()), null);
                else if (type.IsValueType)
                {
                    var _value = type.InvokeMember("Parse", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { _row[property.Name].ToString() });
                    property.SetValue(_t, _value, null);
                }
                else if (type == typeof(string))
                    property.SetValue(_t, _row[property.Name].ToString().Trim(), null);
                else property.SetValue(_t, _row[property.Name], null);
                return _t;
            }
            catch (Exception ex)
            {
                var str = string.Format("{0}:{1}[{2}] Value is {3}, Convert Error!", typeof(T).Name, property.Name, property.PropertyType, _row[property.Name]);
                throw new Exception(str, ex);
            }
        }
    }
}
