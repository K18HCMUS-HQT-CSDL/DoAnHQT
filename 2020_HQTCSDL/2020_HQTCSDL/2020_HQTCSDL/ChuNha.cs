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

namespace _2020_HQTCSDL
{
    public partial class ChuNha : Form
    {
        public ChuNha()
        {
            InitializeComponent();
            this.textbox_role.AppendText(Account.username);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "CapNhapPhong_Error";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@manha", SqlDbType.Char).Value = textBox2.Text;
            cmd.Parameters.Add("@spt", SqlDbType.Char).Value = textBox3.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from Nha where MaChuNha=@mcn";
            cmd.Parameters.AddWithValue("@mcn", Account.username);
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "CapNhapPhong";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@manha", SqlDbType.Char).Value = textBox2.Text;
            cmd.Parameters.Add("@spt", SqlDbType.Char).Value = textBox3.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void themHD_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_MaHD.Text)|| string.IsNullOrWhiteSpace(textBox_MaNha.Text)|| string.IsNullOrWhiteSpace(textBox_MaNT.Text)|| string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please provide information!");
                return;
            }
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_them_NhaThue";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maChuNha", SqlDbType.Char).Value = Account.username;
            cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaHD.Text;
            cmd.Parameters.Add("@soLuongPhong", SqlDbType.Int).Value = textBox_MaNha.Text;
            cmd.Parameters.Add("@giaThue", SqlDbType.Money).Value = textBox_MaNT.Text;
            cmd.Parameters.Add("@ngayHetHan", SqlDbType.DateTime).Value = textBox1.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_MaHD.Text) || string.IsNullOrWhiteSpace(textBox_MaNha.Text) || string.IsNullOrWhiteSpace(textBox_MaNT.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please provide information!");
                return;
            }
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_them_NhaThue_Fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maChuNha", SqlDbType.Char).Value = Account.username;
            cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaHD.Text;
            cmd.Parameters.Add("@soLuongPhong", SqlDbType.Int).Value = textBox_MaNha.Text;
            cmd.Parameters.Add("@giaThue", SqlDbType.Money).Value = textBox_MaNT.Text;
            cmd.Parameters.Add("@ngayHetHan", SqlDbType.DateTime).Value = textBox1.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Please provide information!");
                return;
            }
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_them_NhaBan";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maChuNha", SqlDbType.Char).Value = Account.username;
            cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox4.Text;
            cmd.Parameters.Add("@soLuongPhong", SqlDbType.Int).Value = textBox5.Text;
            cmd.Parameters.Add("@giaBan", SqlDbType.Money).Value = textBox6.Text;
            cmd.Parameters.Add("@dieuKien", SqlDbType.Text).Value = textBox7.Text;
            cmd.Parameters.Add("@ngayHetHan", SqlDbType.DateTime).Value = textBox8.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Please provide information!");
                return;
            }
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_them_NhaBan_Fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maChuNha", SqlDbType.Char).Value = Account.username;
            cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox4.Text;
            cmd.Parameters.Add("@soLuongPhong", SqlDbType.Int).Value = textBox5.Text;
            cmd.Parameters.Add("@giaBan", SqlDbType.Money).Value = textBox6.Text;
            cmd.Parameters.Add("@dieuKien", SqlDbType.Text).Value = textBox7.Text;
            cmd.Parameters.Add("@ngayHetHan", SqlDbType.DateTime).Value = textBox8.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void themHD_button_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_them_NhaThue";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maChuNha", SqlDbType.Char).Value = textbox_role.Text;
            cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaHD.Text;
            cmd.Parameters.Add("@soLuongPhong", SqlDbType.Int).Value = textBox_MaNha.Text;
            cmd.Parameters.Add("@giaThue", SqlDbType.Money).Value = textBox_MaNT.Text;
            cmd.Parameters.Add("@ngayHetHan", SqlDbType.DateTime).Value = textBox1.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_them_NhaThue_fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maChuNha", SqlDbType.Char).Value = textbox_role.Text;
            cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaHD.Text;
            cmd.Parameters.Add("@soLuongPhong", SqlDbType.Int).Value = textBox_MaNha.Text;
            cmd.Parameters.Add("@giaThue", SqlDbType.Money).Value = textBox_MaNT.Text;
            cmd.Parameters.Add("@ngayHetHan", SqlDbType.DateTime).Value = textBox1.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void textBox_MaNT_TextChanged(object sender, EventArgs e)
        {

        }
        /*
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_them_NhaBan";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maChuNha", SqlDbType.Char).Value = textbox_role.Text;
            cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaHD.Text;
            cmd.Parameters.Add("@soLuongPhong", SqlDbType.Int).Value = textBox_MaNha.Text;
            cmd.Parameters.Add("@giaBan", SqlDbType.Money).Value = textBox_MaNT.Text;
            cmd.Parameters.Add("@ngayHetHan", SqlDbType.DateTime).Value = textBox1.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_them_NhaBan_fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maChuNha", SqlDbType.Char).Value = textbox_role.Text;
            cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaHD.Text;
            cmd.Parameters.Add("@soLuongPhong", SqlDbType.Int).Value = textBox_MaNha.Text;
            cmd.Parameters.Add("@giaBan", SqlDbType.Money).Value = textBox_MaNT.Text;
            cmd.Parameters.Add("@ngayHetHan", SqlDbType.DateTime).Value = textBox1.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }
        */
        private void textbox_role_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
