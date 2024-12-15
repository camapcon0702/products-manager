namespace products_manager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            lb2 = new Label();
            label3 = new Label();
            linkLabel1 = new LinkLabel();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(386, 91);
            label1.Name = "label1";
            label1.Size = new Size(281, 37);
            label1.TabIndex = 0;
            label1.Text = "TRANG ĐĂNG NHẬP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(360, 185);
            label2.Name = "label2";
            label2.Size = new Size(75, 30);
            label2.TabIndex = 1;
            label2.Text = "Email: ";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 16F);
            txtEmail.Location = new Point(492, 182);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(193, 36);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 16F);
            txtPassword.Location = new Point(492, 244);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(193, 36);
            txtPassword.TabIndex = 4;
            txtPassword.TextChanged += textBox2_TextChanged;
            // 
            // lb2
            // 
            lb2.AutoSize = true;
            lb2.Font = new Font("Segoe UI", 16F);
            lb2.Location = new Point(360, 247);
            lb2.Name = "lb2";
            lb2.Size = new Size(114, 30);
            lb2.TabIndex = 3;
            lb2.Text = "Mật khẩu: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(426, 309);
            label3.Name = "label3";
            label3.Size = new Size(173, 25);
            label3.TabIndex = 3;
            label3.Text = "Chưa có tài khoản?";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 14F);
            linkLabel1.Location = new Point(605, 309);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(80, 25);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Đăng ký";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(454, 378);
            button1.Name = "button1";
            button1.Size = new Size(132, 47);
            button1.TabIndex = 6;
            button1.Text = "Đăng nhập";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 601);
            Controls.Add(button1);
            Controls.Add(linkLabel1);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(lb2);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Đăng nhập";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Label lb2;
        private Label label3;
        private LinkLabel linkLabel1;
        private Button button1;
    }
}
