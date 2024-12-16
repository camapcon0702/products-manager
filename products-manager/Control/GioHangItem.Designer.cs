namespace products_manager.Control
{
    partial class GioHangItem
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
            checkBox = new CheckBox();
            hinhAnh = new PictureBox();
            lbTenSanPham = new Label();
            lbGia = new Label();
            lbSoLuong = new Label();
            ((System.ComponentModel.ISupportInitialize)hinhAnh).BeginInit();
            SuspendLayout();
            // 
            // checkBox
            // 
            checkBox.AutoSize = true;
            checkBox.Font = new Font("Segoe UI", 16F);
            checkBox.Location = new Point(28, 29);
            checkBox.Name = "checkBox";
            checkBox.Size = new Size(15, 14);
            checkBox.TabIndex = 0;
            checkBox.UseVisualStyleBackColor = true;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
            // 
            // hinhAnh
            // 
            hinhAnh.Location = new Point(58, 7);
            hinhAnh.Name = "hinhAnh";
            hinhAnh.Size = new Size(64, 64);
            hinhAnh.TabIndex = 1;
            hinhAnh.TabStop = false;
            // 
            // lbTenSanPham
            // 
            lbTenSanPham.AutoSize = true;
            lbTenSanPham.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbTenSanPham.Location = new Point(142, 24);
            lbTenSanPham.Name = "lbTenSanPham";
            lbTenSanPham.Size = new Size(75, 25);
            lbTenSanPham.TabIndex = 2;
            lbTenSanPham.Text = "Laptop";
            // 
            // lbGia
            // 
            lbGia.AutoSize = true;
            lbGia.Font = new Font("Segoe UI", 12F);
            lbGia.Location = new Point(325, 27);
            lbGia.Name = "lbGia";
            lbGia.Size = new Size(85, 21);
            lbGia.TabIndex = 3;
            lbGia.Text = "Giá: 1000$";
            // 
            // lbSoLuong
            // 
            lbSoLuong.AutoSize = true;
            lbSoLuong.Font = new Font("Segoe UI", 12F);
            lbSoLuong.Location = new Point(446, 27);
            lbSoLuong.Name = "lbSoLuong";
            lbSoLuong.Size = new Size(89, 21);
            lbSoLuong.TabIndex = 4;
            lbSoLuong.Text = "Số lượng: 2";
            // 
            // GioHangItem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(lbSoLuong);
            Controls.Add(lbGia);
            Controls.Add(lbTenSanPham);
            Controls.Add(hinhAnh);
            Controls.Add(checkBox);
            Name = "GioHangItem";
            Size = new Size(594, 83);
            Load += GioHangItem_Load;
            ((System.ComponentModel.ISupportInitialize)hinhAnh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox;
        private PictureBox hinhAnh;
        private Label lbTenSanPham;
        private Label lbGia;
        private Label lbSoLuong;
    }
}
