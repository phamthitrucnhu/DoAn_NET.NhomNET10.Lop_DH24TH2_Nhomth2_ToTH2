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
    public partial class quanlytivi : Form
    {
        string conString = "server=localhost;port=3306;user=root;password=15082005;database=qlcuahangtivi;";
        public quanlytivi()
        {
            InitializeComponent();
            this.Load += quanlytivi_Load;
            this.dataGridView2.CellClick += dataGridView2_CellClick;
        }
        private void LoadData(string query)
        {
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM sanpham", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }
        // Khi form mở → Hiển thị dữ liệu lên DataGridView

        private void quanlytivi_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM sanpham");



        }
        // ------------- CLICK CHỌN DÒNG LÊN Ô TEXT --------------
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaSP.Text = dataGridView2.Rows[index].Cells["masanpham"].Value.ToString();
                txtTenSP.Text = dataGridView2.Rows[index].Cells["tensanpham"].Value.ToString();
                txtHang.Text = dataGridView2.Rows[index].Cells["hangsanxuat"].Value.ToString();
                txtKichThuoc.Text = dataGridView2.Rows[index].Cells["kichthuoc"].Value.ToString();
                txtLoai.Text = dataGridView2.Rows[index].Cells["loai"].Value.ToString();
                txtGiaNhap.Text = dataGridView2.Rows[index].Cells["gianhap"].Value.ToString();
                txtGiaBan.Text = dataGridView2.Rows[index].Cells["giaban"].Value.ToString();
                txtSoLuong.Text = dataGridView2.Rows[index].Cells["soluongton"].Value.ToString();
                txtTinhTrang.SelectedItem = dataGridView2.Rows[index].Cells["tinhtrang"].Value.ToString();
                txtMoTa.Text = dataGridView2.Rows[index].Cells["mota"].Value.ToString();
            }
        }

        // Nút Thêm sản phẩm
        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();

                string sql = "INSERT INTO sanpham " +
                             "(tensanpham, hangsanxuat, kichthuoc, loai, gianhap, giaban, soluongton, tinhtrang, mota) " +
                             "VALUES (@ten, @hang, @kt, @loai, @gn, @gb, @sl, @tt, @mt)";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                // Gán tham số từ TextBox / ComboBox / NumericUpDown
                cmd.Parameters.AddWithValue("@ten", txtTenSP.Text);
                cmd.Parameters.AddWithValue("@hang", txtHang.Text);
                cmd.Parameters.AddWithValue("@kt", txtKichThuoc.Text);
                cmd.Parameters.AddWithValue("@loai", txtLoai.Text);
                cmd.Parameters.AddWithValue("@gn", string.IsNullOrWhiteSpace(txtGiaNhap.Text) ? 0 : Convert.ToDecimal(txtGiaNhap.Text));
                cmd.Parameters.AddWithValue("@gb", string.IsNullOrWhiteSpace(txtGiaBan.Text) ? 0 : Convert.ToDecimal(txtGiaBan.Text));
                cmd.Parameters.AddWithValue("@sl", string.IsNullOrWhiteSpace(txtSoLuong.Text) ? 0 : Convert.ToInt32(txtSoLuong.Text));
                cmd.Parameters.AddWithValue("@tt", txtTinhTrang.SelectedItem?.ToString() ?? "mới");
                cmd.Parameters.AddWithValue("@mt", txtMoTa.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM sanpham"); // Load lại DataGridView
            MessageBox.Show("Thêm sản phẩm thành công!");
        }
       

        // xóa các textbox sau khi thêm
        private void ClearFields()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtHang.Clear();
            txtKichThuoc.Clear();
            txtLoai.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            txtTinhTrang.SelectedIndex = 0;
            txtMoTa.Clear();
        }

        private void quanlytivi_Load_1(object sender, EventArgs e)
        {
            
        }
        // nut luu
        private void button6_Click(object sender, EventArgs e)
        {


             
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                MySqlCommand cmd;

                // Thêm mới nếu txtMaSP rỗng
                if (string.IsNullOrWhiteSpace(txtMaSP.Text))
                {
                    string sqlInsert = @"INSERT INTO sanpham 
                        (tensanpham, hangsanxuat, kichthuoc, loai, gianhap, giaban, soluongton, tinhtrang, mota) 
                        VALUES (@ten, @hang, @kt, @loai, @gn, @gb, @sl, @tt, @mt)";
                    cmd = new MySqlCommand(sqlInsert, con);
                }
                else // Cập nhật nếu có masanpham
                {
                    string sqlUpdate = @"UPDATE sanpham SET 
                        tensanpham=@ten, hangsanxuat=@hang, kichthuoc=@kt, loai=@loai, 
                        gianhap=@gn, giaban=@gb, soluongton=@sl, tinhtrang=@tt, mota=@mt
                        WHERE masanpham=@id";
                    cmd = new MySqlCommand(sqlUpdate, con);
                    cmd.Parameters.AddWithValue("@id", txtMaSP.Text);
                }

                cmd.Parameters.AddWithValue("@ten", txtTenSP.Text);
                cmd.Parameters.AddWithValue("@hang", txtHang.Text);
                cmd.Parameters.AddWithValue("@kt", txtKichThuoc.Text);
                cmd.Parameters.AddWithValue("@loai", txtLoai.Text);
                cmd.Parameters.AddWithValue("@gn", string.IsNullOrWhiteSpace(txtGiaNhap.Text) ? 0 : Convert.ToDecimal(txtGiaNhap.Text));
                cmd.Parameters.AddWithValue("@gb", string.IsNullOrWhiteSpace(txtGiaBan.Text) ? 0 : Convert.ToDecimal(txtGiaBan.Text));
                cmd.Parameters.AddWithValue("@sl", string.IsNullOrWhiteSpace(txtSoLuong.Text) ? 0 : Convert.ToInt32(txtSoLuong.Text));
                cmd.Parameters.AddWithValue("@tt", txtTinhTrang.SelectedItem?.ToString() ?? "mới");
                cmd.Parameters.AddWithValue("@mt", txtMoTa.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM sanpham");
            MessageBox.Show("Lưu dữ liệu thành công!");
        }
        // nut sửa
        private void button5_Click(object sender, EventArgs e)
        {


          
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa!");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();

                string sql = "UPDATE sanpham SET " +
                             "tensanpham=@ten, hangsanxuat=@hang, kichthuoc=@kt, loai=@loai, " +
                             "gianhap=@gn, giaban=@gb, soluongton=@sl, tinhtrang=@tt, mota=@mt " +
                             "WHERE masanpham=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@ten", txtTenSP.Text);
                cmd.Parameters.AddWithValue("@hang", txtHang.Text);
                cmd.Parameters.AddWithValue("@kt", txtKichThuoc.Text);
                cmd.Parameters.AddWithValue("@loai", txtLoai.Text);
                cmd.Parameters.AddWithValue("@gn", string.IsNullOrWhiteSpace(txtGiaNhap.Text) ? 0 : Convert.ToDecimal(txtGiaNhap.Text));
                cmd.Parameters.AddWithValue("@gb", string.IsNullOrWhiteSpace(txtGiaBan.Text) ? 0 : Convert.ToDecimal(txtGiaBan.Text));
                cmd.Parameters.AddWithValue("@sl", string.IsNullOrWhiteSpace(txtSoLuong.Text) ? 0 : Convert.ToInt32(txtSoLuong.Text));
                cmd.Parameters.AddWithValue("@tt", txtTinhTrang.SelectedItem?.ToString() ?? "mới"); // ComboBox
                cmd.Parameters.AddWithValue("@mt", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@id", txtMaSP.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM sanpham");
            MessageBox.Show("Cập nhật sản phẩm thành công!");
        }

        
        // nut xoa
        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Chọn sản phẩm để xóa!");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = "DELETE FROM sanpham WHERE masanpham=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", txtMaSP.Text);
                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM sanpham");
            MessageBox.Show("Xóa sản phẩm thành công!");

        }
        // NUT THOAT
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // NUT HUY
        private void button4_Click(object sender, EventArgs e)
        {

            txtMaSP.Clear();
            txtTenSP.Clear();
            txtHang.Clear();
            txtKichThuoc.Clear();
            txtLoai.Clear();
            txtGiaNhap.Clear();
            txtGiaBan.Clear();
            txtSoLuong.Clear();
            if (txtTinhTrang.Items.Count > 0)
                txtTinhTrang.SelectedIndex = 0; // chỉ đặt khi có Item
            txtMoTa.Clear();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Nếu trống → load lại tất cả
                LoadData("SELECT * FROM sanpham");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = "SELECT * FROM sanpham WHERE tensanpham LIKE @kw";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView2.DataSource = dt;
            }
        }

        private void btnHienThiALL_Click(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM sanpham");

            // Xóa TextBox tìm kiếm nếu có
            txtTimKiem.Clear();
        }
    }
}
    

    






