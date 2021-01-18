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
    public partial class NhanVien : Form
    {
        public NhanVien()
        {
            InitializeComponent();
            this.textbox_role.AppendText(Account.username);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "select * from Nha where MaNV=@maNV";
            cmd.Parameters.AddWithValue("@maNV", textbox_role.Text);

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CEOGridView.DataSource = dt;
            con.Close();
        }

        private void themHD_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_MaNT.Text) || string.IsNullOrWhiteSpace(textBox_MaNha.Text))
                {
                    MessageBox.Show("Please provide information");
                    return;
                }
                SqlConnection con = new SqlConnection(Account.connectString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "sp_them_HDNhaBan_DL";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                cmd.Parameters.Add("@maNV", SqlDbType.Char).Value = textbox_role.Text;
                cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaNha.Text;
                cmd.Parameters.Add("@maNT", SqlDbType.Char).Value = textBox_MaNT.Text;
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                CEOGridView.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox_MaNT_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "CapNhapSauHopDong_Error";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@mhd", SqlDbType.Char).Value = textBox1.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_MaNT.Text) || string.IsNullOrWhiteSpace(textBox_MaNha.Text))
                {
                    MessageBox.Show("Please provide information");
                    return;
                }
                SqlConnection con = new SqlConnection(Account.connectString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "sp_them_HDNhaBan_Fixed";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                cmd.Parameters.Add("@maNV", SqlDbType.Char).Value = textbox_role.Text;
                cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaNha.Text;
                cmd.Parameters.Add("@maNT", SqlDbType.Char).Value = textBox_MaNT.Text;
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                CEOGridView.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "CapNhapSauHopDong";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            cmd.Parameters.Add("@mhd", SqlDbType.Char).Value = textBox1.Text;
            da.Fill(dt);
            CEOGridView.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_xem_NguoiThue";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CEOGridView.DataSource = dt;
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_xem_NguoiThue_Fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CEOGridView.DataSource = dt;
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_MaNT.Text) || string.IsNullOrWhiteSpace(textBox_MaNha.Text))
                {
                    MessageBox.Show("Please provide information");
                    return;
                }
                SqlConnection con = new SqlConnection(Account.connectString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "sp_them_HDNhaBan_DL_2";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                cmd.Parameters.Add("@maNV", SqlDbType.Char).Value = textbox_role.Text;
                cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaNha.Text;
                cmd.Parameters.Add("@maNT", SqlDbType.Char).Value = textBox_MaNT.Text;
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                CEOGridView.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_MaNT.Text) || string.IsNullOrWhiteSpace(textBox_MaNha.Text))
                {
                    MessageBox.Show("Please provide information");
                    return;
                }
                SqlConnection con = new SqlConnection(Account.connectString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "sp_them_HDNhaBan_DL_Fixed";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                cmd.Parameters.Add("@maNV", SqlDbType.Char).Value = textbox_role.Text;
                cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaNha.Text;
                cmd.Parameters.Add("@maNT", SqlDbType.Char).Value = textBox_MaNT.Text;
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                CEOGridView.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_MaNT.Text) || string.IsNullOrWhiteSpace(textBox_MaNha.Text))
                {
                    MessageBox.Show("Please provide information");
                    return;
                }
                SqlConnection con = new SqlConnection(Account.connectString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "sp_them_HDNhaBan_DL_2_Fixed";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                cmd.Parameters.Add("@maNV", SqlDbType.Char).Value = textbox_role.Text;
                cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox_MaNha.Text;
                cmd.Parameters.Add("@maNT", SqlDbType.Char).Value = textBox_MaNT.Text;
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                CEOGridView.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text) ||string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please provide information");
                    return;
                }
                SqlConnection con = new SqlConnection(Account.connectString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "sp_updateLSX";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                cmd.Parameters.Add("@maNV", SqlDbType.Char).Value = textbox_role.Text;
                cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox3.Text;
                cmd.Parameters.Add("@maNT", SqlDbType.Char).Value = textBox2.Text;
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                CEOGridView.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please provide information");
                    return;
                }
                SqlConnection con = new SqlConnection(Account.connectString);
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "sp_updateLSX_Fixed";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                cmd.Parameters.Add("@maNV", SqlDbType.Char).Value = textbox_role.Text;
                cmd.Parameters.Add("@maNha", SqlDbType.Char).Value = textBox3.Text;
                cmd.Parameters.Add("@maNT", SqlDbType.Char).Value = textBox2.Text;
                cmd.ExecuteNonQuery();
                da.Fill(dt);
                CEOGridView.DataSource = dt;
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }
