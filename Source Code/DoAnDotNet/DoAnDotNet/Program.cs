using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnDotNet
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           //Application.Run(new Form1());
            //Application.Run(new TaiKhoan());
            Application.Run(new FormDangNhap());
            //Application.Run(new FormDangKy()); 
            //Application.Run(new FormThem()); 
            //Application.Run(new FormThueSua()); 
            //Application.Run(new FormThemKhachHang());
            //Application.Run(new FormThemToaNha());
        }
    }
}
