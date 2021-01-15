namespace _2020_HQTCSDL
{
    partial class CEO
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
            this.components = new System.ComponentModel.Container();
            this.CEOGridView = new System.Windows.Forms.DataGridView();
            this.capnhatLuong_button = new System.Windows.Forms.Button();
            this.box_ChiNhanh = new System.Windows.Forms.ComboBox();
            this.chiNhanhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tempDataSet = new _2020_HQTCSDL.tempDataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_hsLuong = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textbox_role = new System.Windows.Forms.TextBox();
            this.chiNhanhTableAdapter = new _2020_HQTCSDL.tempDataSetTableAdapters.ChiNhanhTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CEOGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiNhanhBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // CEOGridView
            // 
            this.CEOGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CEOGridView.Location = new System.Drawing.Point(265, 10);
            this.CEOGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CEOGridView.Name = "CEOGridView";
            this.CEOGridView.RowHeadersWidth = 62;
            this.CEOGridView.RowTemplate.Height = 28;
            this.CEOGridView.Size = new System.Drawing.Size(627, 350);
            this.CEOGridView.TabIndex = 0;
            // 
            // capnhatLuong_button
            // 
            this.capnhatLuong_button.Location = new System.Drawing.Point(30, 188);
            this.capnhatLuong_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.capnhatLuong_button.Name = "capnhatLuong_button";
            this.capnhatLuong_button.Size = new System.Drawing.Size(204, 30);
            this.capnhatLuong_button.TabIndex = 1;
            this.capnhatLuong_button.Text = "Cập nhật_Fix ";
            this.capnhatLuong_button.UseVisualStyleBackColor = true;
            this.capnhatLuong_button.Click += new System.EventHandler(this.capnhatLuong_button_Click);
            // 
            // box_ChiNhanh
            // 
            this.box_ChiNhanh.DataSource = this.chiNhanhBindingSource;
            this.box_ChiNhanh.DisplayMember = "MaCN";
            this.box_ChiNhanh.FormattingEnabled = true;
            this.box_ChiNhanh.Location = new System.Drawing.Point(127, 103);
            this.box_ChiNhanh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.box_ChiNhanh.Name = "box_ChiNhanh";
            this.box_ChiNhanh.Size = new System.Drawing.Size(108, 24);
            this.box_ChiNhanh.TabIndex = 2;
            this.box_ChiNhanh.ValueMember = "MaCN";
            this.box_ChiNhanh.SelectedIndexChanged += new System.EventHandler(this.box_ChiNhanh_SelectedIndexChanged);
            // 
            // chiNhanhBindingSource
            // 
            this.chiNhanhBindingSource.DataMember = "ChiNhanh";
            this.chiNhanhBindingSource.DataSource = this.tempDataSet;
            // 
            // tempDataSet
            // 
            this.tempDataSet.DataSetName = "tempDataSet";
            this.tempDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chi Nhánh";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hệ số lương";
            // 
            // textBox_hsLuong
            // 
            this.textBox_hsLuong.Location = new System.Drawing.Point(127, 129);
            this.textBox_hsLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_hsLuong.Name = "textBox_hsLuong";
            this.textBox_hsLuong.Size = new System.Drawing.Size(108, 22);
            this.textBox_hsLuong.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 34);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(204, 30);
            this.button2.TabIndex = 6;
            this.button2.Text = "Thống kê Nhân viên";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonThongkeNV_Click);
            // 
            // textbox_role
            // 
            this.textbox_role.Location = new System.Drawing.Point(146, 10);
            this.textbox_role.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textbox_role.Name = "textbox_role";
            this.textbox_role.Size = new System.Drawing.Size(89, 22);
            this.textbox_role.TabIndex = 7;
            // 
            // chiNhanhTableAdapter
            // 
            this.chiNhanhTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Mã đăng nhập";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 66);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(204, 30);
            this.button1.TabIndex = 9;
            this.button1.Text = "Thống kê Nhân viên_Fix";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(30, 156);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(204, 30);
            this.button3.TabIndex = 10;
            this.button3.Text = "Cập nhật";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(30, 285);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(204, 30);
            this.button4.TabIndex = 16;
            this.button4.Text = "Cập nhật";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(127, 248);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 22);
            this.textBox1.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mã Nhân viên";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Chi Nhánh";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(127, 222);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 24);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.ValueMember = "MaCN";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(31, 319);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(204, 30);
            this.button5.TabIndex = 11;
            this.button5.Text = "Cập nhật_Fix ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // CEO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 360);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textbox_role);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_hsLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box_ChiNhanh);
            this.Controls.Add(this.capnhatLuong_button);
            this.Controls.Add(this.CEOGridView);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CEO";
            this.Text = "CEO";
            this.Load += new System.EventHandler(this.CEO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CEOGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiNhanhBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CEOGridView;
        private System.Windows.Forms.Button capnhatLuong_button;
        private System.Windows.Forms.ComboBox box_ChiNhanh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_hsLuong;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textbox_role;
        private tempDataSet tempDataSet;
        private System.Windows.Forms.BindingSource chiNhanhBindingSource;
        private tempDataSetTableAdapters.ChiNhanhTableAdapter chiNhanhTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button5;
    }
}
