namespace QuanLyKho.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHOHANG")]
    public partial class KHOHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHOHANG()
        {
            VITRIKHOes = new HashSet<VITRIKHO>();
        }

        [Key]
        public int MaKhoHang { get; set; }

        [Required]
        [StringLength(200)]
        public string LoaiKho { get; set; }

        [Required]
        [StringLength(255)]
        public string TenKhohang { get; set; }

        [Required]
        [StringLength(255)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(20)]
        public string SDTKho { get; set; }

        public int Succhua { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VITRIKHO> VITRIKHOes { get; set; }
    }
}
