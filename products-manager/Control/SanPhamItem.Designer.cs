namespace products_manager.Control
{
    partial class SanPhamItem
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
            hinhAnh = new PictureBox();
            lbTenSanPham = new Label();
            lbSoLuong = new Label();
            lbGia = new Label();
            btnMua = new Button();
            ((System.ComponentModel.ISupportInitialize)hinhAnh).BeginInit();
            SuspendLayout();
            // 
            // hinhAnh
            // 
            hinhAnh.Image = Properties.Resources.laptop;
            hinhAnh.Location = new Point(43, 13);
            hinhAnh.Name = "hinhAnh";
            hinhAnh.Size = new Size(64, 64);
            hinhAnh.TabIndex = 0;
            hinhAnh.TabStop = false;
            // 
            // lbTenSanPham
            // 
            lbTenSanPham.AutoSize = true;
            lbTenSanPham.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTenSanPham.Location = new Point(22, 80);
            lbTenSanPham.Name = "lbTenSanPham";
            lbTenSanPham.Size = new Size(64, 15);
            lbTenSanPham.TabIndex = 1;
            lbTenSanPham.Text = "Laptop HP";
            // 
            // lbSoLuong
            // 
            lbSoLuong.AutoSize = true;
            lbSoLuong.Location = new Point(22, 97);
            lbSoLuong.Name = "lbSoLuong";
            lbSoLuong.Size = new Size(72, 15);
            lbSoLuong.TabIndex = 2;
            lbSoLuong.Text = "Số lượng: 20";
            // 
            // lbGia
            // 
            lbGia.AutoSize = true;
            lbGia.Location = new Point(22, 112);
            lbGia.Name = "lbGia";
            lbGia.Size = new Size(88, 15);
            lbGia.TabIndex = 3;
            lbGia.Text = "Giá: 20000000 đ";
            // 
            // btnMua
            // 
            btnMua.BackColor = SystemColors.ActiveCaption;
            btnMua.Location = new Point(38, 139);
            btnMua.Name = "btnMua";
            btnMua.Size = new Size(75, 27);
            btnMua.TabIndex = 4;
            btnMua.Text = "Mua";
            btnMua.UseVisualStyleBackColor = false;
            btnMua.Click += button1_Click;
            // 
            // SanPhamItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(btnMua);
            Controls.Add(lbGia);
            Controls.Add(lbSoLuong);
            Controls.Add(lbTenSanPham);
            Controls.Add(hinhAnh);
            Name = "SanPhamItem";
            Size = new Size(150, 182);
            Load += SanPhamItem_Load;
            ((System.ComponentModel.ISupportInitialize)hinhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox hinhAnh;
        private Label lbTenSanPham;
        private Label lbSoLuong;
        private Label lbGia;
        private Button btnMua;
    }
}
