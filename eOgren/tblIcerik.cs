namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblIcerik")]
    public partial class tblIcerik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblIcerik()
        {
            tblSinavlar = new HashSet<tblSinavlar>();
            tblSinavlar1 = new HashSet<tblSinavlar>();
            tblSinavlar2 = new HashSet<tblSinavlar>();
            tblSinavlar3 = new HashSet<tblSinavlar>();
        }

        public int ID { get; set; }

        public int? OkulRef { get; set; }

        public int? BolumRef { get; set; }

        public int? SinifRef { get; set; }

        public int? DersRef { get; set; }

        [StringLength(50)]
        public string IcerikBaslik { get; set; }

        public string IcerikMetin { get; set; }

        public string IcerikLink { get; set; }

        public string IcerikAciklama { get; set; }

        [StringLength(50)]
        public string IcerikZaman { get; set; }

        public bool? Durum { get; set; }

        public virtual tblBolum tblBolum { get; set; }

        public virtual tblDers tblDers { get; set; }

        public virtual tblOkul tblOkul { get; set; }

        public virtual tblSinif tblSinif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSinavlar> tblSinavlar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSinavlar> tblSinavlar1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSinavlar> tblSinavlar2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSinavlar> tblSinavlar3 { get; set; }
    }
}
