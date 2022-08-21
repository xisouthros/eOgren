namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblYorumlar")]
    public partial class tblYorumlar
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Tablo { get; set; }

        public int? TabloRef { get; set; }

        public string Yorum { get; set; }

        public bool? Durum { get; set; }
    }
}
