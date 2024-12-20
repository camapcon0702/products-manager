﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using products_manager.App_Data;

#nullable disable

namespace products_manager.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20241215130003_Alter_SP_add_HinhAnh")]
    partial class Alter_SP_add_HinhAnh
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("products_manager.Models.ChiTietDonHang", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("GiaBan")
                        .HasColumnType("real");

                    b.Property<int>("IdDonHang")
                        .HasColumnType("int");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IdDonHang");

                    b.HasIndex("IdSanPham");

                    b.ToTable("ChiTietDonHang");
                });

            modelBuilder.Entity("products_manager.Models.DanhMuc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDanhMuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DanhMuc", (string)null);
                });

            modelBuilder.Entity("products_manager.Models.DonHang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("IdTaiKhoan")
                        .HasColumnType("int");

                    b.Property<DateOnly>("NgayLapDon")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("IdTaiKhoan");

                    b.ToTable("DonHang", (string)null);
                });

            modelBuilder.Entity("products_manager.Models.GioHang", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<float>("GiaBan")
                        .HasColumnType("real");

                    b.Property<int>("IdSanPham")
                        .HasColumnType("int");

                    b.Property<int>("IdTaiKhoan")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IdSanPham");

                    b.HasIndex("IdTaiKhoan");

                    b.ToTable("GioHang");
                });

            modelBuilder.Entity("products_manager.Models.NhaCungCap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenNhaCungCap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NhaCungCap", (string)null);
                });

            modelBuilder.Entity("products_manager.Models.Quyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenQuyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Quyen", (string)null);
                });

            modelBuilder.Entity("products_manager.Models.SanPham", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("DonGia")
                        .HasColumnType("real");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDanhMuc")
                        .HasColumnType("int");

                    b.Property<int>("IdNhaCungCap")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongCon")
                        .HasColumnType("int");

                    b.Property<string>("TenSanPham")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDanhMuc");

                    b.HasIndex("IdNhaCungCap");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("products_manager.Models.TaiKhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdQuyen")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdQuyen");

                    b.ToTable("TaiKhoan", (string)null);
                });

            modelBuilder.Entity("products_manager.Models.ChiTietDonHang", b =>
                {
                    b.HasOne("products_manager.Models.DonHang", "DonHang")
                        .WithMany("chiTietDonHangs")
                        .HasForeignKey("IdDonHang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("products_manager.Models.SanPham", "SanPham")
                        .WithMany("chiTietDonHangs")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonHang");

                    b.Navigation("SanPham");
                });

            modelBuilder.Entity("products_manager.Models.DonHang", b =>
                {
                    b.HasOne("products_manager.Models.TaiKhoan", "TaiKhoan")
                        .WithMany("donHangs")
                        .HasForeignKey("IdTaiKhoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("products_manager.Models.GioHang", b =>
                {
                    b.HasOne("products_manager.Models.SanPham", "SanPham")
                        .WithMany("gioHangs")
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("products_manager.Models.TaiKhoan", "TaiKhoan")
                        .WithMany("gioHangs")
                        .HasForeignKey("IdTaiKhoan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPham");

                    b.Navigation("TaiKhoan");
                });

            modelBuilder.Entity("products_manager.Models.SanPham", b =>
                {
                    b.HasOne("products_manager.Models.DanhMuc", "DanhMuc")
                        .WithMany("sanPhams")
                        .HasForeignKey("IdDanhMuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("products_manager.Models.NhaCungCap", "NhaCungCap")
                        .WithMany("sanPhams")
                        .HasForeignKey("IdNhaCungCap")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMuc");

                    b.Navigation("NhaCungCap");
                });

            modelBuilder.Entity("products_manager.Models.TaiKhoan", b =>
                {
                    b.HasOne("products_manager.Models.Quyen", "Quyen")
                        .WithMany("taiKhoans")
                        .HasForeignKey("IdQuyen");

                    b.Navigation("Quyen");
                });

            modelBuilder.Entity("products_manager.Models.DanhMuc", b =>
                {
                    b.Navigation("sanPhams");
                });

            modelBuilder.Entity("products_manager.Models.DonHang", b =>
                {
                    b.Navigation("chiTietDonHangs");
                });

            modelBuilder.Entity("products_manager.Models.NhaCungCap", b =>
                {
                    b.Navigation("sanPhams");
                });

            modelBuilder.Entity("products_manager.Models.Quyen", b =>
                {
                    b.Navigation("taiKhoans");
                });

            modelBuilder.Entity("products_manager.Models.SanPham", b =>
                {
                    b.Navigation("chiTietDonHangs");

                    b.Navigation("gioHangs");
                });

            modelBuilder.Entity("products_manager.Models.TaiKhoan", b =>
                {
                    b.Navigation("donHangs");

                    b.Navigation("gioHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
