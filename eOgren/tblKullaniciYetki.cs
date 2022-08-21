namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblKullaniciYetki")]
    public partial class tblKullaniciYetki
    {
        public int ID { get; set; }

        public int? MenuRef { get; set; }

        public int? SubMenuRef { get; set; }

        [StringLength(50)]
        public string Kullanici { get; set; }

        public bool? Oku { get; set; }

        public bool? Yaz { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OlusturmaTarih { get; set; }

        public TimeSpan? OlusturmaSaat { get; set; }
    }
}
