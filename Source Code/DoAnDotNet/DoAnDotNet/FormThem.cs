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
    public partial class FormThem : Form
    {
        ketNoi cn;
        public FormThem()
        {
            cn = new ketNoi();
            InitializeComponent();
        }
        
        private void FormThem_Load(object sender, EventArgs e)
        {
            loadCboToaNha();
            loadCboDonVi();
            
        }
        private void loadCboToaNha()
        {
            String str = "select * from toa_nha";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "ToaNha");
            cboToaNha.DataSource = ds.Tables["ToaNha"];
            cboToaNha.DisplayMember = "ten_toanha";
            cboToaNha.ValueMember = "ma_toanha";
        }
        private void loadCboDonVi()
        {
            String str = "select distinct DonViTien,ma_canho from can_ho";
            SqlDataAdapter da = new SqlDataAdapter(str, cn.consql);
            DataSet ds = new DataSet();
            da.Fill(ds, "DonVi");     
            cboDonVi.DataSource = ds.Tables["DonVi"];
            cboDonVi.DisplayMember = "DonViTien";
            cboDonVi.ValueMember = "ma_canho";
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            String matn = cboToaNha.SelectedValue.ToString();
            String tang = txtTang.Text;
            String gia = txtGiaThue.Text;
            String dv = cboDonVi.Text;
            String tt = cboTrangThai.Text;
            String sp = txtSoPhong.Text;
            String dt = txtDienTich.Text;
            String mach = tang + "_" + sp;
            if (ktNhap() )
            {
                if (ktMaCH(mach,matn))
                {
                    cn.consql.Open();
                    
                    String str = "insert into can_ho values('" + mach+ "','" +matn+ "','" +tang + "','" +gia + "','" +dv+ "','" +dt+ "',N'" +tt+ "')";
                    SqlCommand cm = new SqlCommand(str, cn.consql);
                    int a = cm.ExecuteNonQuery();
                    if (a != 0)
                    {
                        MessageBox.Show("Thêm thành công!!!");
                    }
                    else
                        MessageBox.Show("Thất bại");
                    cn.consql.Close();
                }
                else
                {
                    MessageBox.Show("Phòng này đã tồn tại!!!");
                    txtSoPhong.Focus();
                }
            }
            else
            {
                MessageBox.Show("Nhập thiếu dữ liệu!!");
            }
        }
        private bool ktNhap()
        {
            if (cboToaNha.Text != "" && cboDonVi.Text != "" && cboTrangThai.Text != "" && txtTang.Text != "" && txtSoPhong.Text != "" && txtGiaThue.Text != "" && txtDienTich.Text != "")
            {
                return true;
            }
            return false;
        }
        private bool ktMaCH(String mach,String matn){
                cn.consql.Open();
                String str = "select * from can_ho where ma_canho='" + mach + "' and ma_toanha='"+matn+"'";
                SqlCommand cm = new SqlCommand(str, cn.consql);
                var a= cm.ExecuteScalar();        
                if (a == null)
                {
                    cn.consql.Close();
                    return true;
                }
                cn.consql.Close();
                return false;
            }

        private void txtSoPhong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        }
    }

