using products_manager.Control;
using products_manager.DTOs;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Interfaces
{
    public interface IGioHangRepository
    {
        public List<GioHang> GetGioHangByUser();
        public List<GioHangDTO> GetGioHangDTOByUser();
        public void CreateXMLGioHang();
        public Task UpdateGioHangFromXml(string filePath);
        public List<GioHangItem> GioHangsToControls();
        public void DeleteSanPhamFromGioHang(int idSp);
    }
}
