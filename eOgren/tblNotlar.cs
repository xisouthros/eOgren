namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblNotlar")]
    public partial class tblNotlar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? SinavRef { get; set; }

        public int? Puan { get; set; }

        public bool? Durum { get; set; }

        public virtual tblSinavlar tblSinavlar { get; set; }
    }
}
