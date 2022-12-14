namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblYildizlar")]
    public partial class tblYildizlar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Tablo { get; set; }

        public int? TabloRef { get; set; }

        public int? KacYildiz { get; set; }

        public bool? Durum { get; set; }
    }
}
