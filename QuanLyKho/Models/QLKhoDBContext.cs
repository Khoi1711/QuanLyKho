using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLyKho.Models
{
    public partial class QLKhoDBContext : DbContext
    {
    public QLKhoDBContext()
            : base("name=QLKhoDBContext")
        {
        }

        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<CTPHIEUNHAPKHO> CTPHIEUNHAPKHOes { get; set; }
        public virtual DbSet<CTPHIEUXUATKHO> CTPHIEUXUATKHOes { get; set; }
        public virtual DbSet<DONHANG> DONHANGs { get; set; }
        public virtual DbSet<KHOHANG> KHOHANGs { get; set; }
        public virtual DbSet<NHACUNGCAP> NHACUNGCAPs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<NHOMSANPHAM> NHOMSANPHAMs { get; set; }
        public virtual DbSet<PHIEUNHAPKHO> PHIEUNHAPKHOes { get; set; }
        public virtual DbSet<PHIEUXUATKHO> PHIEUXUATKHOes { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<VITRIKHO> VITRIKHOes { get; set; }
        public virtual DbSet<VITRISP> VITRISPs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DONHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KHOHANG>()
                .Property(e => e.SDTKho)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SDTNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.ImgUrl)
                .IsUnicode(false);

            modelBuilder.Entity<PHIEUNHAPKHO>()
                .HasMany(e => e.CTPHIEUNHAPKHOes)
                .WithRequired(e => e.PHIEUNHAPKHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.DonViTinh)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);
        }
  
    }
}
