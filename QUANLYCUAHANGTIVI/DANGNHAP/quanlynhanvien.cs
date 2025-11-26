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
    public partial class quanlynhanvien : Form
    {
        string conString = "server=localhost;database=qlcuahangtivi;user=root;password=15082005;";
        public quanlynhanvien()
        {
            InitializeComponent();
            this.Load += quanlynhanvien_Load;
            this.dataGridView2.CellClick += dataGridView2_CellClick;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);

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

        private void quanlynhanvien_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM nhanvien");
           

        }

        // Nút Thêm: clear các TextBox để nhập mới

        private void btnThem_Click(object sender, EventArgs e)
        {
            //
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = "INSERT INTO nhanvien (hoten, vitri, luong, thuong, calam, hieusuat) " +
                             "VALUES (@ht, @vt, @l, @t, @cl, @hs)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ht", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@vt", txtViTri.Text);
                cmd.Parameters.AddWithValue("@l", txtLuong.Text);
                cmd.Parameters.AddWithValue("@t", txtThuong.Text);
                cmd.Parameters.AddWithValue("@cl", txtCalam.Text);
                cmd.Parameters.AddWithValue("@hs", txtHieuSuat.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM nhanvien");
            MessageBox.Show("Thêm nhân viên thành công!");

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                MySqlCommand cmd;

                if (string.IsNullOrWhiteSpace(txtMaNV.Text))
                {
                    string sqlInsert = @"INSERT INTO nhanvien (hoten, vitri, luong, thuong, calam, hieusuat)
                                         VALUES (@ht, @vt, @l, @t, @cl, @hs)";
                    cmd = new MySqlCommand(sqlInsert, con);
                }
                else
                {
                    string sqlUpdate = @"UPDATE nhanvien 
                                         SET hoten=@ht, vitri=@vt, luong=@l, thuong=@t, calam=@cl, hieusuat=@hs 
                                         WHERE manhanvien=@id";
                    cmd = new MySqlCommand(sqlUpdate, con);
                    cmd.Parameters.AddWithValue("@id", txtMaNV.Text);
                }

                cmd.Parameters.AddWithValue("@ht", txtHoTen.Text);
                cmd.Parameters.AddWithValue("@vt", txtViTri.Text);
                cmd.Parameters.AddWithValue("@l", string.IsNullOrWhiteSpace(txtLuong.Text) ? 0 : Convert.ToDecimal(txtLuong.Text));
                cmd.Parameters.AddWithValue("@t", string.IsNullOrWhiteSpace(txtThuong.Text) ? 0 : Convert.ToDecimal(txtThuong.Text));
                cmd.Parameters.AddWithValue("@cl", txtCalam.Text);
                cmd.Parameters.AddWithValue("@hs", string.IsNullOrWhiteSpace(txtHieuSuat.Text) ? 0 : Convert.ToDecimal(txtHieuSuat.Text));

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM nhanvien");
            MessageBox.Show("Lưu dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnLuu_Click(sender, e); // Dùng lại hàm Lưu
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.No) return;

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = "DELETE FROM nhanvien WHERE manhanvien=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", txtMaNV.Text);
                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM nhanvien");

            txtMaNV.Clear();
            txtHoTen.Clear();
            txtViTri.Clear();
            txtLuong.Clear();
            txtThuong.Clear();
            txtCalam.Clear();
            txtHieuSuat.Clear();

            MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        // nut thoat

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Click vào DataGridView để lấy dữ liệu xuống TextBox
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaNV.Text = dataGridView2.Rows[index].Cells["manhanvien"].Value.ToString();
                txtHoTen.Text = dataGridView2.Rows[index].Cells["hoten"].Value.ToString();
                txtViTri.Text = dataGridView2.Rows[index].Cells["vitri"].Value.ToString();
                txtLuong.Text = dataGridView2.Rows[index].Cells["luong"].Value.ToString();
                txtThuong.Text = dataGridView2.Rows[index].Cells["thuong"].Value.ToString();
                txtCalam.Text = dataGridView2.Rows[index].Cells["calam"].Value.ToString();
                txtHieuSuat.Text = dataGridView2.Rows[index].Cells["hieusuat"].Value.ToString();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }

    
    
}
