using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Models
{
    [Table("Quyen")]
    public class Quyen
    {
        [Key]
        public int Id { get; set; }
        public string TenQuyen { get; set; }
        public string MoTa { get; set; }
        public List<TaiKhoan> taiKhoans { get; set; } = new List<TaiKhoan>();
    }
}
