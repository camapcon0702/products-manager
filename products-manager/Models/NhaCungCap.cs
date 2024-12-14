using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Models
{
    [Table("NhaCungCap")]
    public class NhaCungCap
    {
        [Key]
        public int Id { get; set; }
        public string TenNhaCungCap {  get; set; }
        public string DiaChi {  get; set; }
        public string SoDienThoai { get; set; }
        public List<SanPham> sanPhams { get; set; } = new List<SanPham>();
    }
}
