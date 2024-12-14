using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Models
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public int Id { get; set; }
        public string TenDanhMuc {  get; set; }
        public string MoTa { get; set; }
        public List<SanPham> sanPhams { get; set; } = new List<SanPham>();
    }
}
