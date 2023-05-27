namespace QuanLyKho.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPHIEUXUATKHO")]
    public partial class CTPHIEUXUATKHO
    {
        [Key]
        public int MaCTPXK { get; set; }

        public int MaSP { get; set; }

        public int MaPXK { get; set; }

        public double DonGia { get; set; }

        public int SoLuongXuat { get; set; }

        public virtual PHIEUXUATKHO PHIEUXUATKHO { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
