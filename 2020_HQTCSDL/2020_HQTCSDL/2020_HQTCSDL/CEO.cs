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
        
        public CEO()
        {
            InitializeComponent();
            this.textbox_role.AppendText(Account.username);

        }

        private void CEO_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tempDataSet.ChiNhanh' table. You can move, or remove it, as needed.
            //this.chiNhanhTableAdapter.Fill(this.tempDataSet.ChiNhanh);
            CC();
           
        }
        public void CC()
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select MaCN from ChiNhanh";
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["MaCN"].ToString());
            }
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonThongkeNV_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from NhanVien";
            //cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void capnhatLuong_button_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(textBox_hsLuong.Text))
            {
                MessageBox.Show("Please provide He so Luong");
                return;
            }
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_tang_luong_theochinhanh";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maCN", SqlDbType.Char).Value = box_ChiNhanh.SelectedValue;
            cmd.Parameters.Add("@hesoLuong", SqlDbType.Float).Value = textBox_hsLuong.Text;
            
            da.Fill(dt);
            CEOGridView.DataSource = dt;



        }

        private void box_ChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_hsLuong.Text))
            {
                MessageBox.Show("Please provide He so Luong");
                return;
            }
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_tang_luong_theochinhanh_Fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@maCN", SqlDbType.Char).Value = box_ChiNhanh.SelectedValue;
            cmd.Parameters.Add("@hesoLuong", SqlDbType.Float).Value = textBox_hsLuong.Text;

            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "ChuyenNV_Error";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@manv", SqlDbType.Char).Value = textBox1.Text;
            cmd.Parameters.Add("@mcn", SqlDbType.Char).Value = comboBox1.SelectedItem;
            da.Fill(dt);
            CEOGridView.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "ChuyenNV";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@manv", SqlDbType.Char).Value = textBox1.Text;
            cmd.Parameters.Add("@mcn", SqlDbType.Char).Value = comboBox1.SelectedItem;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }
    }
}
