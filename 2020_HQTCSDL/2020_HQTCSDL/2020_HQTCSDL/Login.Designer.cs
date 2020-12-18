namespace _2020_HQTCSDL	
{	
    partial class Login	
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
            this.usernameTextBox = new System.Windows.Forms.TextBox();	
            this.passwordTextBox = new System.Windows.Forms.TextBox();	
            this.buttonLogIn = new System.Windows.Forms.Button();	
            this.label1 = new System.Windows.Forms.Label();	
            this.label2 = new System.Windows.Forms.Label();	
            this.label3 = new System.Windows.Forms.Label();	
            this.label4 = new System.Windows.Forms.Label();	
            this.SuspendLayout();	
            // 	
            // usernameTextBox	
            // 	
            this.usernameTextBox.AccessibleName = "username";	
            this.usernameTextBox.Font = new System.Drawing.Font("Arial", 10F);	
            this.usernameTextBox.Location = new System.Drawing.Point(38, 182);	
            this.usernameTextBox.Margin = new System.Windows.Forms.Padding(5);	
            this.usernameTextBox.Name = "usernameTextBox";	
            this.usernameTextBox.Size = new System.Drawing.Size(300, 30);	
            this.usernameTextBox.TabIndex = 0;	
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBox_TextChanged);	
            // 	
            // passwordTextBox	
            // 	
            this.passwordTextBox.AccessibleName = "password";	
            this.passwordTextBox.Font = new System.Drawing.Font("Arial", 10F);	
            this.passwordTextBox.Location = new System.Drawing.Point(38, 260);	
            this.passwordTextBox.Margin = new System.Windows.Forms.Padding(5);	
            this.passwordTextBox.Name = "passwordTextBox";	
            this.passwordTextBox.PasswordChar = '*';	
            this.passwordTextBox.Size = new System.Drawing.Size(300, 30);	
            this.passwordTextBox.TabIndex = 1;	
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);	
            // 	
            // buttonLogIn	
            // 	
            this.buttonLogIn.BackColor = System.Drawing.Color.Brown;	
            this.buttonLogIn.FlatAppearance.BorderSize = 0;	
            this.buttonLogIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));	
            this.buttonLogIn.Font = new System.Drawing.Font("Raleway Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));	
            this.buttonLogIn.ForeColor = System.Drawing.Color.AliceBlue;	
            this.buttonLogIn.Location = new System.Drawing.Point(132, 325);	
            this.buttonLogIn.Name = "buttonLogIn";	
            this.buttonLogIn.Size = new System.Drawing.Size(100, 40);	
            this.buttonLogIn.TabIndex = 0;	
            this.buttonLogIn.Text = "LOGIN";	
            this.buttonLogIn.UseVisualStyleBackColor = false;	
            this.buttonLogIn.Click += new System.EventHandler(this.button1_Click);	
            // 	
            // label1	
            // 	
            this.label1.AutoSize = true;	
            this.label1.Font = new System.Drawing.Font("Raleway Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));	
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;	
            this.label1.Location = new System.Drawing.Point(34, 155);	
            this.label1.Name = "label1";	
            this.label1.Size = new System.Drawing.Size(116, 24);	
            this.label1.TabIndex = 3;	
            this.label1.Text = "Username:";	
            this.label1.Click += new System.EventHandler(this.label1_Click);	
            // 	
            // label2	
            // 	
            this.label2.AutoSize = true;	
            this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;	
            this.label2.Font = new System.Drawing.Font("Raleway Black", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));	
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;	
            this.label2.Location = new System.Drawing.Point(34, 233);	
            this.label2.Name = "label2";	
            this.label2.Size = new System.Drawing.Size(110, 24);	
            this.label2.TabIndex = 4;	
            this.label2.Text = "Password:";	
            // 	
            // label3	
            // 	
            this.label3.AutoSize = true;	
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;	
            this.label3.Font = new System.Drawing.Font("Raleway Black", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));	
            this.label3.ForeColor = System.Drawing.Color.Brown;	
            this.label3.Location = new System.Drawing.Point(47, 54);	
            this.label3.Name = "label3";	
            this.label3.Size = new System.Drawing.Size(288, 64);	
            this.label3.TabIndex = 5;	
            this.label3.Text = "2020_N07";	
            this.label3.Click += new System.EventHandler(this.label3_Click);	
            // 	
            // label4	
            // 	
            this.label4.AutoSize = true;	
            this.label4.Font = new System.Drawing.Font("Raleway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));	
            this.label4.ForeColor = System.Drawing.Color.DarkBlue;	
            this.label4.Location = new System.Drawing.Point(53, 396);	
            this.label4.Name = "label4";	
            this.label4.Size = new System.Drawing.Size(272, 29);	
            this.label4.TabIndex = 6;	
            this.label4.Text = "213 - 214 -215 -217 - 227";	
            this.label4.Click += new System.EventHandler(this.label4_Click);	
            // 	
            // Login	
            // 	
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);	
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;	
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;	
            this.ClientSize = new System.Drawing.Size(384, 450);	
            this.Controls.Add(this.label4);	
            this.Controls.Add(this.label3);	
            this.Controls.Add(this.label2);	
            this.Controls.Add(this.label1);	
            this.Controls.Add(this.buttonLogIn);	
            this.Controls.Add(this.passwordTextBox);	
            this.Controls.Add(this.usernameTextBox);	
            this.Name = "Login";	
            this.Text = "Login System";	
            this.ResumeLayout(false);	
            this.PerformLayout();	

        }	

        #endregion	
        private System.Windows.Forms.TextBox passwordTextBox;	
        public System.Windows.Forms.TextBox usernameTextBox;	
        private System.Windows.Forms.Button buttonLogIn;	
        private System.Windows.Forms.Label label1;	
        private System.Windows.Forms.Label label2;	
        private System.Windows.Forms.Label label3;	
        private System.Windows.Forms.Label label4;	
    }	
}	
