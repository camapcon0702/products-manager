namespace products_manager.Control
{
    partial class DonHangControl
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
            dgvDonHang = new DataGridView();
            label1 = new Label();
            dgvChiTietDonHang = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietDonHang).BeginInit();
            SuspendLayout();
            // 
            // dgvDonHang
            // 
            dgvDonHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDonHang.Location = new Point(247, 78);
            dgvDonHang.Name = "dgvDonHang";
            dgvDonHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonHang.Size = new Size(613, 118);
            dgvDonHang.TabIndex = 0;
            dgvDonHang.CellClick += dgvDonHang_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F);
            label1.Location = new Point(247, 32);
            label1.Name = "label1";
            label1.Size = new Size(224, 30);
            label1.TabIndex = 1;
            label1.Text = "Các đơn hàng đã mua";
            // 
            // dgvChiTietDonHang
            // 
            dgvChiTietDonHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietDonHang.Location = new Point(247, 276);
            dgvChiTietDonHang.Name = "dgvChiTietDonHang";
            dgvChiTietDonHang.Size = new Size(613, 250);
            dgvChiTietDonHang.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F);
            label2.Location = new Point(247, 230);
            label2.Name = "label2";
            label2.Size = new Size(179, 30);
            label2.TabIndex = 1;
            label2.Text = "Chi tiết đơn hàng";
            // 
            // DonHangControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvChiTietDonHang);
            Controls.Add(dgvDonHang);
            Name = "DonHangControl";
            Size = new Size(1080, 640);
            Load += DonHangControl_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDonHang).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietDonHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDonHang;
        private Label label1;
        private DataGridView dgvChiTietDonHang;
        private Label label2;
    }
}
