namespace products_manager.Control
{
    partial class GioHangControl
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
            flowLayoutPanel = new FlowLayoutPanel();
            btnMua = new Button();
            btnXoa = new Button();
            lbThanhTien = new Label();
            SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.Location = new Point(236, 47);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(600, 383);
            flowLayoutPanel.TabIndex = 0;
            // 
            // btnMua
            // 
            btnMua.AutoSize = true;
            btnMua.Font = new Font("Segoe UI", 12F);
            btnMua.Location = new Point(593, 489);
            btnMua.Name = "btnMua";
            btnMua.Size = new Size(75, 31);
            btnMua.TabIndex = 1;
            btnMua.Text = "Mua";
            btnMua.UseVisualStyleBackColor = true;
            btnMua.Click += btnMua_Click;
            // 
            // btnXoa
            // 
            btnXoa.AutoSize = true;
            btnXoa.Font = new Font("Segoe UI", 12F);
            btnXoa.Location = new Point(436, 489);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(75, 31);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // lbThanhTien
            // 
            lbThanhTien.AutoSize = true;
            lbThanhTien.Font = new Font("Segoe UI", 14F);
            lbThanhTien.Location = new Point(748, 449);
            lbThanhTien.Name = "lbThanhTien";
            lbThanhTien.Size = new Size(63, 25);
            lbThanhTien.TabIndex = 2;
            lbThanhTien.Text = "label1";
            lbThanhTien.TextAlign = ContentAlignment.MiddleRight;
            lbThanhTien.Click += lbThanhTien_Click;
            // 
            // GioHangControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbThanhTien);
            Controls.Add(btnXoa);
            Controls.Add(btnMua);
            Controls.Add(flowLayoutPanel);
            Name = "GioHangControl";
            Size = new Size(1080, 640);
            Load += GioHangControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel;
        private Button btnMua;
        private Button btnXoa;
        private Label lbThanhTien;
    }
}
