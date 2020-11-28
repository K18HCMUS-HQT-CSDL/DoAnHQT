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
    public partial class Form2 : Form
    {
        public string conString = "Data Source=LAPTOP-B644G9B6\\SQLEXPRESS;Initial Catalog=HQT_CSDL;Integrated Security=True";
        private string myval;
        public string Myval
        {
            get { return myval; }
            set { myval = value; }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Myval = textBox1.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
