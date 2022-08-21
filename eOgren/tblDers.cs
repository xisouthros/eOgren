namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblDers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDers()
        {
            tblIcerik = new HashSet<tblIcerik>();
        }

        public int ID { get; set; }

        public int? OkulRef { get; set; }

        public int? BolumRef { get; set; }

        public int? SinifRef { get; set; }

        [StringLength(100)]
        public string DersAd { get; set; }

        public bool? Durum { get; set; }

        public virtual tblBolum tblBolum { get; set; }

        public virtual tblOkul tblOkul { get; set; }

        public virtual tblSinif tblSinif { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblIcerik> tblIcerik { get; set; }
    }
}
