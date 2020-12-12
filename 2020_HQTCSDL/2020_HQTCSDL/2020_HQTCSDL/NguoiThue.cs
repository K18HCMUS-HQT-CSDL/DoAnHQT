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
        private string username;
        public NguoiThue(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void NguoiThue_Load(object sender, EventArgs e)
        {
            dataGridView3.DataSource = GetTTNguoiThue().Tables[0];
            dataGridView3.Columns["MaNT"].DisplayIndex = 0;
            button1_Click(sender, e);
            button2_Click(sender, e);
            button4_Click(sender, e);
            button5_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e) //Xem Nhà Bán button
        {
            dataGridView1.DataSource = GetNhaBan().Tables[0];
            dataGridView1.Columns["MaNha"].DisplayIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e) //Xem Hợp Đồng Đã Ký button
        {
            dataGridView2.DataSource = GetHopDong().Tables[0];
            dataGridView2.Columns["MaHD"].DisplayIndex = 0;
            dataGridView2.Columns["MaNT"].DisplayIndex = 1;
            dataGridView2.Columns["MaNha"].DisplayIndex = 2;
        }

        private void DataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "LoaiHD")
            {
                switch ((int)dataGridView2["LoaiHD", e.RowIndex].Value)
                {
                    case 0:
                        e.Value = "Mua nhà";
                        e.FormattingApplied = true;
                        break;
                    case 1:
                        e.Value = "Thuê nhà";
                        e.FormattingApplied = true;
                        break;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e) //Xem Nhà Thuê button
        {
            dataGridView4.DataSource = GetNhaThue().Tables[0];
            dataGridView4.Columns["MaNha"].DisplayIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView5.DataSource = GetLSXN().Tables[0];
            dataGridView5.Columns["MaNha"].DisplayIndex = 0;
        }
        public DataSet GetNhaBan()
        {
            DataSet dataNhaBan = new DataSet();
            //SQL Connection
            //Nên có 1 class lưu connection string chuẩn của nhóm khi merge code
            string connectionString = @"Data Source=DESKTOP-R4GG4RM;Initial Catalog=HQT_CSDL;Integrated Security=True";
            string query = "EXEC sp_NT_XemNhaBan"; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(connectionString))
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
            string connectionString = @"Data Source=DESKTOP-R4GG4RM;Initial Catalog=HQT_CSDL;Integrated Security=True";
            string query = "EXEC sp_NT_XemNhaThue"; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataNhaThue);

                connection.Close();
            }

            return dataNhaThue;
        }

        public DataSet GetHopDong()
        {
            DataSet dataHopDong = new DataSet();
            //SQL Connection
            //Nên có 1 class lưu connection string chuẩn của nhóm khi merge code
            string connectionString = @"Data Source=DESKTOP-R4GG4RM;Initial Catalog=HQT_CSDL;Integrated Security=True";
            string query = "EXEC sp_NT_XemHopDongDaKy @MaNT=" + username; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataHopDong);

                connection.Close();
            }

            return dataHopDong;
        }

        public DataSet GetTTNguoiThue()
        {
            DataSet dataTTNguoiThue = new DataSet();
            //SQL Connection
            //Nên có 1 class lưu connection string chuẩn của nhóm khi merge code
            string connectionString = @"Data Source=DESKTOP-R4GG4RM;Initial Catalog=HQT_CSDL;Integrated Security=True";
            string query = "EXEC sp_NT_XemTTNguoiThue @MaNT=" + username; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataTTNguoiThue);

                connection.Close();
            }

            return dataTTNguoiThue;
        }
        public DataSet GetLSXN()
        {
            DataSet dataLSXN = new DataSet();
            //SQL Connection
            //Nên có 1 class lưu connection string chuẩn của nhóm khi merge code
            string connectionString = @"Data Source=DESKTOP-R4GG4RM;Initial Catalog=HQT_CSDL;Integrated Security=True";
            string query = "EXEC sp_NT_XemLSXN @MaNT=" + username; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataLSXN);

                connection.Close();
            }

            return dataLSXN;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SuaTTNT_popup suaTTNT = new SuaTTNT_popup(username);
            DialogResult dialogresult = suaTTNT.ShowDialog();
            suaTTNT.Dispose();
            dataGridView3.DataSource = GetTTNguoiThue().Tables[0];
            dataGridView3.Columns["MaNT"].DisplayIndex = 0;
        }
    }
}