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

        public DataSet GetTTNhaSoHuu()
        {
            DataSet dataTTNhaSoHuu = new DataSet();
            //SQL Connection
            string query = "EXEC sp_ChuN_XemTTNhaSoHuu @MaChuNha=" + Account.username; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(Account.connectString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataTTNhaSoHuu);

                connection.Close();
            }

            return dataTTNhaSoHuu;
        }
        private void NguoiThue_Load(object sender, EventArgs e)
        {
            this.NhaTableAdapter.Fill(this.tempDataSet.Nha);
        }
        private void button_ThongkeNha_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_XemTTNhaSoHuu";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            ChuNhaGridView.DataSource = dt;
        }
        private void button_CapNhatSoPhong_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrWhiteSpace(textBox_MaNha2.text))
            {
                MessageBox.Show("Please provide MA NHA");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_SLPhong2.text))
            {
                MessageBox.Show("Please provide SO LUONG PHONG");
                return;
            }
             SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_Update_SLPhong";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            //cmd.Parameters.Add("@MaNha", SqlDbType.Char).Value = TextBox_MaNha2.Text;
            cmd.Parameters.Add("@MaNha", SqlDbType.Char).Value = box_MaNha2.SelectedValue;//TextBox_MaNha2.Text;
            cmd.Parameters.Add("@SLPhong", SqlDbType.Int).Value = textBox_SLPhong2.Text;
            
            da.Fill(dt);
            ChuNhaGridView.DataSource = dt;
         } 

        private void button_CapNhatSoPhongFix_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrWhiteSpace(textBox_MaNha2.text))
            {
                MessageBox.Show("Please provide MA NHA");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_SLPhong2.text))
            {
                MessageBox.Show("Please provide SO LUONG PHONG");
                return;
            }
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_Update_SLPhong_Fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@MaNha", SqlDbType.Char).Value = box_MaNha2.SelectedValue;//TextBox_MaNha2.Text;
            cmd.Parameters.Add("@SLPhong", SqlDbType.Int).Value = textBox_SLPhong2.Text;
            
            da.Fill(dt);
            ChuNhaGridView.DataSource = dt;

         } 

        

         private void buttonThemNhaThueFix_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrWhiteSpace(textBox_GiaThue.text))
            {
                MessageBox.Show("Please provide GIA THUE");
                return;
            }
              if (string.IsNullOrWhiteSpace(textBox_NgayHH.text))
            {
                MessageBox.Show("Please provide NGAY HET HAN");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_SLPhong.text))
            {
                MessageBox.Show("Please provide SO LUONG PHONG");
                return;
            }
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_them_NhaThue_fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            //cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = TextBox_MaNha.Text;
            cmd.Parameters.Add("@MaNha", SqlDbType.Char).Value = box_MaNha.SelectedValue;//TextBox_MaNha2.Text;
            cmd.Parameters.Add("@soLuongPhong", SqlDbType.Int).Value = textBox_SLPhong.Text;
            cmd.Parameters.Add("@giaThue", SqlDbType.Money).Value = textBox_GiaThue.Text;
            cmd.Parameters.Add("@ngayHetHan", SqlDbType.DateTime).Value = textBox_NgayHH.Text;
            da.Fill(dt);
            ChuNhaGridView.DataSource = dt;
         } 
        private void button_ThemNhaThue_Click(object sender, EventArgs e)
        {
             if (string.IsNullOrWhiteSpace(textBox_GiaThue.text))
            {
                MessageBox.Show("Please provide GIA THUE");
                return;
            }
              if (string.IsNullOrWhiteSpace(textBox_NgayHH.text))
            {
                MessageBox.Show("Please provide NGAY HET HAN");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox_SLPhong.text))
            {
                MessageBox.Show("Please provide SO LUONG PHONG");
                return;
            }
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_them_NhaThue_fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            //cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = TextBox_MaNha.Text;
            cmd.Parameters.Add("@MaNha", SqlDbType.Char).Value = box_MaNha.SelectedValue;//TextBox_MaNha2.Text;
            cmd.Parameters.Add("@soLuongPhong", SqlDbType.Int).Value = textBox_SLPhong.Text;
            cmd.Parameters.Add("@giaThue", SqlDbType.Money).Value = textBox_GiaThue.Text;
            cmd.Parameters.Add("@ngayHetHan", SqlDbType.DateTime).Value = textBox_NgayHH.Text;
            da.Fill(dt);
            ChuNhaGridView.DataSource = dt;
         } 

    }
}
