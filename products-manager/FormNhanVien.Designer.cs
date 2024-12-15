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
            menu.Size = new Size(1180, 33);
            menu.TabIndex = 0;
            menu.Text = "menu";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuDangXuat });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(103, 29);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // menuDangXuat
            // 
            menuDangXuat.Name = "menuDangXuat";
            menuDangXuat.Size = new Size(195, 34);
            menuDangXuat.Text = "Đăng xuất";
            // 
            // menuQLDM
            // 
            menuQLDM.Name = "menuQLDM";
            menuQLDM.Size = new Size(173, 29);
            menuQLDM.Text = "Quản lý danh mục";
            menuQLDM.Click += menuQLDM_Click;
            // 
            // menuQLNCC
            // 
            menuQLNCC.Name = "menuQLNCC";
            menuQLNCC.Size = new Size(200, 29);
            menuQLNCC.Text = "Quản lý nhà cung cấp";
            menuQLNCC.Click += menuQLNCC_Click;
            // 
            // menuQLSP
            // 
            menuQLSP.Name = "menuQLSP";
            menuQLSP.Size = new Size(172, 29);
            menuQLSP.Text = "Quản lý sản phẩm";
            menuQLSP.Click += menuQLSP_Click;
            // 
            // menuXMLtoSQL
            // 
            menuXMLtoSQL.Name = "menuXMLtoSQL";
            menuXMLtoSQL.Size = new Size(207, 29);
            menuXMLtoSQL.Text = "Chuyển XML sang SQL";
            menuXMLtoSQL.Click += menuXMLtoSQL_Click;
            // 
            // pnNhanVien
            // 
            pnNhanVien.BackgroundImage = Properties.Resources.background;
            pnNhanVien.BackgroundImageLayout = ImageLayout.Center;
            pnNhanVien.Dock = DockStyle.Fill;
            pnNhanVien.Location = new Point(0, 33);
            pnNhanVien.Name = "pnNhanVien";
            pnNhanVien.Size = new Size(1180, 618);
            pnNhanVien.TabIndex = 1;
            // 
            // FormNhanVien
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1180, 651);
            Controls.Add(pnNhanVien);
            Controls.Add(menu);
            MainMenuStrip = menu;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormNhanVien";
            Text = "FormNhanVien";
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