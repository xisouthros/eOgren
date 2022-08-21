namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblSinavlar")]
    public partial class tblSinavlar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblSinavlar()
        {
            tblNotlar = new HashSet<tblNotlar>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? OkulRef { get; set; }

        public int? BolumRef { get; set; }

        public int? SinifRef { get; set; }

        public int? DersRef { get; set; }

        [StringLength(50)]
        public string SinavTipi { get; set; }

        public int? OgretmenRef { get; set; }

        public int? SoruRef { get; set; }

        public bool? Durum { get; set; }

        public virtual tblIcerik tblIcerik { get; set; }

        public virtual tblIcerik tblIcerik1 { get; set; }

        public virtual tblIcerik tblIcerik2 { get; set; }

        public virtual tblIcerik tblIcerik3 { get; set; }

        public virtual tblKullanici tblKullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblNotlar> tblNotlar { get; set; }

        public virtual tblSinavSoru tblSinavSoru { get; set; }
    }
}
