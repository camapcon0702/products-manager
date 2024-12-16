namespace products_manager
{
    partial class NhaCungCapControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            tbSDT = new TextBox();
            label4 = new Label();
            tbDiaChi = new TextBox();
            tbNhaCungCap = new TextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            dgvNhaCungCap = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(732, 38);
            label1.TabIndex = 1;
            label1.Text = "QUẢN LÝ NHÀ CUNG CẤP";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tbSDT);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbDiaChi);
            groupBox1.Controls.Add(tbNhaCungCap);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(25, 56);
            groupBox1.Margin = new Padding(2, 2, 2, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2, 2, 2, 2);
            groupBox1.Size = new Size(377, 155);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin";
            // 
            // tbSDT
            // 
            tbSDT.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSDT.Location = new Point(147, 114);
            tbSDT.Margin = new Padding(2, 2, 2, 2);
            tbSDT.Name = "tbSDT";
            tbSDT.Size = new Size(202, 29);
            tbSDT.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 116);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(108, 21);
            label4.TabIndex = 4;
            label4.Text = "Số điện thoại";
            // 
            // tbDiaChi
            // 
            tbDiaChi.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbDiaChi.Location = new Point(147, 52);
            tbDiaChi.Margin = new Padding(2, 2, 2, 2);
            tbDiaChi.Multiline = true;
            tbDiaChi.Name = "tbDiaChi";
            tbDiaChi.Size = new Size(202, 57);
            tbDiaChi.TabIndex = 3;
            // 
            // tbNhaCungCap
            // 
            tbNhaCungCap.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNhaCungCap.Location = new Point(147, 22);
            tbNhaCungCap.Margin = new Padding(2, 2, 2, 2);
            tbNhaCungCap.Name = "tbNhaCungCap";
            tbNhaCungCap.Size = new Size(202, 29);
            tbNhaCungCap.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(13, 53);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(65, 21);
            label3.TabIndex = 1;
            label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 23);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(113, 21);
            label2.TabIndex = 0;
            label2.Text = "Nhà cung cấp";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Location = new Point(415, 56);
            groupBox2.Margin = new Padding(2, 2, 2, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(2, 2, 2, 2);
            groupBox2.Size = new Size(302, 155);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chức năng";
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(41, 80);
            btnXoa.Margin = new Padding(2, 2, 2, 2);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(88, 27);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(180, 29);
            btnSua.Margin = new Padding(2, 2, 2, 2);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(88, 27);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(41, 29);
            btnThem.Margin = new Padding(2, 2, 2, 2);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(88, 27);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // dgvNhaCungCap
            // 
            dgvNhaCungCap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvNhaCungCap.Location = new Point(25, 220);
            dgvNhaCungCap.Margin = new Padding(2, 2, 2, 2);
            dgvNhaCungCap.Name = "dgvNhaCungCap";
            dgvNhaCungCap.RowHeadersWidth = 62;
            dgvNhaCungCap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNhaCungCap.Size = new Size(692, 124);
            dgvNhaCungCap.TabIndex = 4;
            dgvNhaCungCap.CellContentClick += dgvNhaCungCap_CellContentClick;
            // 
            // NhaCungCapControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvNhaCungCap);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "NhaCungCapControl";
            Size = new Size(732, 353);
            Load += NhaCungCapControl_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNhaCungCap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox tbDiaChi;
        private TextBox tbNhaCungCap;
        private Label label3;
        private Label label2;
        private TextBox tbSDT;
        private Label label4;
        private GroupBox groupBox2;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private DataGridView dgvNhaCungCap;
    }
}
