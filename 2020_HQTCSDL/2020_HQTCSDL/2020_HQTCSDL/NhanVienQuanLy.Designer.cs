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
            this.textbox_role.Location = new System.Drawing.Point(128, 10);
            this.textbox_role.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_role.Name = "textbox_role";
            this.textbox_role.Size = new System.Drawing.Size(89, 22);
            this.textbox_role.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 66);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 30);
            this.button2.TabIndex = 14;
            this.button2.Text = "Thống kê Nhân viên";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_hsLuong
            // 
            this.textBox_hsLuong.Location = new System.Drawing.Point(109, 171);
            this.textBox_hsLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_hsLuong.Name = "textBox_hsLuong";
            this.textBox_hsLuong.Size = new System.Drawing.Size(108, 22);
            this.textBox_hsLuong.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Lương thêm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mã Nhân viên";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // capnhatLuong_button
            // 
            this.capnhatLuong_button.Location = new System.Drawing.Point(12, 204);
            this.capnhatLuong_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.capnhatLuong_button.Name = "capnhatLuong_button";
            this.capnhatLuong_button.Size = new System.Drawing.Size(204, 30);
            this.capnhatLuong_button.TabIndex = 9;
            this.capnhatLuong_button.Text = "Cập nhật Lương";
            this.capnhatLuong_button.UseVisualStyleBackColor = true;
            this.capnhatLuong_button.Click += new System.EventHandler(this.capnhatLuong_button_Click);
            // 
            // CEOGridView
            // 
            this.CEOGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CEOGridView.Location = new System.Drawing.Point(247, 10);
            this.CEOGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CEOGridView.Name = "CEOGridView";
            this.CEOGridView.RowHeadersWidth = 62;
            this.CEOGridView.RowTemplate.Height = 28;
            this.CEOGridView.Size = new System.Drawing.Size(618, 341);
            this.CEOGridView.TabIndex = 8;
            this.CEOGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CEOGridView_CellContentClick);
            // 
            // textBox_CN
            // 
            this.textBox_CN.Location = new System.Drawing.Point(128, 35);
            this.textBox_CN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_CN.Name = "textBox_CN";
            this.textBox_CN.Size = new System.Drawing.Size(89, 22);
            this.textBox_CN.TabIndex = 16;
            this.textBox_CN.TextChanged += new System.EventHandler(this.textBox_CN_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mã đăng nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Mã chi nhánh";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textBox_MaNV
            // 
            this.textBox_MaNV.Location = new System.Drawing.Point(109, 144);
            this.textBox_MaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_MaNV.Name = "textBox_MaNV";
            this.textBox_MaNV.Size = new System.Drawing.Size(108, 22);
            this.textBox_MaNV.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 102);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 30);
            this.button1.TabIndex = 20;
            this.button1.Text = "Thống kê Nhân viên_Fix";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 239);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(204, 30);
            this.button3.TabIndex = 21;
            this.button3.Text = "Cập nhật Lương_Fix";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // NhanVienQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 360);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
