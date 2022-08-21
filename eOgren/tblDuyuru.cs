namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblDuyuru")]
    public partial class tblDuyuru
    {
        public int ID { get; set; }

        public int? KullaniciRef { get; set; }

        public int? SinifRef { get; set; }

        public string Duyuru { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public TimeSpan? CreateTime { get; set; }
    }
}
