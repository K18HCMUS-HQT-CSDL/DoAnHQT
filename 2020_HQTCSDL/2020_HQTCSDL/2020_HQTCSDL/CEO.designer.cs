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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_hsLuong = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textbox_role = new System.Windows.Forms.TextBox();
            this.tempDataSet = new _2020_HQTCSDL.tempDataSet();
            this.chiNhanhBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chiNhanhTableAdapter = new _2020_HQTCSDL.tempDataSetTableAdapters.ChiNhanhTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.CEOGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiNhanhBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CEOGridView
            // 
            this.CEOGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CEOGridView.Location = new System.Drawing.Point(298, 12);
            this.CEOGridView.Name = "CEOGridView";
            this.CEOGridView.RowHeadersWidth = 62;
            this.CEOGridView.RowTemplate.Height = 28;
            this.CEOGridView.Size = new System.Drawing.Size(695, 426);
            this.CEOGridView.TabIndex = 0;
            // 
            // capnhatLuong_button
            // 
            this.capnhatLuong_button.Location = new System.Drawing.Point(34, 197);
            this.capnhatLuong_button.Name = "capnhatLuong_button";
            this.capnhatLuong_button.Size = new System.Drawing.Size(230, 38);
            this.capnhatLuong_button.TabIndex = 1;
            this.capnhatLuong_button.Text = "Cập nhật ";
            this.capnhatLuong_button.UseVisualStyleBackColor = true;
            this.capnhatLuong_button.Click += new System.EventHandler(this.capnhatLuong_button_Click);
            // 
            // box_ChiNhanh
            // 
            this.box_ChiNhanh.DataSource = this.chiNhanhBindingSource;
            this.box_ChiNhanh.DisplayMember = "MaCN";
            this.box_ChiNhanh.FormattingEnabled = true;
            this.box_ChiNhanh.Location = new System.Drawing.Point(143, 112);
            this.box_ChiNhanh.Name = "box_ChiNhanh";
            this.box_ChiNhanh.Size = new System.Drawing.Size(121, 28);
            this.box_ChiNhanh.TabIndex = 2;
            this.box_ChiNhanh.ValueMember = "MaCN";
            this.box_ChiNhanh.SelectedIndexChanged += new System.EventHandler(this.box_ChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Chi Nhánh";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hệ số lương";
            // 
            // textBox_hsLuong
            // 
            this.textBox_hsLuong.Location = new System.Drawing.Point(143, 153);
            this.textBox_hsLuong.Name = "textBox_hsLuong";
            this.textBox_hsLuong.Size = new System.Drawing.Size(121, 26);
            this.textBox_hsLuong.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(34, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 38);
            this.button2.TabIndex = 6;
            this.button2.Text = "Thống kê Nhân viên";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonThongkeNV_Click);
            // 
            // textbox_role
            // 
            this.textbox_role.Location = new System.Drawing.Point(34, 12);
            this.textbox_role.Name = "textbox_role";
            this.textbox_role.Size = new System.Drawing.Size(100, 26);
            this.textbox_role.TabIndex = 7;
            // 
            // tempDataSet
            // 
            this.tempDataSet.DataSetName = "tempDataSet";
            this.tempDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chiNhanhBindingSource
            // 
            this.chiNhanhBindingSource.DataMember = "ChiNhanh";
            this.chiNhanhBindingSource.DataSource = this.tempDataSet;
            // 
            // chiNhanhTableAdapter
            // 
            this.chiNhanhTableAdapter.ClearBeforeFill = true;
            // 
            // CEO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 450);
            this.Controls.Add(this.textbox_role);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_hsLuong);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box_ChiNhanh);
            this.Controls.Add(this.capnhatLuong_button);
            this.Controls.Add(this.CEOGridView);
            this.Name = "CEO";
            this.Text = "CEO";
            this.Load += new System.EventHandler(this.CEO_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CEOGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tempDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chiNhanhBindingSource)).EndInit();
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
    }
}