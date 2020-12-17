namespace _2020_HQTCSDL
{
    partial class NhanVienQuanLy
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
            this.textbox_role = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_hsLuong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.box_ChiNhanh = new System.Windows.Forms.ComboBox();
            this.capnhatLuong_button = new System.Windows.Forms.Button();
            this.CEOGridView = new System.Windows.Forms.DataGridView();
            this.textBox_CN = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CEOGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textbox_role
            // 
            this.textbox_role.Location = new System.Drawing.Point(144, 12);
            this.textbox_role.Name = "textbox_role";
            this.textbox_role.Size = new System.Drawing.Size(100, 26);
            this.textbox_role.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 38);
            this.button2.TabIndex = 14;
            this.button2.Text = "Thống kê Nhân viên";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox_hsLuong
            // 
            this.textBox_hsLuong.Location = new System.Drawing.Point(123, 184);
            this.textBox_hsLuong.Name = "textBox_hsLuong";
            this.textBox_hsLuong.Size = new System.Drawing.Size(121, 26);
            this.textBox_hsLuong.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hệ số lương";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Chi Nhánh";
            // 
            // box_ChiNhanh
            // 
            this.box_ChiNhanh.DisplayMember = "MaCN";
            this.box_ChiNhanh.FormattingEnabled = true;
            this.box_ChiNhanh.Location = new System.Drawing.Point(123, 143);
            this.box_ChiNhanh.Name = "box_ChiNhanh";
            this.box_ChiNhanh.Size = new System.Drawing.Size(121, 28);
            this.box_ChiNhanh.TabIndex = 10;
            this.box_ChiNhanh.ValueMember = "MaCN";
            // 
            // capnhatLuong_button
            // 
            this.capnhatLuong_button.Location = new System.Drawing.Point(14, 228);
            this.capnhatLuong_button.Name = "capnhatLuong_button";
            this.capnhatLuong_button.Size = new System.Drawing.Size(230, 38);
            this.capnhatLuong_button.TabIndex = 9;
            this.capnhatLuong_button.Text = "Cập nhật ";
            this.capnhatLuong_button.UseVisualStyleBackColor = true;
            // 
            // CEOGridView
            // 
            this.CEOGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CEOGridView.Location = new System.Drawing.Point(278, 12);
            this.CEOGridView.Name = "CEOGridView";
            this.CEOGridView.RowHeadersWidth = 62;
            this.CEOGridView.RowTemplate.Height = 28;
            this.CEOGridView.Size = new System.Drawing.Size(695, 426);
            this.CEOGridView.TabIndex = 8;
            this.CEOGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CEOGridView_CellContentClick);
            // 
            // textBox_CN
            // 
            this.textBox_CN.Location = new System.Drawing.Point(144, 44);
            this.textBox_CN.Name = "textBox_CN";
            this.textBox_CN.Size = new System.Drawing.Size(100, 26);
            this.textBox_CN.TabIndex = 16;
            // 
            // NhanVienQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 450);
            this.Controls.Add(this.textBox_CN);
            this.Controls.Add(this.textbox_role);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_hsLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box_ChiNhanh);
            this.Controls.Add(this.capnhatLuong_button);
            this.Controls.Add(this.CEOGridView);
            this.Name = "NhanVienQuanLy";
            this.Text = "NhanVienQuanLy";
            ((System.ComponentModel.ISupportInitialize)(this.CEOGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_role;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_hsLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox box_ChiNhanh;
        private System.Windows.Forms.Button capnhatLuong_button;
        private System.Windows.Forms.DataGridView CEOGridView;
        private System.Windows.Forms.TextBox textBox_CN;
    }
}