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
using System.Runtime.CompilerServices;

namespace _2020_HQTCSDL
{
    public partial class SuaTTNT_popup : Form
    {
        private string username;
        public SuaTTNT_popup(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void SuaTTNT_Load(object sender, EventArgs e)
        {
            NguoiThue temp = new NguoiThue(username);
            DataSet tempData = temp.GetTTNguoiThue();
            textBox1.Text = tempData.Tables[0].Rows[0]["TenNT"].ToString(); //Hiện tên người thuê
            textBox2.Text = tempData.Tables[0].Rows[0]["DiaChi"].ToString(); //Hiện địa chỉ
            textBox3.Text = tempData.Tables[0].Rows[0]["SDT"].ToString(); //Hiện số điện thoại
            textBox4.Text = tempData.Tables[0].Rows[0]["TieuChi"].ToString(); //Hiện tiêu chí

            string yeuCau = tempData.Tables[0].Rows[0]["YeuCau"].ToString();
            //comboBox1.Items[0].ToString;
            if (yeuCau == "LOAI01  ") //Do trong database lỡ set MaLoai của bảng LoaiNha là 8 kí tự nên lúc lấy về nó tự thêm khoảng trắng cho đủ 8
            {
                comboBox1.SelectedItem = "Loại 01";
            }
            else if (yeuCau == "LOAI02  ")
            {
                comboBox1.SelectedItem = "Loại 02";
            }
            else if (yeuCau == "LOAI03  ")
            {
                comboBox1.SelectedItem = "Loại 03";
            }
            else if (yeuCau == "LOAI04  ")
            {
                comboBox1.SelectedItem = "Loại 04";
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string tenNT = textBox1.Text;
            string diaChi = textBox2.Text;
            string sdt = textBox3.Text;
            string money = textBox4.Text;
            string yeuCau = comboBox1.SelectedItem.ToString();
            if (yeuCau == "Loại 01") //Do trong database lỡ set MaLoai của bảng LoaiNha là 8 kí tự nên lúc lấy về nó tự thêm khoảng trắng cho đủ 8
            {
                yeuCau = "LOAI01  ";
            }
            else if (yeuCau == "Loại 02")
            {
                yeuCau = "LOAI02  ";
            }
            else if (yeuCau == "Loại 03")
            {
                yeuCau = "LOAI03  ";
            }
            else if (yeuCau == "Loại 04")
            {
                yeuCau = "LOAI04  ";
            }

            //SQL Connection
            //Nên có 1 class lưu connection string chuẩn của nhóm khi merge code
            string connectionString = @"Data Source=DESKTOP-R4GG4RM;Initial Catalog=HQT_CSDL;Integrated Security=True";
            string query = "EXEC sp_NT_Update @MaNT=" + username + ",@TenNT=" + tenNT + ",@DiaChi=" + diaChi + ",@SDT=" + sdt + ",@TieuChi=" + money + ",@LoaiNhaYeuCau=" + yeuCau; //Câu lệnh truy vấn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                //SqlDataAdapter
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                connection.Close();
            }

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
