using Microsoft.EntityFrameworkCore;
using products_manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace products_manager.App_Data
{
    public class AppDataContext : DbContext
    {
        public DbSet<DanhMuc> danhMucs { get; set; }
        public DbSet<NhaCungCap> nhaCungCaps { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<Quyen> quyens { get; set; }
        public DbSet<TaiKhoan> taiKhoans { get; set; }
        public DbSet<DonHang> donHangs { get; set; }
        public DbSet<ChiTietDonHang> chiTietDonHangs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DanhMuc>()
                .ToTable("DanhMuc")
                .HasMany(d => d.sanPhams)
                .WithOne(s => s.DanhMuc)
                .HasForeignKey("IdDanhMuc");

            modelBuilder.Entity<NhaCungCap>()
                .ToTable("NhaCungCap")
                .HasMany(n => n.sanPhams)
                .WithOne(s => s.NhaCungCap)
                .HasForeignKey("IdNhaCungCap");

            modelBuilder.Entity<SanPham>()
                .ToTable("SanPham")
                .HasMany(s => s.chiTietDonHangs)
                .WithOne(c => c.SanPham)
                .HasForeignKey("IdSanPham");

            modelBuilder.Entity<DonHang>()
                .ToTable("DonHang")
                .HasMany(d => d.chiTietDonHangs)
                .WithOne(c => c.DonHang)
                .HasForeignKey("IdDonHang");

            modelBuilder.Entity<Quyen>()
                .ToTable("Quyen")
                .HasMany(q => q.taiKhoans)
                .WithOne(t => t.Quyen)
                .HasForeignKey("IdQuyen");

            modelBuilder.Entity<TaiKhoan>()
                .ToTable("TaiKhoan")
                .HasMany(t => t.donHangs)
                .WithOne(d => d.TaiKhoan)
                .HasForeignKey("IdTaiKhoan");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HaChau;Initial Catalog=products_manager;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
