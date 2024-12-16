using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.DTOs
{
    public class GioHangDTO
    {
        public int SoLuong { get; set; }
        public float GiaBan { get; set; }
        public int IdSanPham { get; set; }
        public int IdTaiKhoan { get; set; }
        public bool isSelected { get; set; }
    }
}
