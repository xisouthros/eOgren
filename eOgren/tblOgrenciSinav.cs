namespace eOgren
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblOgrenciSinav")]
    public partial class tblOgrenciSinav
    {
        public int ID { get; set; }

        public int? OgrenciRef { get; set; }

        public int? SinavRef { get; set; }

        public string CevapRef { get; set; }

        public bool? Durum { get; set; }

        public virtual tblKullanici tblKullanici { get; set; }

        public virtual tblSinavSoru tblSinavSoru { get; set; }
    }
}
