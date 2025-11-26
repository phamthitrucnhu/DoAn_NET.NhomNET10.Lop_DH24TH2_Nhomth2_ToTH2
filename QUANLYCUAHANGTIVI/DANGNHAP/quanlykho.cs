using MySql.Data.MySqlClient;
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
    public partial class quanlykho : Form
    {
        string conString = "server=localhost;database=qlcuahangtivi;user=root;password=15082005;";
        public quanlykho()
        {
            InitializeComponent();
            this.Load += quanlykho_Load;
           
            this.dataGridView2.CellClick += dataGridView2_CellClick;
        }
        
        private void LoadData(string query)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;database=qlcuahangtivi;user=root;password=15082005;"))
            {
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void quanlykho_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM khohang");
        }
        // nút thêm
        private void button1_Click(object sender, EventArgs e)
        {
           
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();

                string sql = "INSERT INTO khohang (loaiphieu, ngaylap, nhacungcap, masanpham, dongia, soluong, ghichu) " +
                             "VALUES (@lp, @nl, @ncc, @msp, @dg, @sl, @gc)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@lp", txtLoaiPhieu.Text);
                cmd.Parameters.AddWithValue("@nl", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ncc", txtNhaCC.Text);
                cmd.Parameters.AddWithValue("@msp", txtMaSP.Text);
                cmd.Parameters.AddWithValue("@dg", string.IsNullOrWhiteSpace(txtDonGia.Text) ? 0 : Convert.ToDecimal(txtDonGia.Text));
                cmd.Parameters.AddWithValue("@sl", string.IsNullOrWhiteSpace(txtSoLuong.Text) ? 0 : Convert.ToDecimal(txtSoLuong.Text));
                cmd.Parameters.AddWithValue("@gc", txtGhiChu.Text);
            // câu lênhj thực thi khi insert

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM khohang");
            MessageBox.Show("Thêm phiếu kho thành công!");
        }



        
        // nut luu

        private void button6_Click(object sender, EventArgs e)
        {
            
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                MySqlCommand cmd;

                // Nếu không có mã phiếu → thêm mới
                if (string.IsNullOrWhiteSpace(txtMaPhieu.Text))
                {
                    string sql = "INSERT INTO khohang (loaiphieu, ngaylap, nhacungcap,dongia, masanpham, soluong, ghichu) " +
                                 "VALUES (@lp, @nl, @ncc,@dg, @msp, @sl, @gc)";
                    cmd = new MySqlCommand(sql, con);
                }
                else  // CÓ mã phiếu → cập nhật
                {
                    string sql = "UPDATE khohang SET loaiphieu=@lp, ngaylap=@nl,dongia=@dg, nhacungcap=@ncc, " +
                                 "masanpham=@msp, soluong=@sl, ghichu=@gc WHERE maphieu=@id";

                    cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", txtMaPhieu.Text);
                }

                // Các tham số chung
                cmd.Parameters.AddWithValue("@lp", txtLoaiPhieu.Text);
                cmd.Parameters.AddWithValue("@nl", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@ncc", txtNhaCC.Text);
                cmd.Parameters.AddWithValue("@msp", txtMaSP.Text);
                cmd.Parameters.AddWithValue("@sl", txtSoLuong.Text);
                cmd.Parameters.AddWithValue("@gc", txtGhiChu.Text);
                cmd.Parameters.AddWithValue("@dg", string.IsNullOrWhiteSpace(txtDonGia.Text) ? 0 : Convert.ToDecimal(txtDonGia.Text));


                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM khohang");
            MessageBox.Show("Lưu thành công!");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (txtMaPhieu.Text == "")
            {
                MessageBox.Show("Vui lòng chọn phiếu để xóa!");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();

                string sql = "DELETE FROM khohang WHERE maphieu=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", txtMaPhieu.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM khohang");
            MessageBox.Show("Xóa thành công!");
        }

        private void btnTailai_Click(object sender, EventArgs e)
        
        {
            LoadData("SELECT * FROM khohang");
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // ---------------------- CELL CLICK (ĐỔ DỮ LIỆU LÊN FORM) ----------------------
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = e.RowIndex;
            if (r >= 0)
            {
                txtMaPhieu.Text = dataGridView2.Rows[r].Cells["maphieu"].Value.ToString();
                txtLoaiPhieu.Text = dataGridView2.Rows[r].Cells["loaiphieu"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView2.Rows[r].Cells["ngaylap"].Value);
                txtNhaCC.Text = dataGridView2.Rows[r].Cells["nhacungcap"].Value.ToString();
                txtMaSP.Text = dataGridView2.Rows[r].Cells["masanpham"].Value.ToString();
                txtSoLuong.Text = dataGridView2.Rows[r].Cells["soluong"].Value.ToString();
                txtGhiChu.Text = dataGridView2.Rows[r].Cells["ghichu"].Value.ToString();
                txtDonGia.Text = dataGridView2.Rows[r].Cells["dongia"].Value.ToString();
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }


}
    

