namespace products_manager
{
    partial class FormDangKy
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
            button1 = new Button();
            linkLabel1 = new LinkLabel();
            txtPassword = new TextBox();
            label3 = new Label();
            lb2 = new Label();
            txtEmail = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            txtConfirmPassword = new TextBox();
            label5 = new Label();
            txtHoten = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(464, 466);
            button1.Name = "button1";
            button1.Size = new Size(132, 47);
            button1.TabIndex = 14;
            button1.Text = "Đăng ký";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 14F);
            linkLabel1.Location = new Point(640, 412);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(105, 25);
            linkLabel1.TabIndex = 13;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Đăng nhập";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Segoe UI", 16F);
            txtPassword.Location = new Point(552, 286);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(193, 36);
            txtPassword.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(486, 412);
            label3.Name = "label3";
            label3.Size = new Size(152, 25);
            label3.TabIndex = 10;
            label3.Text = "Đã có tài khoản?";
            // 
            // lb2
            // 
            lb2.AutoSize = true;
            lb2.Font = new Font("Segoe UI", 16F);
            lb2.Location = new Point(338, 289);
            lb2.Name = "lb2";
            lb2.Size = new Size(114, 30);
            lb2.TabIndex = 11;
            lb2.Text = "Mật khẩu: ";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 16F);
            txtEmail.Location = new Point(552, 224);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(193, 36);
            txtEmail.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(338, 227);
            label2.Name = "label2";
            label2.Size = new Size(75, 30);
            label2.TabIndex = 8;
            label2.Text = "Email: ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.ForeColor = Color.Blue;
            label1.Location = new Point(396, 83);
            label1.Name = "label1";
            label1.Size = new Size(281, 37);
            label1.TabIndex = 7;
            label1.Text = "TRANG ĐĂNG NHẬP";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F);
            label4.Location = new Point(338, 352);
            label4.Name = "label4";
            label4.Size = new Size(206, 30);
            label4.TabIndex = 11;
            label4.Text = "Xác nhận mật khẩu: ";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Segoe UI", 16F);
            txtConfirmPassword.Location = new Point(552, 349);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(193, 36);
            txtConfirmPassword.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F);
            label5.Location = new Point(338, 163);
            label5.Name = "label5";
            label5.Size = new Size(84, 30);
            label5.TabIndex = 8;
            label5.Text = "Họ tên:";
            // 
            // txtHoten
            // 
            txtHoten.Font = new Font("Segoe UI", 16F);
            txtHoten.Location = new Point(552, 160);
            txtHoten.Name = "txtHoten";
            txtHoten.Size = new Size(193, 36);
            txtHoten.TabIndex = 9;
            // 
            // FormDangKy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 601);
            Controls.Add(button1);
            Controls.Add(linkLabel1);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lb2);
            Controls.Add(txtHoten);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormDangKy";
            Text = "FormDangKy";
            Load += FormDangKy_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private LinkLabel linkLabel1;
        private TextBox txtPassword;
        private Label label3;
        private Label lb2;
        private TextBox txtEmail;
        private Label label2;
        private Label label1;
        private Label label4;
        private TextBox txtConfirmPassword;
        private Label label5;
        private TextBox txtHoten;
    }
}