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
    public partial class ChonKhachHang : Form
    {
        ketNoi cn;
        public String cmnd{get; set;}

        public ChonKhachHang()
        {
            cn = new ketNoi();
            InitializeComponent();
        }
        private void LoadGrid()
        {
            String str = "select cmnd as 'CMND',tenkh as 'Họ tên',sodt as 'Số điện thoại',email,diachi as 'Địa chỉ',gioitinh as 'Giới tính' from Khach_hang";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "KH");
            dgvKhachHang.DataSource = ds.Tables["KH"];
            
        }
        private void ChonKhachHang_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void chọnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmnd = dgvKhachHang.SelectedRows[0].Cells[0].Value.ToString();
            MessageBox.Show("Đã chọn !!!");
            this.Close();
        }
    }
}
