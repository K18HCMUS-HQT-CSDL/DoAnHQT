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

        private void themHD_button_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}