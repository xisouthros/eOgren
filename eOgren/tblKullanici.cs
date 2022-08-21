namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblKullanici")]
    public partial class tblKullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblKullanici()
        {
            tblOgrenciSinav = new HashSet<tblOgrenciSinav>();
            tblSinavlar = new HashSet<tblSinavlar>();
            tblVideo = new HashSet<tblVideo>();
        }

        public int ID { get; set; }

        [StringLength(15)]
        public string KullaniciKodu { get; set; }

        [StringLength(50)]
        public string Adi { get; set; }

        [StringLength(50)]
        public string Soyadi { get; set; }

        [StringLength(20)]
        public string Tip { get; set; }

        [StringLength(50)]
        public string Unvan { get; set; }

        [StringLength(15)]
        public string TelefonNo { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(25)]
        public string Sifre { get; set; }

        public bool? Durum { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OlusturulmaTarihi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOgrenciSinav> tblOgrenciSinav { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSinavlar> tblSinavlar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblVideo> tblVideo { get; set; }
    }
}
