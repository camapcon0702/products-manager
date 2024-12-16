using products_manager.App_Data;
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
    public partial class GioHangControl : UserControl
    {
        private IGioHangRepository _gioHangRepo;
        private ITaiKhoanRepository _taiKhoanRepository;
        private IChiTietDonHangRepository _chiTietDonHangRepository;
        public List<GioHangItem> gioHangItems;
        public GioHangControl()
        {
            InitializeComponent();
            _gioHangRepo = new GioHangRepository(new AppDataContext());
            _taiKhoanRepository = new TaiKhoanRepository(new AppDataContext());
            _chiTietDonHangRepository = new ChiTietDonHangRepository(new AppDataContext());
        }

        private async void GioHangControl_Load(object sender, EventArgs e)
        {
            await _gioHangRepo.UpdateGioHangFromXml("../Data/giohang.xml");
            gioHangItems = _gioHangRepo.GioHangsToControls();
            foreach (var item in gioHangItems)
            {
                item.CheckBoxCheckedChanged += GioHangItem_CheckBoxCheckedChanged;
                flowLayoutPanel.Controls.Add(item);
            }
            TinhTongGia();
        }

        private void GioHangItem_CheckBoxCheckedChanged(object? sender, GioHangItem e)
        {
            TinhTongGia();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            for (int i = gioHangItems.Count - 1; i >= 0; i--)
            {
                var item = gioHangItems[i];
                CheckBox chkSelect = item.Controls.OfType<CheckBox>().FirstOrDefault();

                if (chkSelect != null && chkSelect.Checked)
                {
                    flowLayoutPanel.Controls.Remove(item);
                    gioHangItems.RemoveAt(i);
                    _gioHangRepo.DeleteSanPhamFromGioHang(item.sanPham.Id);
                    DataHelper.DeleteSanPhamFromGioHangXML("../Data/giohang.xml", item.sanPham.Id);
                }
            }
            //DataHelper.WriteToXmlFile("../Data/giohang.xml", FormKhachHang.gioHangs);
        }

        private async void btnMua_Click(object sender, EventArgs e)
        {
            var chiTiets = new List<ChiTietDonHang>();
            for (int i = gioHangItems.Count - 1; i >= 0; i--)
            {
                var item = gioHangItems[i];
                CheckBox chkSelect = item.Controls.OfType<CheckBox>().FirstOrDefault();

                if (chkSelect != null && chkSelect.Checked)
                {
                    flowLayoutPanel.Controls.Remove(item);
                    gioHangItems.RemoveAt(i);
                    _gioHangRepo.DeleteSanPhamFromGioHang(item.sanPham.Id);
                    DataHelper.DeleteSanPhamFromGioHangXML("../Data/giohang.xml", item.sanPham.Id);

                    ChiTietDonHang chiTietDonHang = new ChiTietDonHang();
                    chiTietDonHang.SoLuong = item.gioHang.SoLuong;
                    chiTietDonHang.GiaBan = item.gioHang.GiaBan;
                    chiTietDonHang.SanPham = item.sanPham;

                    chiTiets.Add(chiTietDonHang);
                }
            }
            if (chiTiets.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm", "Thông báo");
            }
            else
            {
                await _chiTietDonHangRepository.CreateDonHangAsync(chiTiets);
                MessageBox.Show("Đặt hàng thành công", "Thông báo");
            }
        }

        public void TinhTongGia()
        {
            float tong = 0;
            for (int i = gioHangItems.Count - 1; i >= 0; i--)
            {
                var item = gioHangItems[i];
                CheckBox chkSelect = item.Controls.OfType<CheckBox>().FirstOrDefault();

                if (chkSelect != null && chkSelect.Checked)
                {
                    tong += item.gioHang.SoLuong * item.gioHang.GiaBan;
                }
            }
            lbThanhTien.Text = "Tổng giá: " + tong + "$";
        }

        private void GioHangItem_CheckBoxCheckedChanged(object sender, SanPhamItem e)
        {
            TinhTongGia();
        }

        private void lbThanhTien_Click(object sender, EventArgs e)
        {

        }
    }
}
