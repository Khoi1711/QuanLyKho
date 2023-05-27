namespace QuanLyKho.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VITRIKHO")]
    public partial class VITRIKHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VITRIKHO()
        {
            VITRISPs = new HashSet<VITRISP>();
        }

        [Key]
        public int MaVTK { get; set; }

        [Required]
        [StringLength(255)]
        public string TenVTK { get; set; }

        [StringLength(255)]
        public string MoTa { get; set; }

        public int MaKhoHang { get; set; }

        public virtual KHOHANG KHOHANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VITRISP> VITRISPs { get; set; }
    }
}
