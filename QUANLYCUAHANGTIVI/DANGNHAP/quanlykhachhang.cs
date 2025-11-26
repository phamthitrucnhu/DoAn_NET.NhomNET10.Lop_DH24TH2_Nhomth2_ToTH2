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
    public partial class quanlykhachhang : Form
    {
        string conString = "server=localhost;database=qlcuahangtivi;user=root;password=15082005;";
        public quanlykhachhang()
        {
            InitializeComponent();
            this.Load += quanlykhachhang_Load;
            // Gán sự kiện CellClick cho dataGridView2
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
           
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = "INSERT INTO khachhang (hoten, sodienthoai, diachi, lichsumuahang, chinhsach) " +
                             "VALUES (@ht, @sdt, @dc, @ls, @cs)";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ht", txtHoten.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                cmd.Parameters.AddWithValue("@dc", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@ls", textBox2.Text);
                cmd.Parameters.AddWithValue("@cs", txtChinhSach.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM khachhang");
            MessageBox.Show("Thêm khách hàng thành công!");
        }

        

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();

                MySqlCommand cmd;

                // Nếu txtMakh trống → thêm mới
                if (string.IsNullOrWhiteSpace(txtMakh.Text))
                {
                    string sqlInsert = "INSERT INTO khachhang (hoten, sodienthoai, diachi, lichsumuahang, chinhsach) " +
                                       "VALUES (@ht, @sdt, @dc, @ls, @cs)";
                    cmd = new MySqlCommand(sqlInsert, con);
                }
                else // Có ID → cập nhật
                {
                    string sqlUpdate = "UPDATE khachhang SET hoten=@ht, sodienthoai=@sdt, diachi=@dc, " +
                                       "lichsumuahang=@ls, chinhsach=@cs WHERE makhachhang=@id";
                    cmd = new MySqlCommand(sqlUpdate, con);
                    cmd.Parameters.AddWithValue("@id", txtMakh.Text);
                }

                // Thêm parameter chung
                cmd.Parameters.AddWithValue("@ht", txtHoten.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                cmd.Parameters.AddWithValue("@dc", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@ls", textBox2.Text);
                cmd.Parameters.AddWithValue("@cs", txtChinhSach.Text);

                cmd.ExecuteNonQuery();
            }

            // Load lại DataGridView
            LoadData("SELECT * FROM khachhang");

            MessageBox.Show("Lưu dữ liệu thành công!");
        

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {


          
            if (string.IsNullOrWhiteSpace(txtMakh.Text))
            {
                MessageBox.Show("Vui lòng chọn khách hàng để cập nhật!");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = "UPDATE khachhang SET hoten=@ht, sodienthoai=@sdt, diachi=@dc, " +
                             "lichsumuahang=@ls, chinhsach=@cs WHERE makhachhang=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ht", txtHoten.Text);
                cmd.Parameters.AddWithValue("@sdt", txtSdt.Text);
                cmd.Parameters.AddWithValue("@dc", txtDiachi.Text);
                cmd.Parameters.AddWithValue("@ls", textBox2.Text);
                cmd.Parameters.AddWithValue("@cs", txtChinhSach.Text);
                cmd.Parameters.AddWithValue("@id", txtMakh.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM khachhang");
            MessageBox.Show("Cập nhật thành công!");
        }

        

        
        // nút thoát 
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (txtMakh.Text == "")
            {
                MessageBox.Show("Chọn khách hàng để xóa!");
                return;
            }

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                con.Open();
                string sql = "DELETE FROM khachhang WHERE makhachhang=@id";

                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", txtMakh.Text);

                cmd.ExecuteNonQuery();
            }

            LoadData("SELECT * FROM khachhang");
            MessageBox.Show("Xóa khách hàng thành công!");
        }

        

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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

        private void quanlykhachhang_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM khachhang");


        }
        // dùng để lâys dl trên datagridview xuống để sửa ....
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMakh.Text = dataGridView2.Rows[index].Cells["makhachhang"].Value.ToString();
                txtHoten.Text = dataGridView2.Rows[index].Cells["hoten"].Value.ToString();
                txtSdt.Text = dataGridView2.Rows[index].Cells["sodienthoai"].Value.ToString();
                txtDiachi.Text = dataGridView2.Rows[index].Cells["diachi"].Value.ToString();
                textBox2.Text = dataGridView2.Rows[index].Cells["lichsumuahang"].Value.ToString();
                txtChinhSach.Text = dataGridView2.Rows[index].Cells["chinhsach"].Value.ToString();
            }
        }

    }
}
