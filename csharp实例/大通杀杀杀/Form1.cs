using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 大通杀杀杀
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string s1 = new XElement("base_xml",
                    new XElement("source", "HIS"),
                    new XElement("hosp_code", 476),
                    new XElement("dept_code", 123),
                    new XElement("dept_name", "s"),
                    new XElement("doct",
                    new XElement("code", 12),
                    new XElement("name", "sdd"),
                    new XElement("type",1),
                    new XElement("type_name",1))).ToString();
        private string s2 = new XElement("details_xml", new XElement("doct_pwd", "1")).ToString();
        private string s3 = "";
        private string s4 = new XElement("details_xml",
                    new XElement("hosp_flag", "ip"),
                    new XElement("medicine",
                    new XElement("his_code", 29610417),
                    new XElement("his_name", "注射用泮托拉唑钠"))).ToString();
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crms.CRMS_UI(1, s1, s2,ref s3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            crms.CRMS_UI(1, s1, s4, ref s3);
        }
    }
}
