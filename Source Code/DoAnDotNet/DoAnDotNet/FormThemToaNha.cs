using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAnDotNet
{
    public partial class FormThemToaNha : Form
    {
        private Form1 formMain;
        SqlDataAdapter da_toaNha;
        DataSet ds_toaNha;
        ketNoi cn;
        public FormThemToaNha()
        {
            InitializeComponent();
            formMain = new Form1();
            cn = new ketNoi();
            addTextBoxToList();
        }

        List<TextBox> listTextBox = new List<TextBox>();
        void addTextBoxToList()
        {
            addList(this);
        }

        private void addList(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c is TextBox)
                    listTextBox.Add((TextBox)c);
                if (c.Controls.Count > 0)
                    addList(c);
            }
        }

        private bool enableBtnThem()
        {
            foreach (TextBox item in listTextBox)
            {
                if (item.Text.Trim().Length == 0)
                    return false;
            }
            return true;
        }

        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                String selectStr = "select * from toa_nha";
                da_toaNha = new SqlDataAdapter(selectStr, cn.consql);
                ds_toaNha = new DataSet();
                da_toaNha.Fill(ds_toaNha, "build");


                DataRow dr = ds_toaNha.Tables["build"].NewRow();
                dr["Ten_ToaNha"] = txt_TenToaNha.Text;
                String diaChi = txt_PhuongXa.Text + ", " + txt_QuanHuyen.Text + ", " + txt_ThanhPho.Text;
                dr["DiaChi"] = diaChi.Trim();
                ds_toaNha.Tables["build"].Rows.Add(dr);

                SqlCommandBuilder cB = new SqlCommandBuilder(da_toaNha);
                da_toaNha.Update(ds_toaNha, "build");
                MessageBox.Show("Thêm tòa nhà " + txt_TenToaNha.Text + " thành công.");
                btn_XacNhan.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            txt_TenToaNha.Clear();
            txt_ThanhPho.Clear();
            txt_QuanHuyen.Clear();
            txt_PhuongXa.Clear();
            txt_TenToaNha.Focus();
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            formMain.Show();
            formMain.selectTabPage = "tabPage2";
            formMain.addListViewItem();
            formMain.addToListView();
            this.Hide();
        }

        private void txt_TenToaNha_TextChanged(object sender, EventArgs e)
        {
            btn_XacNhan.Enabled = enableBtnThem();
        }

        private void FormThemToaNha_Load(object sender, EventArgs e)
        {
            btn_XacNhan.Enabled = false;
            txt_TenToaNha.Focus();
        }

        private void txt_TenToaNha_KeyPress(object sender, KeyPressEventArgs e)
        {
            // chặn dấu phẩy
        }


    }
}
