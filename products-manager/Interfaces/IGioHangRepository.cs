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
        public Task<List<GioHang>> GetGioHangByUser();
        public Task<List<GioHangDTO>> GetGioHangDTOByUser();
        public Task CreateXMLGioHang();
        public Task UpdateGioHangFromXml(string filePath);

    }
}
