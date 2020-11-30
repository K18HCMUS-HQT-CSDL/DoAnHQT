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
    public partial class CapNhapCN : Form
    {
        private string myvalMaCN;
        public string MyvalMaCN
        {
            get { return myvalMaCN; }
            set { myvalMaCN = value; }
        }
        private string myvalMaNV;
        public string MyvalMaNV
        {
            get { return myvalMaNV; }
            set { myvalMaNV = value; }
        }
        private string myvaltd;
        public string Myvaltd
        {
            get { return myvaltd; }
            set { myvaltd = value; }
        }
        private string myvaltq;
        public string Myvaltq
        {
            get { return myvaltq; }
            set { myvaltq = value; }
        }
        private string myvaltkv;
        public string Myvaltkv
        {
            get { return myvaltkv; }
            set { myvaltkv = value; }
        }
        private string myvalttp;
        public string Myvalttp
        {
            get { return myvalttp; }
            set { myvalttp = value; }
        }
        private string myvalsdt;
        public string Myvalsdt
        {
            get { return myvalsdt; }
            set { myvalsdt = value; }
        }
        private string myvalfax;
        public string Myvalfax
        {
            get { return myvalfax; }
            set { myvalfax = value; }
        }
        public CapNhapCN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyvalMaCN = textBox3.Text;
            MyvalMaNV = textBox1.Text;
            Myvaltd = textBox8.Text;
            Myvaltq = textBox7.Text;
            Myvaltkv = textBox6.Text;
            Myvalttp = textBox5.Text;
            Myvalsdt = textBox4.Text;
            Myvalfax = textBox2.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
