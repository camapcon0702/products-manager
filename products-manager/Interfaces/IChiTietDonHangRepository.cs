using products_manager.DTOs;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Interfaces
{
    public interface IChiTietDonHangRepository
    {
        public Task CreateDonHangAsync(List<ChiTietDonHang> chiTiets);
        public DataTable GetChiTietDonHangAsDataTable(int donHangId);
    }
}
