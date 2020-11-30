using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2020_HQTCSDL
{
    public partial class Form4 : Form
    {
        private string myvalMaNV;
        public string MyvalMaNV
        {
            get { return myvalMaNV; }
            set { myvalMaNV = value; }
        }
        private string myvalTenNV;
        public string MyvalTenNV
        {
            get { return myvalTenNV; }
            set { myvalTenNV = value; }
        }
        private string myvaldiachi;
        public string Myvaldiachi
        {
            get { return myvaldiachi; }
            set { myvaldiachi = value; }
        }
        private string myvalsdt;
        public string Myvalsdt
        {
            get { return myvalsdt; }
            set { myvalsdt = value; }
        }
        private string myvalgt;
        public string Myvalgt
        {
            get { return myvalgt; }
            set { myvalgt = value; }
        }
        private string myvalns;
        public string Myvalns
        {
            get { return myvalns; }
            set { myvalns = value; }
        }
        private string myvalluong;
        public string Myvalluong
        {
            get { return myvalluong; }
            set { myvalluong = value; }
        }

        private string myvalql;
        public string Myvalql
        {
            get { return myvalql; }
            set { myvalql = value; }
        }
        private string myvalcn;
        public string Myvalcn
        {
            get { return myvalcn; }
            set { myvalcn = value; }
        }
        private string myvalnvql;
        public string Myvalnvql
        {
            get { return myvalnvql; }
            set { myvalnvql = value; }
        }
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyvalMaNV = textBox3.Text;
            MyvalTenNV = textBox1.Text;
            Myvaldiachi = textBox8.Text;
            Myvalsdt = textBox7.Text;
            Myvalgt = textBox6.Text;
            Myvalns =textBox5.Text;
            Myvalluong = textBox4.Text;
            Myvalcn = textBox2.Text;
            Myvalnvql = textBox22.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyvalMaNV = textBox20.Text;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
