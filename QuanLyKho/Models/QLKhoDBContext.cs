using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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
            modelBuilder.Entity<CHUCVU>()
                .HasMany(e => e.NHANVIENs)
                .WithRequired(e => e.CHUCVU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONHANG>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<DONHANG>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.DONHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHOHANG>()
                .Property(e => e.SDTKho)
                .IsUnicode(false);

            modelBuilder.Entity<KHOHANG>()
                .HasMany(e => e.VITRIKHOes)
                .WithRequired(e => e.KHOHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .Property(e => e.SDTNCC)
                .IsUnicode(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.PHIEUNHAPKHOes)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHACUNGCAP>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.NHACUNGCAP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.ImgUrl)
                .IsUnicode(false);

            modelBuilder.Entity<NHOMSANPHAM>()
                .HasMany(e => e.SANPHAMs)
                .WithRequired(e => e.NHOMSANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUNHAPKHO>()
                .HasMany(e => e.CTPHIEUNHAPKHOes)
                .WithRequired(e => e.PHIEUNHAPKHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHIEUXUATKHO>()
                .HasMany(e => e.CTPHIEUXUATKHOes)
                .WithRequired(e => e.PHIEUXUATKHO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.DonViTinh)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTPHIEUNHAPKHOes)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CTPHIEUXUATKHOes)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.VITRISPs)
                .WithRequired(e => e.SANPHAM)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VITRIKHO>()
                .HasMany(e => e.VITRISPs)
                .WithRequired(e => e.VITRIKHO)
                .WillCascadeOnDelete(false);
        }
    }
}
