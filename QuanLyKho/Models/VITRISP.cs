namespace QuanLyKho.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VITRISP")]
    public partial class VITRISP
    {
        [Key]
        public int MaVTSP { get; set; }

        public int SoLuong { get; set; }

        public int MaSP { get; set; }

        public int MaVTK { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        public virtual VITRIKHO VITRIKHO { get; set; }
    }
}
