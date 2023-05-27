namespace QuanLyKho.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPHIEUNHAPKHO")]
    public partial class CTPHIEUNHAPKHO
    {
        [Key]
        public int MaCTPNK { get; set; }

        public int MaSP { get; set; }

        public int MaPNK { get; set; }

        public double DonGia { get; set; }

        public int SoLuongNhap { get; set; }

        public virtual PHIEUNHAPKHO PHIEUNHAPKHO { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
