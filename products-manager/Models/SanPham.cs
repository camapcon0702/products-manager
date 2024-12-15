using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int Id { get; set; }
        public string? TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public float DonGia { get; set; }
        public int SoLuongCon { get; set; }
        public DanhMuc DanhMuc { get; set; }
        public NhaCungCap NhaCungCap { get; set; }
        public List<ChiTietDonHang> chiTietDonHangs { get; set; } = new List<ChiTietDonHang>();
        public List<GioHang> gioHangs { get; set; } = new List<GioHang>();
    }
}
