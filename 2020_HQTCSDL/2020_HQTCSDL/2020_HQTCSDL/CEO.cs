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
    public partial class CEO : Form
    {
        public string conString = "Data Source=LAPTOP-B644G9B6\\SQLEXPRESS;Initial Catalog=HQT_CSDL;Integrated Security=True";
        public CEO()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 TimNha = new Form2();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (TimNha.ShowDialog() == DialogResult.OK)
            {
                //TimNha.Show();
                string query = "Select * from Nha where MaNha='" + TimNha.Myval.Trim() + "'";
                SqlDataAdapter cmd1 = new SqlDataAdapter(query, con);
                DataTable ck1 = new DataTable();
                cmd1.Fill(ck1);
                dataGridView1.DataSource = ck1;
                con.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 TimNT = new Form3();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (TimNT.ShowDialog() == DialogResult.OK)
            {
                //TimNha.Show();
                string query = "Select * from NguoiThue where MaNT='" + TimNT.Myval.Trim() + "'";
                SqlDataAdapter cmd2 = new SqlDataAdapter(query, con);
                DataTable ck2 = new DataTable();
                cmd2.Fill(ck2);
                dataGridView1.DataSource = ck2;
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 TX = new Form4();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (TX.ShowDialog() == DialogResult.OK)
            {
                string q = "ThemNV";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@manv", SqlDbType.Char).Value = TX.MyvalMaNV.Trim();
                cmd.Parameters.AddWithValue("@tennv", SqlDbType.NVarChar).Value = TX.MyvalTenNV.Trim();
                cmd.Parameters.AddWithValue("@diachi", SqlDbType.NVarChar).Value = TX.Myvaldiachi.Trim();
                cmd.Parameters.AddWithValue("@sdt", SqlDbType.Char).Value = TX.Myvalsdt.Trim();
                cmd.Parameters.AddWithValue("@gt", SqlDbType.TinyInt).Value = TX.Myvalgt.Trim();
                cmd.Parameters.AddWithValue("@ngaysinh", SqlDbType.DateTime).Value = TX.Myvalns.Trim();
                cmd.Parameters.AddWithValue("@luong", SqlDbType.Money).Value = TX.Myvalluong.Trim();
                cmd.Parameters.AddWithValue("@mcn", SqlDbType.Char).Value = TX.Myvalcn.Trim();
                cmd.Parameters.AddWithValue("@maql", SqlDbType.Char).Value = TX.Myvalnvql.Trim();
                cmd.ExecuteNonQuery();
                string showUp = "Select * from NhanVien";
                SqlDataAdapter cmd3 = new SqlDataAdapter(showUp, con);
                DataTable ck3 = new DataTable();
                cmd3.Fill(ck3);
                dataGridView1.DataSource = ck3;
                con.Close();
            }
            else if(TX.ShowDialog()==DialogResult.Yes)
            {
                string q = "XoaNV";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@manv", SqlDbType.Int).Value = TX.MyvalMaNV.Trim();
                cmd.ExecuteNonQuery();
                string showUp = "Select * from NhanVien";
                SqlDataAdapter cmd3 = new SqlDataAdapter(showUp, con);
                DataTable ck3 = new DataTable();
                cmd3.Fill(ck3);
                dataGridView1.DataSource = ck3;
                con.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CapNhapNV CNNV = new CapNhapNV();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (CNNV.ShowDialog() == DialogResult.OK)
            {
                string q = "CapNhapNhanVien";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@manv", SqlDbType.Char).Value = CNNV.MyvalMaNV.Trim();
                cmd.Parameters.AddWithValue("@luong", SqlDbType.Money).Value = CNNV.Myvalluong.Trim();
                cmd.Parameters.AddWithValue("@mcn", SqlDbType.Char).Value = CNNV.Myvalcn.Trim();
                cmd.ExecuteNonQuery();
                string showUp = "Select * from NhanVien";
                SqlDataAdapter cmd3 = new SqlDataAdapter(showUp, con);
                DataTable ck3 = new DataTable();
                cmd3.Fill(ck3);
                dataGridView1.DataSource = ck3;
                con.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 TXCN = new Form6();
            TXCN.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CapNhapChiNhanh CNCN = new CapNhapChiNhanh();
            CNCN.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            TimNV TNV = new TimNV();
            TNV.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form8 TimCN = new Form8();
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (TimCN.ShowDialog() == DialogResult.OK)
            {
                //TimNha.Show();
                string query = "Select * from ChiNhanh where MaCN='" + TimCN.Myval.Trim() + "'";
                SqlDataAdapter cmd2 = new SqlDataAdapter(query, con);
                DataTable ck2 = new DataTable();
                cmd2.Fill(ck2);
                dataGridView1.DataSource = ck2;
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = "Select * from LichSuXem";
            SqlDataAdapter cmd1 = new SqlDataAdapter(query, con);
            DataTable ck1 = new DataTable();
            cmd1.Fill(ck1);
            dataGridView1.DataSource = ck1;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = "Select * from HopDong";
            SqlDataAdapter cmd1 = new SqlDataAdapter(query, con);
            DataTable ck1 = new DataTable();
            cmd1.Fill(ck1);
            dataGridView1.DataSource = ck1;
            con.Close();
        }
    }
}
