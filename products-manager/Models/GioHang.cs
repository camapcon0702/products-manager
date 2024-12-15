﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.Models
{
    [Table("GioHang")]
    public class GioHang
    {
        [Key]
        public int ID { get; set; }
        public int SoLuong { get; set; }
        public float GiaBan { get; set; }
        public SanPham SanPham { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
    }
}