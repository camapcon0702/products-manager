namespace products_manager
{
    partial class SanPhamControl
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
            dgvSanPham = new DataGridView();
            label1 = new Label();
            groupBox1 = new GroupBox();
            cbHinhAnh = new ComboBox();
            cbNhaCungCap = new ComboBox();
            cbDanhMuc = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            tbSLC = new TextBox();
            label4 = new Label();
            tbDonGia = new TextBox();
            tbSanPham = new TextBox();
            label3 = new Label();
            label2 = new Label();
            groupBox2 = new GroupBox();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvSanPham
            // 
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Location = new Point(80, 456);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 62;
            dgvSanPham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSanPham.Size = new Size(1107, 214);
            dgvSanPham.TabIndex = 0;
            dgvSanPham.CellContentClick += dgvSanPham_CellContentClick;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Times New Roman", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1242, 63);
            label1.TabIndex = 1;
            label1.Text = "QUẢN LÝ SẢN PHẨM";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbHinhAnh);
            groupBox1.Controls.Add(cbNhaCungCap);
            groupBox1.Controls.Add(cbDanhMuc);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbSLC);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbDonGia);
            groupBox1.Controls.Add(tbSanPham);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(80, 66);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1097, 260);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin";
            // 
            // cbHinhAnh
            // 
            cbHinhAnh.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbHinhAnh.FormattingEnabled = true;
            cbHinhAnh.Location = new Point(195, 201);
            cbHinhAnh.Name = "cbHinhAnh";
            cbHinhAnh.Size = new Size(287, 41);
            cbHinhAnh.TabIndex = 12;
            // 
            // cbNhaCungCap
            // 
            cbNhaCungCap.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbNhaCungCap.FormattingEnabled = true;
            cbNhaCungCap.Location = new Point(743, 93);
            cbNhaCungCap.Name = "cbNhaCungCap";
            cbNhaCungCap.Size = new Size(211, 41);
            cbNhaCungCap.TabIndex = 11;
            // 
            // cbDanhMuc
            // 
            cbDanhMuc.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbDanhMuc.FormattingEnabled = true;
            cbDanhMuc.Location = new Point(743, 36);
            cbDanhMuc.Name = "cbDanhMuc";
            cbDanhMuc.Size = new Size(211, 41);
            cbDanhMuc.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(565, 96);
            label7.Name = "label7";
            label7.Size = new Size(166, 33);
            label7.TabIndex = 9;
            label7.Text = "Nhà cung cấp";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(565, 35);
            label6.Name = "label6";
            label6.Size = new Size(128, 33);
            label6.TabIndex = 8;
            label6.Text = "Danh mục";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 204);
            label5.Name = "label5";
            label5.Size = new Size(117, 33);
            label5.TabIndex = 6;
            label5.Text = "Hình ảnh";
            // 
            // tbSLC
            // 
            tbSLC.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSLC.Location = new Point(195, 140);
            tbSLC.Name = "tbSLC";
            tbSLC.Size = new Size(287, 40);
            tbSLC.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(18, 147);
            label4.Name = "label4";
            label4.Size = new Size(164, 33);
            label4.TabIndex = 4;
            label4.Text = "Số lượng còn";
            // 
            // tbDonGia
            // 
            tbDonGia.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbDonGia.Location = new Point(195, 86);
            tbDonGia.Name = "tbDonGia";
            tbDonGia.Size = new Size(287, 40);
            tbDonGia.TabIndex = 3;
            // 
            // tbSanPham
            // 
            tbSanPham.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSanPham.Location = new Point(195, 32);
            tbSanPham.Name = "tbSanPham";
            tbSanPham.Size = new Size(287, 40);
            tbSanPham.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 93);
            label3.Name = "label3";
            label3.Size = new Size(104, 33);
            label3.TabIndex = 1;
            label3.Text = "Đơn giá";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 39);
            label2.Name = "label2";
            label2.Size = new Size(124, 33);
            label2.TabIndex = 0;
            label2.Text = "Sản phẩm";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnXoa);
            groupBox2.Controls.Add(btnSua);
            groupBox2.Controls.Add(btnThem);
            groupBox2.Location = new Point(80, 345);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(795, 95);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chức năng";
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(478, 30);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(125, 45);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSua.Location = new Point(292, 30);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(125, 45);
            btnSua.TabIndex = 1;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnThem.Location = new Point(93, 30);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(125, 45);
            btnThem.TabIndex = 0;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // SanPhamControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(dgvSanPham);
            Name = "SanPhamControl";
            Size = new Size(1242, 688);
            Load += SanPhamControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvSanPham;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox tbMoTa;
        private TextBox tbSanPham;
        private Label label3;
        private Label label2;
        private ComboBox cbNhaCungCap;
        private ComboBox cbDanhMuc;
        private Label label7;
        private Label label6;
        private Label label5;
        private TextBox tbSLC;
        private Label label4;
        private TextBox tbDonGia;
        private GroupBox groupBox2;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private ComboBox cbHinhAnh;
    }
}
