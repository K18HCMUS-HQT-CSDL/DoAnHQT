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
            SqlCommand cmd = con.CreateCommand();
            SqlDataReader myreader;
            cmd.CommandText = "select top 1 MaCN from ChiNhanh where MaNV="+Account.username;
            myreader = cmd.ExecuteReader();
            this.textBox_CN.AppendText(myreader[0].ToString());
        }
       

        private void CEOGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
