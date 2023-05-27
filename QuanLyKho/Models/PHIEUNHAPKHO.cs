namespace QuanLyKho.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUNHAPKHO")]
    public partial class PHIEUNHAPKHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUNHAPKHO()
        {
            CTPHIEUNHAPKHOes = new HashSet<CTPHIEUNHAPKHO>();
        }

        [Key]
        public int MaPNK { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayNhap { get; set; }

        public double TongTien { get; set; }

        public int TongSPNhapKho { get; set; }

        public int MaNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUNHAPKHO> CTPHIEUNHAPKHOes { get; set; }

        public virtual NHACUNGCAP NHACUNGCAP { get; set; }
    }
}
