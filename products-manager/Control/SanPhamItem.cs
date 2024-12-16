using products_manager.App_Data;
using products_manager.DTOs;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design.Behavior;

namespace products_manager.Control
{
    public partial class SanPhamItem : UserControl
    {
        string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName + "\\Resources\\images\\";
        SanPham SanPham;
        public SanPhamItem()
        {
            InitializeComponent();
            SanPham = new SanPham();
        }
        public SanPhamItem(SanPham sanPham)
        {
            InitializeComponent();
            SanPham = sanPham;
        }

        private void SanPhamItem_Load(object sender, EventArgs e)
        {
            var imageName = SanPham.HinhAnh;
            var image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            hinhAnh.Image = image;
            lbTenSanPham.Text = SanPham.TenSanPham;
            lbGia.Text = "Giá: " + SanPham.DonGia.ToString() + "$";
            lbSoLuong.Text = "Số lượng: " + SanPham.SoLuongCon.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GioHangDTO gioHangDTO = FormKhachHang.gioHangs.FirstOrDefault(g => g.IdSanPham == SanPham.Id);
            
            if (gioHangDTO == null)
            {
                gioHangDTO = new GioHangDTO();
                gioHangDTO.IdSanPham = SanPham.Id;
                gioHangDTO.SoLuong = 1;
                gioHangDTO.GiaBan = SanPham.DonGia;

                FormKhachHang.gioHangs.Add(gioHangDTO);
            }
            else
            {
                gioHangDTO.SoLuong++;
            }

            DataHelper.WriteToXmlFile("../Data/giohang.xml", FormKhachHang.gioHangs);
        }
    }
}
