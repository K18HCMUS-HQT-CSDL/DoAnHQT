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
            this.capnhatLuong_button = new System.Windows.Forms.Button();
            this.CEOGridView = new System.Windows.Forms.DataGridView();
            this.textBox_CN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_MaNV = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_hsLuong
            // 
            this.textBox_hsLuong.Location = new System.Drawing.Point(123, 214);
            this.textBox_hsLuong.Name = "textBox_hsLuong";
            this.textBox_hsLuong.Size = new System.Drawing.Size(121, 26);
            this.textBox_hsLuong.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Lương thêm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã Nhân viên";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // capnhatLuong_button
            // 
            this.capnhatLuong_button.Location = new System.Drawing.Point(14, 255);
            this.capnhatLuong_button.Name = "capnhatLuong_button";
            this.capnhatLuong_button.Size = new System.Drawing.Size(230, 38);
            this.capnhatLuong_button.TabIndex = 9;
            this.capnhatLuong_button.Text = "Cập nhật Lương";
            this.capnhatLuong_button.UseVisualStyleBackColor = true;
            this.capnhatLuong_button.Click += new System.EventHandler(this.capnhatLuong_button_Click);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mã đăng nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Mã chi nhánh";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox_MaNV
            // 
            this.textBox_MaNV.Location = new System.Drawing.Point(123, 180);
            this.textBox_MaNV.Name = "textBox_MaNV";
            this.textBox_MaNV.Size = new System.Drawing.Size(121, 26);
            this.textBox_MaNV.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 38);
            this.button1.TabIndex = 20;
            this.button1.Text = "Thống kê Nhân viên_Fix";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(230, 38);
            this.button3.TabIndex = 21;
            this.button3.Text = "Cập nhật Lương_Fix";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // NhanVienQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_MaNV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_CN);
            this.Controls.Add(this.textbox_role);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_hsLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Button capnhatLuong_button;
        private System.Windows.Forms.DataGridView CEOGridView;
        private System.Windows.Forms.TextBox textBox_CN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_MaNV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}