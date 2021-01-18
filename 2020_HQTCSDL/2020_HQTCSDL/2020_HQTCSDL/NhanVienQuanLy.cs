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
    public partial class NhanVienQuanLy : Form
    {
        public NhanVienQuanLy()
        {
            InitializeComponent();
            this.textbox_role.AppendText(Account.username);
            SqlConnection con = new SqlConnection(Account.connectString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select top 1 MaCN from ChiNhanh where MaNV=@maNV", con);
            cmd.Parameters.AddWithValue("@maNV", Account.username);
            SqlDataReader myreader = cmd.ExecuteReader();
            if (myreader.Read())
                 this.textBox_CN.AppendText(myreader[0].ToString());
            
        }
       

        private void CEOGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void capnhatLuong_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_hsLuong.Text)|| string.IsNullOrWhiteSpace(textBox_MaNV.Text))
            {
                MessageBox.Show("Please provide information");
                return;
            }
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_tang_Luong_nhanvien";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maNV", SqlDbType.Char).Value = textBox_MaNV.Text;
            cmd.Parameters.Add("@Luong", SqlDbType.Money).Value = textBox_hsLuong.Text;
            cmd.Parameters.Add("@maCN", SqlDbType.Char).Value = textBox_CN.Text;

            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            
            cmd.CommandText = "select * from NhanVien where MaCN=@maCN";
            cmd.Parameters.AddWithValue("@maCN", textBox_CN.Text);
            
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
