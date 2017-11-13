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
    public partial class MergeGrid : Form
    {
        public MergeGrid()
        {
            InitializeComponent();
        }

        private void MergeGrid_Load(object sender, EventArgs e)
        {
            string sql = "select * from MergeColumn";

            var table=DbHelperSQL.Query(sql).Tables[0];

            var date = FgFuncTable2Entity.DataTableToList<组别Entity>(table);

            gridControl1.DataSource = date;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            //if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            //{
            //    e.Info.DisplayText = (e.RowHandle + 1).ToString();
            //}
        }
    }
}
