using Microsoft.EntityFrameworkCore;
using products_manager.App_Data;
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
        public async Task CreateXMLGioHang()
        {
            var listGioHang = await GetGioHangByUser();

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

        public async Task<List<GioHang>> GetGioHangByUser()
        {
            var user = await _taiKhoanRepository.FindTaiKhoanByAuth();
            return await _context.gioHangs
                .Include(g => g.TaiKhoan)
                .Include(g => g.SanPham)
                .Where(g => g.TaiKhoan == user)
                .ToListAsync();
        }

        public async Task<List<GioHangDTO>> GetGioHangDTOByUser()
        {
            var gioHangs = await GetGioHangByUser();
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

        public async Task UpdateGioHangFromXml(string filePath)
        {
            try
            {
                // Bước 1: Deserialize XML thành danh sách GioHangDTO
                var serializer = new XmlSerializer(typeof(List<GioHangDTO>));
                List<GioHangDTO> gioHangDTOs;

                var reader = new StreamReader(filePath);
                gioHangDTOs = (List<GioHangDTO>)serializer.Deserialize(reader);

                foreach (var dto in gioHangDTOs)
                {
                    var existingGioHang = await _context.gioHangs
                        .Include(g => g.SanPham)
                        .FirstOrDefaultAsync(g => g.SanPham.Id == dto.IdSanPham);

                    if (existingGioHang != null)
                    {
                        //existingGioHang.SoLuong += dto.SoLuong;
                        existingGioHang.GiaBan = dto.GiaBan;
                    }
                    else
                    {
                        // Thêm mới sản phẩm vào giỏ hàng
                        var newGioHang = new GioHang
                        {
                            SoLuong = dto.SoLuong,
                            GiaBan = dto.GiaBan,
                            SanPham = await _context.sanPhams.FindAsync(dto.IdSanPham),
                            TaiKhoan = await _taiKhoanRepository.FindTaiKhoanByAuth()
                        };
                        _context.gioHangs.Add(newGioHang);
                    }

                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
