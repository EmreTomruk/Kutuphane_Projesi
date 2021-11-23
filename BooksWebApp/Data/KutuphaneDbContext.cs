using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using BooksWebApp.Models;
using BooksWebApp.Models.Identity;
using BooksWebApp.Models.Configuration;

namespace BooksWebApp.Data
{
    public class KutuphaneDbContext : IdentityDbContext<Uye, Rol, int>
    {
        public KutuphaneDbContext()
        {
        }

        public KutuphaneDbContext(DbContextOptions<KutuphaneDbContext> options)
            : base(options)
        {
        }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<KitapKategori> KitapKategori { get; set; }
        public DbSet<YayinEvi> YayinEvleri { get; set; }
        public DbSet<OduncVerme> OduncVerme { get; set; }
        public DbSet<Ceza> Cezalar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //optionsBuilder.UseSqlServer("Data source=.; initial catalog = KutuphaneProje; integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //InitData(builder);

            RolConfiguration rolConfig = new RolConfiguration();
            builder.ApplyConfiguration<Rol>(rolConfig);

            builder.Entity<KitapKategori>().HasKey(hk => new { hk.KitapID, hk.KategoriID });

            builder.Entity<KitapKategori>().HasOne(hk => hk.Kitap).WithMany(k => k.KitapKategoriler).HasForeignKey(hk => hk.KitapID);

            builder.Entity<KitapKategori>().HasOne(hk => hk.Kategori).WithMany(k => k.KitapKategoriler).HasForeignKey(hk => hk.KategoriID);
        }

        //private void InitData(ModelBuilder builder)
        //{
        //    builder.Entity<Yazar>().HasData(
        //        new Yazar { YazarID = 1, YazarAdi = "Fyodor Dostoevsky", OzetBiyografi = "..." },
        //        new Yazar { YazarID = 2, YazarAdi = "Lev Tolstoy", OzetBiyografi = "Bio" }
        //        );

        //    builder.Entity<YayinEvi>().HasData(
        //        new YayinEvi { YayinEviID = 1, YayinEviAdi = "Güneş Yayınları" },
        //        new YayinEvi { YayinEviID = 2, YayinEviAdi = "Bulut Yayıncılık" }
        //        );

        //    builder.Entity<Kategori>().HasData(
        //        new Kategori { KategoriID = 1, KategoriAdi = "Polisiye" },
        //        new Kategori { KategoriID = 2, KategoriAdi = "Gezi" },
        //        new Kategori { KategoriID = 3, KategoriAdi = "Bilim Kurgu" },
        //        new Kategori { KategoriID = 4, KategoriAdi = "Tarih" },
        //        new Kategori { KategoriID = 5, KategoriAdi = "Fantastik" }
        //        );

        //    builder.Entity<Kitap>().HasData(
        //        new Kitap { KitapID = 1, KitapAdi = "Yıldız Savasları", YayinEviID = 1, YazarID = 2, Ozet = "Darth Vader...", KapakResmi = "yildiz.jpg", BaskiNo = 2, SayfaSayisi = 456, BasimTarihi = new DateTime(1960, 10, 30) },
        //        new Kitap { KitapID = 2, KitapAdi = "Suc ve Ceza", YayinEviID = 2, YazarID = 1, Ozet = "Biri suclunun Raskolnikov...", KapakResmi = "sucveceza.jpg", BaskiNo = 4, SayfaSayisi = 356, BasimTarihi = new DateTime(2000, 7, 15) }
        //        );

        //    builder.Entity<KitapKategori>().HasData(
        //        new KitapKategori { KitapID = 1, KategoriID = 3 },
        //        new KitapKategori { KitapID = 2, KategoriID = 4 }
        //        );
        //}
    }
}
