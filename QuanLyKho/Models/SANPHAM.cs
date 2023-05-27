namespace QuanLyKho.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CHITIETDONHANGs = new HashSet<CHITIETDONHANG>();
            CTPHIEUNHAPKHOes = new HashSet<CTPHIEUNHAPKHO>();
            CTPHIEUXUATKHOes = new HashSet<CTPHIEUXUATKHO>();
            VITRISPs = new HashSet<VITRISP>();
        }

        [Key]
        public int MaSP { get; set; }

        [Required]
        [StringLength(255)]
        public string TenSP { get; set; }

        [StringLength(255)]
        public string Mota { get; set; }

        public double DonGia { get; set; }

        [Required]
        [StringLength(50)]
        public string DonViTinh { get; set; }

        public int SoLuongTon { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        public double? KhoiLuong { get; set; }

        public int MaNCC { get; set; }

        public int MaNhomSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETDONHANG> CHITIETDONHANGs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUNHAPKHO> CTPHIEUNHAPKHOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUXUATKHO> CTPHIEUXUATKHOes { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }

        public virtual NHOMSANPHAM NHOMSANPHAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VITRISP> VITRISPs { get; set; }
    }
}
