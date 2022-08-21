namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSinif")]
    public partial class tblSinif
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSinif()
        {
            tblDers = new HashSet<tblDers>();
            tblIcerik = new HashSet<tblIcerik>();
        }

        public int ID { get; set; }

        public int? OkulRef { get; set; }

        public int? BolumRef { get; set; }

        [StringLength(50)]
        public string SinifAd { get; set; }

        public bool? Durum { get; set; }

        public virtual tblBolum tblBolum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDers> tblDers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblIcerik> tblIcerik { get; set; }

        public virtual tblOkul tblOkul { get; set; }
    }
}
