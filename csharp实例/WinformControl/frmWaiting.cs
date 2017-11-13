using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformControl
{
    public partial class frmWaiting : DevExpress.XtraEditors.XtraForm
    {
        private List<Func<string>> FuncList { get; set; }

        private int DefaultStep { get { return 0; } }
        /// <summary>
        ///  窗体初始化构造
        /// </summary>
        /// <param name="_funclist">需要执行的方法集合(方法返回参数为string,无入参)</param>
        public frmWaiting(List<Func<string>> _funclist)
        {
            InitializeComponent();
            label1.Text = "加载数据开始";
            this.FuncList = _funclist;
        }
        /// <summary>
        /// 显示进度条
        /// </summary>
        /// <param name="_funclist">需要执行的方法集合(方法返回参数为string,无入参)</param>
        public static void Showing(List<Func<string>> _funclist)
        {
            Showing(null, _funclist);
        }
        public static void Showing(Form _handle, List<Func<string>> _funclist)
        {
            using (var fm = new frmWaiting(_funclist))
                fm.ShowDialog(_handle);
        }
        public frmWaiting()
        {
            InitializeComponent();
        }

        private void frmWaiting_Load(object sender, EventArgs e)
        {

        }

        private void frmWaiting_Shown(object sender, EventArgs e)
        {
            //if (Screen.PrimaryScreen.Bounds.Height <= 600) FgPubVar.g_ribbon.Minimized = true;
            if (this.FuncList == null || this.FuncList.Count == 0)
            {
                this.DialogResult = DialogResult.OK;
                return;
            }
            progressBarControl1.Properties.Maximum = DefaultStep + this.FuncList.Count;
            progressBarControl1.EditValue = DefaultStep;

            var _current = Thread.CurrentThread.CurrentUICulture;
            Parallel.ForEach(FuncList,
                p => Task.Factory.StartNew((_curent) =>
                    {
                        Thread.CurrentThread.CurrentUICulture = _curent as CultureInfo;
                        try { return p.Invoke(); }
                        catch { return p.Method.Name + " Function Error!"; }
                    }, _current)
                    .ContinueWith(result =>
                    {
                        this.Invoke(new ThreadStart(() =>
                        {
                            label1.Text = result.Result;
                            progressBarControl1.EditValue = (int)progressBarControl1.EditValue + 1;
                            if ((int)progressBarControl1.EditValue == progressBarControl1.Properties.Maximum)
                                this.DialogResult = DialogResult.OK;
                        }));
                    }));
        }
    }
}
