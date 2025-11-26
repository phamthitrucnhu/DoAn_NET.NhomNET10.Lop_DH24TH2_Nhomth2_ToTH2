using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DANGNHAP
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            quanlytivi sp = new quanlytivi();
            
            sp.ShowDialog();

        }
        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
         // Đóng Menu là thoát ứng dụng
        }

        private void button5_Click(object sender, EventArgs e)
        {
            quanlykhachhang kh = new quanlykhachhang();
            kh.ShowDialog();
        }
        // nut thoat
        private void button6_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            

            quanlynhanvien nv = new quanlynhanvien();
            nv.ShowDialog();
        }

        private void btnKHO_Click(object sender, EventArgs e)
        {
            quanlykho kho = new quanlykho();
            kho.ShowDialog();
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            quanlyhoadon hd = new quanlyhoadon();
            hd.ShowDialog();
        
        }
    }
}
