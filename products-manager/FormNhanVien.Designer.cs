namespace products_manager
{
    partial class FormNhanVien
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
            menu = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            menuDangXuat = new ToolStripMenuItem();
            menuQLDM = new ToolStripMenuItem();
            menuQLNCC = new ToolStripMenuItem();
            menuQLSP = new ToolStripMenuItem();
            menuXMLtoSQL = new ToolStripMenuItem();
            pnNhanVien = new Panel();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // menu
            // 
            menu.ImageScalingSize = new Size(24, 24);
            menu.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, menuQLDM, menuQLNCC, menuQLSP, menuXMLtoSQL });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Padding = new Padding(4, 1, 0, 1);
            menu.Size = new Size(826, 24);
            menu.TabIndex = 0;
            menu.Text = "menu";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuDangXuat });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(69, 22);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // menuDangXuat
            // 
            menuDangXuat.Name = "menuDangXuat";
            menuDangXuat.Size = new Size(127, 22);
            menuDangXuat.Text = "Đăng xuất";
            // 
            // menuQLDM
            // 
            menuQLDM.Name = "menuQLDM";
            menuQLDM.Size = new Size(117, 22);
            menuQLDM.Text = "Quản lý danh mục";
            menuQLDM.Click += menuQLDM_Click;
            // 
            // menuQLNCC
            // 
            menuQLNCC.Name = "menuQLNCC";
            menuQLNCC.Size = new Size(135, 22);
            menuQLNCC.Text = "Quản lý nhà cung cấp";
            menuQLNCC.Click += menuQLNCC_Click;
            // 
            // menuQLSP
            // 
            menuQLSP.Name = "menuQLSP";
            menuQLSP.Size = new Size(115, 22);
            menuQLSP.Text = "Quản lý sản phẩm";
            menuQLSP.Click += menuQLSP_Click;
            // 
            // menuXMLtoSQL
            // 
            menuXMLtoSQL.Name = "menuXMLtoSQL";
            menuXMLtoSQL.Size = new Size(139, 22);
            menuXMLtoSQL.Text = "Chuyển XML sang SQL";
            menuXMLtoSQL.Click += menuXMLtoSQL_Click;
            // 
            // pnNhanVien
            // 
            pnNhanVien.BackgroundImage = Properties.Resources.background;
            pnNhanVien.BackgroundImageLayout = ImageLayout.Center;
            pnNhanVien.Dock = DockStyle.Fill;
            pnNhanVien.Location = new Point(0, 24);
            pnNhanVien.Margin = new Padding(2, 2, 2, 2);
            pnNhanVien.Name = "pnNhanVien";
            pnNhanVien.Size = new Size(826, 367);
            pnNhanVien.TabIndex = 1;
            // 
            // FormNhanVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(826, 391);
            Controls.Add(pnNhanVien);
            Controls.Add(menu);
            MainMenuStrip = menu;
            Name = "FormNhanVien";
            Text = "FormNhanVien";
            Load += FormNhanVien_Load;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menu;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem menuDangXuat;
        private ToolStripMenuItem menuQLDM;
        private ToolStripMenuItem menuQLNCC;
        private ToolStripMenuItem menuQLSP;
        private Panel pnNhanVien;
        private ToolStripMenuItem menuXMLtoSQL;
    }
}