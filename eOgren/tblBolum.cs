namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblBolum")]
    public partial class tblBolum
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblBolum()
        {
            tblDers = new HashSet<tblDers>();
            tblIcerik = new HashSet<tblIcerik>();
            tblSinif = new HashSet<tblSinif>();
        }

        public int ID { get; set; }

        public int? OkulRef { get; set; }

        [StringLength(150)]
        public string BolumAd { get; set; }

        public bool? Durum { get; set; }

        public virtual tblOkul tblOkul { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDers> tblDers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblIcerik> tblIcerik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSinif> tblSinif { get; set; }
    }
}
