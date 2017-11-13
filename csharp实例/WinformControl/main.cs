using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformControl
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmWaiting.Showing(new List<Func<string>>()
            {
                LoadStatic.fun1,
                LoadStatic.fun2,
                LoadStatic.fun3,
                LoadStatic.fun4,
                LoadStatic.fun5
            });

        }

    }
}
