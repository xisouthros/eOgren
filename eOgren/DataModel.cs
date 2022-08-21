using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace eOgren
{
    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblBolum> tblBolum { get; set; }
        public virtual DbSet<tblDers> tblDers { get; set; }
        public virtual DbSet<tblDuyuru> tblDuyuru { get; set; }
        public virtual DbSet<tblIcerik> tblIcerik { get; set; }
        public virtual DbSet<tblKullanici> tblKullanici { get; set; }
        public virtual DbSet<tblKullaniciYetki> tblKullaniciYetki { get; set; }
        public virtual DbSet<tblMenu> tblMenu { get; set; }
        public virtual DbSet<tblMenuAlt> tblMenuAlt { get; set; }
        public virtual DbSet<tblNotlar> tblNotlar { get; set; }
        public virtual DbSet<tblOgrenciDers> tblOgrenciDers { get; set; }
        public virtual DbSet<tblOgrenciSinav> tblOgrenciSinav { get; set; }
        public virtual DbSet<tblOkul> tblOkul { get; set; }
        public virtual DbSet<tblSinavlar> tblSinavlar { get; set; }
        public virtual DbSet<tblSinavSoru> tblSinavSoru { get; set; }
        public virtual DbSet<tblSinif> tblSinif { get; set; }
        public virtual DbSet<tblVideo> tblVideo { get; set; }
        public virtual DbSet<tblYildizlar> tblYildizlar { get; set; }
        public virtual DbSet<tblYorumlar> tblYorumlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblBolum>()
                .Property(e => e.BolumAd)
                .IsUnicode(false);

            modelBuilder.Entity<tblBolum>()
                .HasMany(e => e.tblDers)
                .WithOptional(e => e.tblBolum)
                .HasForeignKey(e => e.BolumRef);

            modelBuilder.Entity<tblBolum>()
                .HasMany(e => e.tblIcerik)
                .WithOptional(e => e.tblBolum)
                .HasForeignKey(e => e.BolumRef);

            modelBuilder.Entity<tblBolum>()
                .HasMany(e => e.tblSinif)
                .WithOptional(e => e.tblBolum)
                .HasForeignKey(e => e.BolumRef);

            modelBuilder.Entity<tblDers>()
                .Property(e => e.DersAd)
                .IsUnicode(false);

            modelBuilder.Entity<tblDers>()
                .HasMany(e => e.tblIcerik)
                .WithOptional(e => e.tblDers)
                .HasForeignKey(e => e.DersRef);

            modelBuilder.Entity<tblDuyuru>()
                .Property(e => e.Duyuru)
                .IsUnicode(false);

            modelBuilder.Entity<tblIcerik>()
                .Property(e => e.IcerikBaslik)
                .IsUnicode(false);

            modelBuilder.Entity<tblIcerik>()
                .Property(e => e.IcerikMetin)
                .IsUnicode(false);

            modelBuilder.Entity<tblIcerik>()
                .Property(e => e.IcerikLink)
                .IsUnicode(false);

            modelBuilder.Entity<tblIcerik>()
                .Property(e => e.IcerikAciklama)
                .IsUnicode(false);

            modelBuilder.Entity<tblIcerik>()
                .Property(e => e.IcerikZaman)
                .IsUnicode(false);

            modelBuilder.Entity<tblIcerik>()
                .HasMany(e => e.tblSinavlar)
                .WithOptional(e => e.tblIcerik)
                .HasForeignKey(e => e.OkulRef);

            modelBuilder.Entity<tblIcerik>()
                .HasMany(e => e.tblSinavlar1)
                .WithOptional(e => e.tblIcerik1)
                .HasForeignKey(e => e.BolumRef);

            modelBuilder.Entity<tblIcerik>()
                .HasMany(e => e.tblSinavlar2)
                .WithOptional(e => e.tblIcerik2)
                .HasForeignKey(e => e.SinifRef);

            modelBuilder.Entity<tblIcerik>()
                .HasMany(e => e.tblSinavlar3)
                .WithOptional(e => e.tblIcerik3)
                .HasForeignKey(e => e.DersRef);

            modelBuilder.Entity<tblKullanici>()
                .Property(e => e.KullaniciKodu)
                .IsUnicode(false);

            modelBuilder.Entity<tblKullanici>()
                .Property(e => e.Adi)
                .IsUnicode(false);

            modelBuilder.Entity<tblKullanici>()
                .Property(e => e.Soyadi)
                .IsUnicode(false);

            modelBuilder.Entity<tblKullanici>()
                .Property(e => e.Tip)
                .IsUnicode(false);

            modelBuilder.Entity<tblKullanici>()
                .Property(e => e.Unvan)
                .IsUnicode(false);

            modelBuilder.Entity<tblKullanici>()
                .Property(e => e.TelefonNo)
                .IsUnicode(false);

            modelBuilder.Entity<tblKullanici>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<tblKullanici>()
                .Property(e => e.Sifre)
                .IsUnicode(false);

            modelBuilder.Entity<tblKullanici>()
                .HasMany(e => e.tblOgrenciSinav)
                .WithOptional(e => e.tblKullanici)
                .HasForeignKey(e => e.OgrenciRef);

            modelBuilder.Entity<tblKullanici>()
                .HasMany(e => e.tblSinavlar)
                .WithOptional(e => e.tblKullanici)
                .HasForeignKey(e => e.OgretmenRef);

            modelBuilder.Entity<tblKullanici>()
                .HasMany(e => e.tblVideo)
                .WithOptional(e => e.tblKullanici)
                .HasForeignKey(e => e.OgretmenRef);

            modelBuilder.Entity<tblKullaniciYetki>()
                .Property(e => e.Kullanici)
                .IsUnicode(false);

            modelBuilder.Entity<tblMenu>()
                .Property(e => e.MenuAd)
                .IsUnicode(false);

            modelBuilder.Entity<tblMenuAlt>()
                .Property(e => e.Ad)
                .IsUnicode(false);

            modelBuilder.Entity<tblMenuAlt>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<tblMenuAlt>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<tblOgrenciSinav>()
                .Property(e => e.CevapRef)
                .IsUnicode(false);

            modelBuilder.Entity<tblOkul>()
                .Property(e => e.OkulAd)
                .IsUnicode(false);

            modelBuilder.Entity<tblOkul>()
                .HasMany(e => e.tblBolum)
                .WithOptional(e => e.tblOkul)
                .HasForeignKey(e => e.OkulRef);

            modelBuilder.Entity<tblOkul>()
                .HasMany(e => e.tblDers)
                .WithOptional(e => e.tblOkul)
                .HasForeignKey(e => e.OkulRef);

            modelBuilder.Entity<tblOkul>()
                .HasMany(e => e.tblIcerik)
                .WithOptional(e => e.tblOkul)
                .HasForeignKey(e => e.OkulRef);

            modelBuilder.Entity<tblOkul>()
                .HasMany(e => e.tblSinif)
                .WithOptional(e => e.tblOkul)
                .HasForeignKey(e => e.OkulRef);

            modelBuilder.Entity<tblSinavlar>()
                .Property(e => e.SinavTipi)
                .IsUnicode(false);

            modelBuilder.Entity<tblSinavlar>()
                .HasMany(e => e.tblNotlar)
                .WithOptional(e => e.tblSinavlar)
                .HasForeignKey(e => e.SinavRef);

            modelBuilder.Entity<tblSinavSoru>()
                .Property(e => e.Soru)
                .IsUnicode(false);

            modelBuilder.Entity<tblSinavSoru>()
                .Property(e => e.Cevap1)
                .IsUnicode(false);

            modelBuilder.Entity<tblSinavSoru>()
                .Property(e => e.Cevap2)
                .IsUnicode(false);

            modelBuilder.Entity<tblSinavSoru>()
                .Property(e => e.Cevap3)
                .IsUnicode(false);

            modelBuilder.Entity<tblSinavSoru>()
                .Property(e => e.Cevap4)
                .IsUnicode(false);

            modelBuilder.Entity<tblSinavSoru>()
                .Property(e => e.Cevap5)
                .IsUnicode(false);

            modelBuilder.Entity<tblSinavSoru>()
                .Property(e => e.DogruCevap)
                .IsUnicode(false);

            modelBuilder.Entity<tblSinavSoru>()
                .HasMany(e => e.tblOgrenciSinav)
                .WithOptional(e => e.tblSinavSoru)
                .HasForeignKey(e => e.SinavRef);

            modelBuilder.Entity<tblSinavSoru>()
                .HasMany(e => e.tblSinavlar)
                .WithOptional(e => e.tblSinavSoru)
                .HasForeignKey(e => e.SoruRef);

            modelBuilder.Entity<tblSinif>()
                .Property(e => e.SinifAd)
                .IsUnicode(false);

            modelBuilder.Entity<tblSinif>()
                .HasMany(e => e.tblDers)
                .WithOptional(e => e.tblSinif)
                .HasForeignKey(e => e.SinifRef);

            modelBuilder.Entity<tblSinif>()
                .HasMany(e => e.tblIcerik)
                .WithOptional(e => e.tblSinif)
                .HasForeignKey(e => e.SinifRef);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.VideoAd)
                .IsUnicode(false);

            modelBuilder.Entity<tblVideo>()
                .Property(e => e.VideoLink)
                .IsUnicode(false);

            modelBuilder.Entity<tblYildizlar>()
                .Property(e => e.Tablo)
                .IsUnicode(false);

            modelBuilder.Entity<tblYorumlar>()
                .Property(e => e.Tablo)
                .IsUnicode(false);

            modelBuilder.Entity<tblYorumlar>()
                .Property(e => e.Yorum)
                .IsUnicode(false);
        }
    }
}
