namespace QuanLyKho.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUXUATKHO")]
    public partial class PHIEUXUATKHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUXUATKHO()
        {
            CTPHIEUXUATKHOes = new HashSet<CTPHIEUXUATKHO>();
        }

        [Key]
        public int MaPXK { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayXuat { get; set; }

        public double TongTien { get; set; }

        public int TongSPXuatKho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUXUATKHO> CTPHIEUXUATKHOes { get; set; }
    }
}
