using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using products_manager.App_Data;
using products_manager.Control;
using products_manager.DTOs;
using products_manager.Interfaces;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace products_manager.Repositories
{
    public class GioHangRepository : IGioHangRepository
    {
        private readonly AppDataContext _context;
        private readonly ITaiKhoanRepository _taiKhoanRepository;
        public GioHangRepository(AppDataContext context)
        {
            _context = context;
            _taiKhoanRepository = new TaiKhoanRepository(context);
        }
        public void CreateXMLGioHang()
        {
            var listGioHang = GetGioHangByUser();

            List<XElement> gioHangs = new List<XElement>();

            foreach (var item in listGioHang)
            {
                XElement xElement = new XElement("GioHang",
                    new XElement("Id", item.ID),
                    new XElement("SoLuong", item.SoLuong),
                    new XElement("GiaBan", item.GiaBan),
                    new XElement("IdTaiKhoan", item.TaiKhoan.Id),
                    new XElement("IdSanPham", item.SanPham.Id));
                gioHangs.Add(xElement);
            }

            XElement root = new XElement("ChiTietGioHang", gioHangs);

            root.Save("../Data/ChiTietGioHang.xml");
        }

        public void DeleteSanPhamFromGioHang(int idSp)
        {
            var gioHangItem = _context.gioHangs.FirstOrDefault(g => g.SanPham.Id == idSp);
            if (gioHangItem != null)
            {
                _context.gioHangs.Remove(gioHangItem);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Không tìm thấy sản phẩm trong giỏ hàng.");
            }
        }


        public List<GioHang> GetGioHangByUser()
        {
            var user = _taiKhoanRepository.FindTaiKhoanByAuth();

            using (var context = new AppDataContext())
            {

                return context.gioHangs
                    .Include(g => g.TaiKhoan)
                    .Include(g => g.SanPham)
                    .Where(g => g.TaiKhoan.Id == user.Id)
                    .ToList();
            }
        }

        public List<GioHangDTO> GetGioHangDTOByUser()
        {
            var gioHangs = GetGioHangByUser();
            var gioHangDTOs = new List<GioHangDTO>();
            foreach (var item in gioHangs)
            {
                var gioHangDTO = new GioHangDTO();
                gioHangDTO.IdSanPham = item.SanPham.Id;
                gioHangDTO.IdTaiKhoan = item.TaiKhoan.Id;
                gioHangDTO.SoLuong = item.SoLuong;
                gioHangDTO.GiaBan = item.GiaBan;
                gioHangDTO.isSelected = false;

                gioHangDTOs.Add(gioHangDTO);
            }
            return gioHangDTOs;
        }

        public List<GioHangItem> GioHangsToControls()
        {
            var gioHangs = GetGioHangByUser();
            var items = new List<GioHangItem>();
            foreach(var item in gioHangs)
            {
                items.Add(new GioHangItem(item));
            }
            return items;
        }

        public async Task UpdateGioHangFromXml(string filePath)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(List<GioHangDTO>));
                List<GioHangDTO> gioHangDTOs;

                using (var reader = new StreamReader(filePath))
                {
                    gioHangDTOs = (List<GioHangDTO>)serializer.Deserialize(reader);
                }

                int idUser = _taiKhoanRepository.FindTaiKhoanByAuth().Id;

                var currentUser = await _context.taiKhoans.FindAsync(idUser);

                if (currentUser == null)
                {
                    throw new Exception("Tài khoản hiện tại không tồn tại.");
                }

                foreach (var dto in gioHangDTOs)
                {
                    var existingGioHang = await _context.gioHangs
                        .Include(g => g.SanPham)
                        .FirstOrDefaultAsync(g => g.SanPham.Id == dto.IdSanPham && g.TaiKhoan.Id == currentUser.Id);

                    if (existingGioHang != null)
                    {
                        existingGioHang.SoLuong = dto.SoLuong;
                        existingGioHang.GiaBan = dto.GiaBan;
                    }
                    else
                    {
                        var sanPham = await _context.sanPhams.FindAsync(dto.IdSanPham);
                        if (sanPham == null)
                        {
                            throw new Exception($"Sản phẩm với ID {dto.IdSanPham} không tồn tại.");
                        }

                        var newGioHang = new GioHang
                        {
                            SoLuong = dto.SoLuong,
                            GiaBan = dto.GiaBan,
                            SanPham = sanPham,
                            TaiKhoan = currentUser
                        };
                        _context.gioHangs.Add(newGioHang);
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
