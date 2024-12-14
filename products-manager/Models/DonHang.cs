using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Models
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public int Id { get; set; }
        public DateOnly NgayLapDon {  get; set; }
        public TaiKhoan TaiKhoan { get; set; }
        public List<ChiTietDonHang> chiTietDonHangs { get; set; } = new List<ChiTietDonHang>();
    }
}
