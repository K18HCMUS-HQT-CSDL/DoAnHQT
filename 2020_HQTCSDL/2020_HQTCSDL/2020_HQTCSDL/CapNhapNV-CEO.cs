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
    public partial class CapNhapNV : Form
    {
        private string myvalMaNV;
        public string MyvalMaNV
        {
            get { return myvalMaNV; }
            set { myvalMaNV = value; }
        }
        private string myvalluong;
        public string Myvalluong
        {
            get { return myvalluong; }
            set { myvalluong = value; }
        }
        private string myvalcn;
        public string Myvalcn
        {
            get { return myvalcn; }
            set { myvalcn = value; }
        }
        public CapNhapNV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyvalMaNV = textBox1.Text;
            Myvalluong = textBox2.Text;
            Myvalcn = textBox3.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
