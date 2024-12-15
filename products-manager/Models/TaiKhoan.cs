using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public int Id { get; set; }
        public string? HoTen {  get; set; }
        public string? Email { get; set; }
        public string? MatKhau { get; set; }
        public Quyen? Quyen { get; set; }
        public List<DonHang> donHangs { get; set; } = new List<DonHang>();
        public List<GioHang> gioHangs { get; set; } = new List<GioHang>();

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
