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
    public partial class NguoiThue : Form
    {
        public NguoiThue()
        {
            InitializeComponent();
        }
        
        public DataSet GetTTNguoiThue()
        {

             DataSet dataTTNguoiThue = new DataSet();
            //SQL Connection
            string query = "EXEC sp_NT_XemTTNguoiThue @MaNT=" + Account.username; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(Account.connectString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataTTNguoiThue);

                connection.Close();
            }

            return dataTTNguoiThue;
            
        }

        public DataSet GetNhaBan()
        {
            DataSet dataNhaBan = new DataSet();
            //SQL Connection
            //Nên có 1 class lưu connection string chuẩn của nhóm khi merge code
            //string connectionString = @"Data Source=DESKTOP-R4GG4RM;Initial Catalog=HQT_CSDL;Integrated Security=True";
            string query = "EXEC sp_xem_NhaBan"; 
            using (SqlConnection connection = new SqlConnection(Account.connectString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataNhaBan);

                connection.Close();
            }

            return dataNhaBan;
        }

        public DataSet GetNhaThue()
        {
            DataSet dataNhaThue = new DataSet();
            //SQL Connection
            //Nên có 1 class lưu connection string chuẩn của nhóm khi merge code
            //string connectionString = @"Data Source=DESKTOP-R4GG4RM;Initial Catalog=HQT_CSDL;Integrated Security=True";
            string query = "EXEC sp_xem_NhaThue"; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(Account.connectString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataNhaThue);

                connection.Close();
            }

            return dataNhaThue;
        }

        private void text_NumberOnly(object sender, KeyEventArgs e)
        {
            //Allow navigation keyboard arrows
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageUp:
                case Keys.PageDown:
                case Keys.Delete:
                    e.SuppressKeyPress = false;
                    return;
                default:
                    break;
            }

            //Block non-number characters
            char currentKey = (char)e.KeyCode;
            bool modifier = e.Control || e.Alt || e.Shift;
            bool nonNumber = char.IsLetter(currentKey) ||
                             char.IsSymbol(currentKey) ||
                             char.IsWhiteSpace(currentKey) ||
                             char.IsPunctuation(currentKey);

            if (!modifier && nonNumber)
                e.SuppressKeyPress = true;

            //Handle pasted Text
            if (e.Control && e.KeyCode == Keys.V)
            {
                //Preview paste data (removing non-number characters)
                string pasteText = Clipboard.GetText();
                string strippedText = "";
                for (int i = 0; i < pasteText.Length; i++)
                {
                    if (char.IsDigit(pasteText[i]))
                        strippedText += pasteText[i].ToString();
                }

                if (strippedText != pasteText)
                {
                    //There were non-numbers in the pasted text
                    e.SuppressKeyPress = true;

                    //OPTIONAL: Manually insert text stripped of non-numbers
                    TextBox me = (TextBox)sender;
                    int start = me.SelectionStart;
                    string newTxt = me.Text;
                    newTxt = newTxt.Remove(me.SelectionStart, me.SelectionLength); //remove highlighted text
                    newTxt = newTxt.Insert(me.SelectionStart, strippedText); //paste
                    me.Text = newTxt;
                    me.SelectionStart = start + strippedText.Length;
                }
                else
                    e.SuppressKeyPress = false;
            }
        }

        private void NguoiThue_Load(object sender, EventArgs e)
        {
            textbox_role.Text = Account.username;
            DataSet tempData = GetTTNguoiThue();
            textBox_MaHD.Text = tempData.Tables[0].Rows[0]["TenNT"].ToString(); //Hiện tên người thuê
            textBox1.Text = tempData.Tables[0].Rows[0]["DiaChi"].ToString(); //Hiện địa chỉ
            textBox_MaNha.Text = tempData.Tables[0].Rows[0]["SDT"].ToString(); //Hiện số điện thoại
            textBox_MaNT.Text = tempData.Tables[0].Rows[0]["TieuChi"].ToString(); //Hiện số điện thoại
            textBox2.Text = tempData.Tables[0].Rows[0]["YeuCau"].ToString(); //Hiện số điện thoại
        }

        private void butt_thongkeNhaBan_Click(object sender, EventArgs e) //Thống kê nhà bán
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_xem_NhaBan_Fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CEOGridView.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e) //Thống kê nhà bán fix
        {
            SqlConnection con = new SqlConnection(Account.connectString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "sp_xem_NhaBan_Fixed";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            CEOGridView.DataSource = dt;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e) //Thống kê nhà thuê
        {
            CEOGridView.DataSource = GetNhaThue().Tables[0];
            CEOGridView.Columns["MaNha"].DisplayIndex = 0;
            CEOGridView.Refresh();
        }

        private void button4_Click(object sender, EventArgs e) //Thống kê nhà thuê fix
        {
            CEOGridView.DataSource = GetNhaThue().Tables[0];
            CEOGridView.Columns["MaNha"].DisplayIndex = 0;
            CEOGridView.Refresh();
        }

        private void button6_Click(object sender, EventArgs e) //Cập nhật thông tin người thuê
        {
            string tenNT = textBox_MaHD.Text;
            string diaChi = textBox1.Text;
            string sdt = textBox_MaNha.Text;
            string money = textBox_MaNT.Text;
            string yeuCau = textBox2.Text;

            string query = "EXEC sp_sua_NguoiThue @MaNT=" + Account.username + ",@TenNT=" + tenNT + ",@DiaChi=" + diaChi + ",@SDT=" + sdt + ",@TieuChi=" + money + ",@LoaiNhaYeuCau=" + yeuCau; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(Account.connectString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                connection.Close();
            }

            Close();
        }

        private void button3_Click(object sender, EventArgs e) //Cập nhật thông tin người thuê fix
        {
            string tenNT = textBox_MaHD.Text;
            string diaChi = textBox1.Text;
            string sdt = textBox_MaNha.Text;
            string money = textBox_MaNT.Text;
            string yeuCau = textBox2.Text;

            string query = "EXEC sp_NT_Update @MaNT=" + Account.username + ",@TenNT=" + tenNT + ",@DiaChi=" + diaChi + ",@SDT=" + sdt + ",@TieuChi=" + money + ",@LoaiNhaYeuCau=" + yeuCau; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(Account.connectString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                connection.Close();
            }

            Close();
        }

    }
}
