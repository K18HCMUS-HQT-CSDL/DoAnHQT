﻿namespace _2020_HQTCSDL
{
    partial class NhanVien
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
            this.textBox_MaHD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textbox_role = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_MaNha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.themHD_button = new System.Windows.Forms.Button();
            this.CEOGridView = new System.Windows.Forms.DataGridView();
            this.textBox_MaNT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CEOGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_MaHD
            // 
            this.textBox_MaHD.Location = new System.Drawing.Point(125, 98);
            this.textBox_MaHD.Name = "textBox_MaHD";
            this.textBox_MaHD.Size = new System.Drawing.Size(121, 26);
            this.textBox_MaHD.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Mã đăng nhập";
            // 
            // textbox_role
            // 
            this.textbox_role.Location = new System.Drawing.Point(144, 6);
            this.textbox_role.Name = "textbox_role";
            this.textbox_role.Size = new System.Drawing.Size(100, 26);
            this.textbox_role.TabIndex = 25;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 38);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 38);
            this.button2.TabIndex = 24;
            this.button2.Text = "Thống kê Nhà";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_MaNha
            // 
            this.textBox_MaNha.Location = new System.Drawing.Point(125, 132);
            this.textBox_MaNha.Name = "textBox_MaNha";
            this.textBox_MaNha.Size = new System.Drawing.Size(121, 26);
            this.textBox_MaNha.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Mã Nhà";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Mã Hợp đồng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // themHD_button
            // 
            this.themHD_button.Location = new System.Drawing.Point(18, 210);
            this.themHD_button.Name = "themHD_button";
            this.themHD_button.Size = new System.Drawing.Size(230, 38);
            this.themHD_button.TabIndex = 20;
            this.themHD_button.Text = "Thêm Hợp đồng";
            this.themHD_button.UseVisualStyleBackColor = true;
            this.themHD_button.Click += new System.EventHandler(this.themHD_button_Click);
            // 
            // CEOGridView
            // 
            this.CEOGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CEOGridView.Location = new System.Drawing.Point(282, 12);
            this.CEOGridView.Name = "CEOGridView";
            this.CEOGridView.RowHeadersWidth = 62;
            this.CEOGridView.RowTemplate.Height = 28;
            this.CEOGridView.Size = new System.Drawing.Size(695, 426);
            this.CEOGridView.TabIndex = 30;
            // 
            // textBox_MaNT
            // 
            this.textBox_MaNT.Location = new System.Drawing.Point(125, 167);
            this.textBox_MaNT.Name = "textBox_MaNT";
            this.textBox_MaNT.Size = new System.Drawing.Size(121, 26);
            this.textBox_MaNT.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 20);
            this.label4.TabIndex = 31;
            this.label4.Text = "Mã Người thuê";
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 450);
            this.Controls.Add(this.textBox_MaNT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CEOGridView);
            this.Controls.Add(this.textBox_MaHD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_role);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_MaNha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.themHD_button);
            this.Name = "NhanVien";
            this.Text = "NhanVien";
            ((System.ComponentModel.ISupportInitialize)(this.CEOGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_MaHD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textbox_role;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_MaNha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button themHD_button;
        private System.Windows.Forms.DataGridView CEOGridView;
        private System.Windows.Forms.TextBox textBox_MaNT;
        private System.Windows.Forms.Label label4;
    }
}