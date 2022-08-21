namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSinavSoru")]
    public partial class tblSinavSoru
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSinavSoru()
        {
            tblOgrenciSinav = new HashSet<tblOgrenciSinav>();
            tblSinavlar = new HashSet<tblSinavlar>();
        }

        public int ID { get; set; }

        public string Soru { get; set; }

        public string Cevap1 { get; set; }

        public string Cevap2 { get; set; }

        public string Cevap3 { get; set; }

        public string Cevap4 { get; set; }

        public string Cevap5 { get; set; }

        public string DogruCevap { get; set; }

        public bool? Durum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOgrenciSinav> tblOgrenciSinav { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSinavlar> tblSinavlar { get; set; }
    }
}
