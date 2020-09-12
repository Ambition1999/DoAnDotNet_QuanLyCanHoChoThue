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
    public partial class MyCrystalCTHD : Form
    {
        public MyCrystalCTHD(string ma)
        {
            m = ma;
            InitializeComponent();
            int chieurong = Screen.PrimaryScreen.WorkingArea.Width;
            int chieudai = Screen.PrimaryScreen.WorkingArea.Height;
            this.Size = new Size(chieurong, chieudai);
        }
        string m="";
        private void MyCrystalCTHD_Load(object sender, EventArgs e)
        {
            try
            {
                CrystalReportCTHD cry = new CrystalReportCTHD();
                crystalReportViewer1.ReportSource = cry;
                cry.SetDatabaseLogon("sa", "len123", "BACHUTHEGIOI\\SQLEXPRESS", "ql_canho");
                cry.SetParameterValue("LocMaHD", m);
                crystalReportViewer1.DisplayStatusBar = false;
                crystalReportViewer1.DisplayToolbar = true;
                crystalReportViewer1.Refresh();
            }
            catch
            {
                MessageBox.Show("Không có Report Này!");
                this.Close();
            }
        }
    }
}
