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
   
    public partial class Login : Form
    {
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account.username = usernameTextBox.Text;
            Account.password = passwordTextBox.Text;
            if (string.IsNullOrWhiteSpace(Account.username) || string.IsNullOrWhiteSpace(Account.password))
            {
                MessageBox.Show("Please provide Username and Password");
                return;
            }
            string DB_Link = @"ICEBEAR-PC\YENNGOCC";
            string DB_Name = "temp";
            Account.connectString = @"Data Source="+DB_Link+";Database="+DB_Name+";Persist Security Info=True;User ID=" + Account.username + ";Password=" + Account.password;
            SqlConnection con = new SqlConnection(Account.connectString);
            
            bool checkLog = true;
            try
            {
                con.Open();
            }
            catch(SqlException)
            {
                checkLog = false;
            }
            if (checkLog)
            {
               
                
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "login_role";
                cmd.CommandType = CommandType.StoredProcedure;             
                
                cmd.Parameters.Add("@username", SqlDbType.Char,20).Value = Account.username;
                
                SqlParameter returnParameter = cmd.Parameters.Add("@role", SqlDbType.VarChar,20);
                returnParameter.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                string result = (string)returnParameter.Value;
                
                MessageBox.Show("Connection Open for " +result +" !");
                switch(result)
                {
                    
                    case "CEO":
                        {
                            CEO fr = new CEO();
                            fr.Show();
                            this.Hide();
                            break;
                        }
                    case "NhanVienQuanLy":
                        {
                            NhanVienQuanLy fr = new NhanVienQuanLy();
                            fr.Show();
                            this.Hide();
                            break;
                        }
                    case "NhanVien":
                        {
                            NhanVien fr = new NhanVien();
                            fr.Show();
                            this.Hide();
                            break;
                        }
                    case "ChuNha":
                        {
                            //ChuNha fr = new ChuNha();
                            //fr.Show();
                            this.Hide();
                            break;
                        }
                    case "NguoiThue":
                        {
                            NguoiThue fr = new NguoiThue();
                            fr.Show();
                            this.Hide();
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Something Wrong!");
                            break;
                        }
                }    

            }
            else MessageBox.Show("Login fail!");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
