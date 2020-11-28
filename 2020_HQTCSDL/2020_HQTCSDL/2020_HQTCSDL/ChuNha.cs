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
    public partial class ChuNha : Form
    {
        public ChuNha()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void O_NhaMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMenuItem.Enabled = true;
            DeleteMenuItem.Enabled = true;
            AddMenuItem.Enabled = true;
            SelectMenuItem.Enabled = true;
        }

        private void O_NguoiThueMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMenuItem.Enabled = false;
            DeleteMenuItem.Enabled = false;
            AddMenuItem.Enabled = false;
            SelectMenuItem.Enabled = true;
        }

        private void O_NhaThueMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMenuItem.Enabled = true;
            DeleteMenuItem.Enabled = true;
            AddMenuItem.Enabled = true;
            SelectMenuItem.Enabled = true;
        }

        private void O_NhaBanMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMenuItem.Enabled = true;
            DeleteMenuItem.Enabled = true;
            AddMenuItem.Enabled = true;
            SelectMenuItem.Enabled = true;
        }

        private void ChuNhaMenuItem_Click(object sender, EventArgs e)
        {
            SelectMenuItem.Enabled = false;
            DeleteMenuItem.Enabled = false;
            AddMenuItem.Enabled = false;
            UpdateMenuItem.Enabled = true;
        }

        private void HopDongMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMenuItem.Enabled = false;
            DeleteMenuItem.Enabled = false;
            AddMenuItem.Enabled = false;
            SelectMenuItem.Enabled = true;
        }

        private void LichSuXemMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMenuItem.Enabled = false;
            DeleteMenuItem.Enabled = false;
            AddMenuItem.Enabled = false;
            SelectMenuItem.Enabled = true;
        }

        private void LoaiNhaMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMenuItem.Enabled = false;
            DeleteMenuItem.Enabled = false;
            AddMenuItem.Enabled = false;
            SelectMenuItem.Enabled = true;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
