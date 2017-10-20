using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLTOlinq
{
    class Program
    {
        static void Main(string[] args)
        {

            //XNamespace name = "www.baidu.com";
            //XElement AnalysisPrescription = new XElement("details_xml", new XAttribute("is_upload", 1), new XElement(name+"his_time"));


            //XElement sf = AnalysisPrescription.Element(name + "his_time");

            XNamespace ns1 = "http://www.cnblogs.com/space1";
            XNamespace ns2 = "http://www.cnblogs.com/space2";
            var mix = new XElement(ns1 + "data",
                new XElement(ns2 + "element", "value"),
                new XElement(ns2 + "element", "value"),
                new XElement(ns2 + "element", "value")
            );


            mix.SetAttributeValue(XNamespace.Xmlns + "ns1", ns1);
            mix.SetAttributeValue(XNamespace.Xmlns + "ns2", ns2);

            Console.WriteLine(mix.ToString());

            Console.ReadKey();
        }
    }
}
