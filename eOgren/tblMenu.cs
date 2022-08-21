namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMenu")]
    public partial class tblMenu
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string MenuAd { get; set; }
    }
}
