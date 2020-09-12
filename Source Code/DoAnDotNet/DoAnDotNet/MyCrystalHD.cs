using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnDotNet
{
    public partial class MyCrystalHD : Form
    {
        public MyCrystalHD()
        {
            InitializeComponent();
            int chieurong = Screen.PrimaryScreen.WorkingArea.Width;
            int chieudai = Screen.PrimaryScreen.WorkingArea.Height;
            this.Size = new Size(chieurong, chieudai);
        }

        private void MyCrystalHD_Load(object sender, EventArgs e)
        {
            CrystalReportHD cry = new CrystalReportHD();
            crystalReportViewer1.ReportSource = cry;
            cry.SetDatabaseLogon("sa", "len123", "BACHUTHEGIOI\\SQLEXPRESS", "ql_canho");
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            crystalReportViewer1.Refresh();
        }
    }
}
