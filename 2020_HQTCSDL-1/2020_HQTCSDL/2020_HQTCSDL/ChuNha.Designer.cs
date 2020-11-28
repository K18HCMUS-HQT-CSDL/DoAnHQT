
namespace _2020_HQTCSDL
{
    public partial class ChuNha
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.O_NhaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.O_NhaThueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.O_NhaBanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.O_NguoiThueMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.O_ChuNhaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.O_HopDongMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.O_LichSuXemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.O_LoaiNhaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbl_Resulr = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(790, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenu,
            this.SaveMenuItem,
            this.CloseMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 32);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openMenu
            // 
            this.openMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.O_NhaMenuItem,
            this.O_NhaThueMenuItem,
            this.O_NhaBanMenuItem,
            this.O_NguoiThueMenuItem,
            this.O_ChuNhaMenuItem,
            this.O_HopDongMenuItem,
            this.O_LichSuXemMenuItem,
            this.O_LoaiNhaMenuItem});
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(155, 34);
            this.openMenu.Text = "open";
            // 
            // O_NhaMenuItem
            // 
            this.O_NhaMenuItem.Name = "O_NhaMenuItem";
            this.O_NhaMenuItem.Size = new System.Drawing.Size(201, 34);
            this.O_NhaMenuItem.Text = "Nha";
            this.O_NhaMenuItem.Click += new System.EventHandler(this.O_NhaMenuItem_Click);
            // 
            // O_NhaThueMenuItem
            // 
            this.O_NhaThueMenuItem.Name = "O_NhaThueMenuItem";
            this.O_NhaThueMenuItem.Size = new System.Drawing.Size(201, 34);
            this.O_NhaThueMenuItem.Text = "NhaThue";
            this.O_NhaThueMenuItem.Click += new System.EventHandler(this.O_NhaThueMenuItem_Click);
            // 
            // O_NhaBanMenuItem
            // 
            this.O_NhaBanMenuItem.Name = "O_NhaBanMenuItem";
            this.O_NhaBanMenuItem.Size = new System.Drawing.Size(201, 34);
            this.O_NhaBanMenuItem.Text = "NhaBan";
            this.O_NhaBanMenuItem.Click += new System.EventHandler(this.O_NhaBanMenuItem_Click);
            // 
            // O_NguoiThueMenuItem
            // 
            this.O_NguoiThueMenuItem.Name = "O_NguoiThueMenuItem";
            this.O_NguoiThueMenuItem.Size = new System.Drawing.Size(201, 34);
            this.O_NguoiThueMenuItem.Text = "NguoiThue";
            this.O_NguoiThueMenuItem.Click += new System.EventHandler(this.O_NguoiThueMenuItem_Click);
            // 
            // O_ChuNhaMenuItem
            // 
            this.O_ChuNhaMenuItem.Name = "O_ChuNhaMenuItem";
            this.O_ChuNhaMenuItem.Size = new System.Drawing.Size(201, 34);
            this.O_ChuNhaMenuItem.Text = "ChuNha";
            this.O_ChuNhaMenuItem.Click += new System.EventHandler(this.ChuNhaMenuItem_Click);
            // 
            // O_HopDongMenuItem
            // 
            this.O_HopDongMenuItem.Name = "O_HopDongMenuItem";
            this.O_HopDongMenuItem.Size = new System.Drawing.Size(201, 34);
            this.O_HopDongMenuItem.Text = "HopDong";
            this.O_HopDongMenuItem.Click += new System.EventHandler(this.HopDongMenuItem_Click);
            // 
            // O_LichSuXemMenuItem
            // 
            this.O_LichSuXemMenuItem.Name = "O_LichSuXemMenuItem";
            this.O_LichSuXemMenuItem.Size = new System.Drawing.Size(201, 34);
            this.O_LichSuXemMenuItem.Text = "LichSuXem";
            this.O_LichSuXemMenuItem.Click += new System.EventHandler(this.LichSuXemMenuItem_Click);
            // 
            // O_LoaiNhaMenuItem
            // 
            this.O_LoaiNhaMenuItem.Name = "O_LoaiNhaMenuItem";
            this.O_LoaiNhaMenuItem.Size = new System.Drawing.Size(201, 34);
            this.O_LoaiNhaMenuItem.Text = "LoaiNha";
            this.O_LoaiNhaMenuItem.Click += new System.EventHandler(this.LoaiNhaMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(155, 34);
            this.SaveMenuItem.Text = "save";
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.Size = new System.Drawing.Size(155, 34);
            this.CloseMenuItem.Text = "close";
            this.CloseMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteMenuItem,
            this.UpdateMenuItem,
            this.AddMenuItem,
            this.SelectMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(58, 32);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size(172, 34);
            this.DeleteMenuItem.Text = "Delete";
            // 
            // UpdateMenuItem
            // 
            this.UpdateMenuItem.Name = "UpdateMenuItem";
            this.UpdateMenuItem.Size = new System.Drawing.Size(172, 34);
            this.UpdateMenuItem.Text = "Update";
            // 
            // AddMenuItem
            // 
            this.AddMenuItem.Name = "AddMenuItem";
            this.AddMenuItem.Size = new System.Drawing.Size(172, 34);
            this.AddMenuItem.Text = "Insert";
            // 
            // SelectMenuItem
            // 
            this.SelectMenuItem.Name = "SelectMenuItem";
            this.SelectMenuItem.Size = new System.Drawing.Size(172, 34);
            this.SelectMenuItem.Text = "Select";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(69, 32);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(65, 32);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // lbl_Resulr
            // 
            this.lbl_Resulr.BackColor = System.Drawing.Color.White;
            this.lbl_Resulr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_Resulr.Location = new System.Drawing.Point(12, 45);
            this.lbl_Resulr.Name = "lbl_Resulr";
            this.lbl_Resulr.Size = new System.Drawing.Size(700, 40);
            this.lbl_Resulr.TabIndex = 58;
            this.lbl_Resulr.Text = "Result: ";
            this.lbl_Resulr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChuNha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 467);
            this.Controls.Add(this.lbl_Resulr);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChuNha";
            this.Text = "ChuNha";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem O_NhaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem O_NhaThueMenuItem;
        private System.Windows.Forms.ToolStripMenuItem O_NhaBanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem O_NguoiThueMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CloseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectMenuItem;
        private System.Windows.Forms.ToolStripMenuItem O_ChuNhaMenuItem;
        private System.Windows.Forms.ToolStripMenuItem O_HopDongMenuItem;
        private System.Windows.Forms.ToolStripMenuItem O_LichSuXemMenuItem;
        private System.Windows.Forms.ToolStripMenuItem O_LoaiNhaMenuItem;
        private System.Windows.Forms.Label lbl_Resulr;
    }
}

