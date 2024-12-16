using products_manager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.DTOs
{
    public class ChiTietDonHangDTO
    {
        public int ID { get; set; }
        public int SoLuong { get; set; }
        public float GiaBan { get; set; }
        public int IdSanPham { get; set; }
        public int IdDonHang { get; set; }
    }
}
