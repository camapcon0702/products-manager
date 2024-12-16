namespace products_manager
{
    partial class FormKhachHang
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
            menuStrip1 = new MenuStrip();
            xemSảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            giỏHàngToolStripMenuItem = new ToolStripMenuItem();
            đơnĐãMuaToolStripMenuItem = new ToolStripMenuItem();
            pnKhachHang = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { xemSảnPhẩmToolStripMenuItem, giỏHàngToolStripMenuItem, đơnĐãMuaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1064, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // xemSảnPhẩmToolStripMenuItem
            // 
            xemSảnPhẩmToolStripMenuItem.Name = "xemSảnPhẩmToolStripMenuItem";
            xemSảnPhẩmToolStripMenuItem.Size = new Size(98, 20);
            xemSảnPhẩmToolStripMenuItem.Text = "Xem sản phẩm";
            xemSảnPhẩmToolStripMenuItem.Click += xemSảnPhẩmToolStripMenuItem_Click;
            // 
            // giỏHàngToolStripMenuItem
            // 
            giỏHàngToolStripMenuItem.Name = "giỏHàngToolStripMenuItem";
            giỏHàngToolStripMenuItem.Size = new Size(67, 20);
            giỏHàngToolStripMenuItem.Text = "Giỏ hàng";
            giỏHàngToolStripMenuItem.Click += giỏHàngToolStripMenuItem_Click;
            // 
            // đơnĐãMuaToolStripMenuItem
            // 
            đơnĐãMuaToolStripMenuItem.Name = "đơnĐãMuaToolStripMenuItem";
            đơnĐãMuaToolStripMenuItem.Size = new Size(84, 20);
            đơnĐãMuaToolStripMenuItem.Text = "Đơn đã mua";
            // 
            // pnKhachHang
            // 
            pnKhachHang.Dock = DockStyle.Fill;
            pnKhachHang.Location = new Point(0, 24);
            pnKhachHang.Name = "pnKhachHang";
            pnKhachHang.Size = new Size(1064, 577);
            pnKhachHang.TabIndex = 1;
            // 
            // FormKhachHang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1064, 601);
            Controls.Add(pnKhachHang);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormKhachHang";
            Text = "FormKhachHang";
            Load += FormKhachHang_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem xemSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem giỏHàngToolStripMenuItem;
        private ToolStripMenuItem đơnĐãMuaToolStripMenuItem;
        private Panel pnKhachHang;
    }
}