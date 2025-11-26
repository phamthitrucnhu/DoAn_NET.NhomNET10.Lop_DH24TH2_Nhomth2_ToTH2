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
using static System.Windows.Forms.LinkLabel;

namespace DANGNHAP
{
    public partial class quanlyhoadon : Form
    {
        string conString = "server=localhost;database=qlcuahangtivi;user=root;password=15082005;";
        public quanlyhoadon()
        {
            InitializeComponent();
            this.Load += quanlyhoadon_Load;
            this.dataGridView2.CellClick += DataGridView2_CellClick;

            this.dataGridView1.CellClick += dataGridView1_CellClick;
            
        }
        private void LoadData(string query)
        {
          
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt; // dùng cùng DataGridView
                // ẩn cột 
                dataGridView1.Columns["makhachhang"].Visible = false;
                dataGridView1.Columns["manhanvien"].Visible = false;

            }
        }
        
      

        private void quanlyhoadon_Load(object sender, EventArgs e)
        {

            try
            {
                LoadData("SELECT * FROM hoadon");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message);
            }
            if (dataGridView1.Rows.Count > 0 && dataGridView1.Rows[0].Cells["mahoadon"].Value != null)
            {
                string firstHD = dataGridView1.Rows[0].Cells["mahoadon"].Value.ToString();
                LoadChiTietHD(firstHD);
            }

        }
        // nut tao hd
        private void button1_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = @"INSERT INTO hoadon 
                   (ngayban, tenkhachhang, tongtien, nhanvienbanhang, hinhthuctt, ghichu) 
                   VALUES (@ngay, @tenkh, @tongtien, @nv, @hinhthuc, @ghichu)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ngay", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@tenkh", txtKhachHang.Text);
                cmd.Parameters.AddWithValue("@tongtien", string.IsNullOrWhiteSpace(txtTongTien.Text) ? 0 : Convert.ToDecimal(txtTongTien.Text));
                cmd.Parameters.AddWithValue("@nv", txtNV.Text);
                cmd.Parameters.AddWithValue("@hinhthuc", txtHinhThucTT.SelectedItem?.ToString() ?? "");

                cmd.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM hoadon");
            MessageBox.Show("Thêm hóa đơn thành công!");

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                MySqlCommand cmd;

                if (string.IsNullOrWhiteSpace(txtMaHD.Text)) // Thêm mới
                {
                    string sqlInsert = @"INSERT INTO hoadon 
                        (ngayban, tenkhachhang, tongtien, nhanvienbanhang, hinhthuctt, ghichu) 
                        VALUES (@ngay, @tenkh, @tongtien, @nv, @hinhthuc, @ghichu)";
                    cmd = new MySqlCommand(sqlInsert, con);
                }
                else // Cập nhật
                {
                    string sqlUpdate = @"UPDATE hoadon SET 
                        ngayban=@ngay, tenkhachhang=@tenkh, tongtien=@tongtien, 
                        nhanvienbanhang=@nv, hinhthuctt=@hinhthuc, ghichu=@ghichu
                        WHERE mahoadon=@id";
                    cmd = new MySqlCommand(sqlUpdate, con);
                    cmd.Parameters.AddWithValue("@id", txtMaHD.Text);
                }

                cmd.Parameters.AddWithValue("@ngay", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@tenkh", txtKhachHang.Text);
                cmd.Parameters.AddWithValue("@tongtien", string.IsNullOrWhiteSpace(txtTongTien.Text) ? 0 : Convert.ToDecimal(txtTongTien.Text));
                cmd.Parameters.AddWithValue("@nv", txtNV.Text);
                cmd.Parameters.AddWithValue("@hinhthuc", txtHinhThucTT.SelectedItem?.ToString() ?? "");

                cmd.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM hoadon");
            MessageBox.Show("Lưu hóa đơn thành công!");
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
        
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để sửa!");
                return;
            }

            int maHD;
            if (!int.TryParse(txtMaHD.Text, out maHD))
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ!");
                return;
            }

            decimal tongTien = 0;
            if (!decimal.TryParse(txtTongTien.Text, out tongTien))
            {
                MessageBox.Show("Tổng tiền không hợp lệ! Vui lòng nhập số hợp lệ.");
                return;
            }

            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();

                    string sql = @"UPDATE hoadon SET 
                           ngayban=@ngay, 
                           tenkhachhang=@tenkh, 
                           tongtien=@tongtien, 
                           nhanvienbanhang=@nv, 
                           hinhthuctt=@hinhthuc, 
                           ghichu=@ghichu
                           WHERE mahoadon=@id";

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@ngay", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@tenkh", txtKhachHang.Text.Trim());
                        cmd.Parameters.AddWithValue("@tongtien", tongTien);
                        cmd.Parameters.AddWithValue("@nv", txtNV.Text.Trim());
                        cmd.Parameters.AddWithValue("@hinhthuc", txtHinhThucTT.SelectedItem?.ToString() ?? "");
                        cmd.Parameters.AddWithValue("@ghichu", txtGhiChu.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", maHD);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Cập nhật hóa đơn thành công!");
                        else
                            MessageBox.Show("Không tìm thấy hóa đơn để cập nhật.");
                    }
                }

                // Load lại dữ liệu sau khi sửa
                LoadData("SELECT * FROM hoadon");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật hóa đơn: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }




        private void btnThemChiTiet_Click(object sender, EventArgs e)
        {

        
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước khi thêm chi tiết!");
                return;
            }

            int soLuong = 0;
            decimal donGia = 0;

            if (!int.TryParse(txtSL.Text, out soLuong))
                soLuong = 0;

            if (!decimal.TryParse(txtDonGia.Text, out donGia))
                donGia = 0;

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = @"INSERT INTO chitiethoadon 
                       (mahoadon, masanpham, tensanpham, soluong, dongia)
                       VALUES (@mahd, @msp, @tensp, @sl, @dongia)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@mahd", txtMaHD.Text);
                cmd.Parameters.AddWithValue("@msp", txtMaSP.Text);
                cmd.Parameters.AddWithValue("@tensp", txtTenSP.Text);
                cmd.Parameters.AddWithValue("@sl", soLuong);
                cmd.Parameters.AddWithValue("@dongia", donGia);
                cmd.ExecuteNonQuery();
            }

            LoadChiTietHD(txtMaHD.Text);
            MessageBox.Show("Thêm chi tiết hóa đơn thành công!");
        }

        

        private void btnXoaHD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaHD.Text))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn để xóa!");
                return;
            }

            int maHD;
            if (!int.TryParse(txtMaHD.Text, out maHD))
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ!");
                return;
            }

            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();

                    // 1. Xóa chi tiết hóa đơn trước
                    string sqlChiTiet = "DELETE FROM chitiethoadon WHERE mahoadon=@id";
                    using (MySqlCommand cmdChiTiet = new MySqlCommand(sqlChiTiet, con))
                    {
                        cmdChiTiet.Parameters.AddWithValue("@id", maHD);
                        cmdChiTiet.ExecuteNonQuery();
                    }

                    // 2. Xóa hóa đơn
                    string sqlHD = "DELETE FROM hoadon WHERE mahoadon=@id";
                    using (MySqlCommand cmdHD = new MySqlCommand(sqlHD, con))
                    {
                        cmdHD.Parameters.AddWithValue("@id", maHD);
                        int rowsAffected = cmdHD.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            MessageBox.Show("Xóa hóa đơn thành công!");
                        else
                            MessageBox.Show("Không tìm thấy hóa đơn để xóa.");
                    }
                }

                // 3. Load lại dữ liệu
                LoadData("SELECT * FROM hoadon");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //----------- CLICK CHỌN DÒNG TRÊN DATAGRIDVIEW -------------
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaHD.Text = dataGridView1.Rows[index].Cells["mahoadon"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[index].Cells["ngayban"].Value);
                txtKhachHang.Text = dataGridView1.Rows[index].Cells["tenkhachhang"].Value.ToString();
                txtTongTien.Text = dataGridView1.Rows[index].Cells["tongtien"].Value.ToString();
                txtNV.Text = dataGridView1.Rows[index].Cells["nhanvienbanhang"].Value.ToString();
                txtHinhThucTT.Text = dataGridView1.Rows[index].Cells["hinhthuctt"].Value.ToString();


                txtGhiChu.Text = dataGridView1.Rows[index].Cells["ghichu"].Value.ToString();
            }
        }
            private void LoadChiTietHD(string maHD)
             {

            try
            {
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();
                    string query = "SELECT * FROM chitiethoadon WHERE mahoadon=@id";
                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@id", maHD);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView2.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load chi tiết hóa đơn: " + ex.Message);
            }
        }
        private void DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaHD.Text = dataGridView2.Rows[index].Cells["mahoadon"].Value.ToString();
                // Các dòng gán TextBox khác từ dataGridView2

                // ... các dòng gán TextBox khác

                // Load chi tiết hóa đơn
                LoadChiTietHD(txtMaHD.Text);
            }
        }


    }
}


