namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblVideo")]
    public partial class tblVideo
    {
        public int ID { get; set; }

        public int? OgretmenRef { get; set; }

        public string VideoAd { get; set; }

        public string VideoLink { get; set; }

        public bool? Durum { get; set; }

        public virtual tblKullanici tblKullanici { get; set; }
    }
}
