using products_manager.Interfaces;
using products_manager.Models;
using products_manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace products_manager.Control
{
    public partial class GioHangItem : UserControl
    {
        public SanPham sanPham;
        public GioHang gioHang;
        private readonly ISanPhamRepository _sanPhamRepo;
        public event EventHandler<GioHangItem> CheckBoxCheckedChanged;
        public GioHangItem()
        {
            InitializeComponent();
            _sanPhamRepo = new SanPhamRepository(new App_Data.AppDataContext());
        }
        public GioHangItem(GioHang giohang)
        {
            InitializeComponent();
            gioHang = giohang;
            _sanPhamRepo = new SanPhamRepository(new App_Data.AppDataContext());
            //sanPham = _sanPhamRepo.GetSanPhamById(gioHang.SanPham.Id);
        }

        private void GioHangItem_Load(object sender, EventArgs e)
        {
            sanPham = _sanPhamRepo.GetSanPhamById(gioHang.SanPham.Id);
            var imageName = sanPham.HinhAnh;
            var image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            hinhAnh.Image = image;
            lbTenSanPham.Text = sanPham.TenSanPham;
            lbGia.Text = "Giá: " + sanPham.DonGia.ToString() + "$";
            lbSoLuong.Text = "Số lượng: " + gioHang.SoLuong.ToString();

            checkBox.CheckedChanged += checkBox_CheckedChanged;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxCheckedChanged?.Invoke(this, this);
        }
    }
}
