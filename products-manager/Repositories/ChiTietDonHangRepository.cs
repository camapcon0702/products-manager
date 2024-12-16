using Microsoft.EntityFrameworkCore;
using products_manager.App_Data;
using products_manager.DTOs;
using products_manager.Interfaces;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Repositories
{
    public class ChiTietDonHangRepository : IChiTietDonHangRepository
    {
        private readonly AppDataContext _context;
        private readonly ITaiKhoanRepository _taiKhoanRepository;
        public ChiTietDonHangRepository(AppDataContext context)
        {
            _context = context;
            _taiKhoanRepository = new TaiKhoanRepository(context);
        }

        public async Task CreateDonHangAsync(List<ChiTietDonHang> chiTiets)
        {
            try
            {
                var currentUser = _taiKhoanRepository.FindTaiKhoanByAuth();

                var taiKhoan = await _context.taiKhoans.FindAsync(currentUser.Id);

                var donHang = new DonHang
                {
                    NgayLapDon = DateOnly.FromDateTime(DateTime.Now), 
                    TaiKhoan = taiKhoan 
                };

                foreach (var item in chiTiets)
                {
                    var sanPham = await _context.sanPhams.FindAsync(item.SanPham.Id);
                    if (sanPham == null)
                    {
                        throw new Exception("Sản phẩm không tồn tại.");
                    }

                    var chiTietDonHang = new ChiTietDonHang
                    {
                        SoLuong = item.SoLuong,
                        GiaBan = item.GiaBan,
                        SanPham = sanPham, 
                        DonHang = donHang 
                    };

                    donHang.chiTietDonHangs.Add(chiTietDonHang);
                }

                _context.donHangs.Add(donHang);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetChiTietDonHangAsDataTable(int donHangId)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Tên sản phẩm", typeof(string));
            dataTable.Columns.Add("Số lượng", typeof(int));
            dataTable.Columns.Add("Giá bán", typeof(decimal));
            dataTable.Columns.Add("Thành tiền", typeof(decimal));

            try
            {
                var chiTietDonHangs = _context.chiTietDonHangs
                    .Include(ct => ct.SanPham)
                    .Where(ct => ct.DonHang.Id == donHangId)
                    .ToList();

                foreach (var chiTiet in chiTietDonHangs)
                {
                    decimal thanhTien = chiTiet.SoLuong * (decimal)chiTiet.GiaBan;
                    dataTable.Rows.Add(
                        chiTiet.ID,
                        chiTiet.SanPham.TenSanPham,
                        chiTiet.SoLuong,
                        (decimal)chiTiet.GiaBan,
                        thanhTien
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy chi tiết đơn hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

    }
}
