using BooksWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApp.Interfaces
{
    interface IKutuphaneDbContext : IDbContext
    {
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<KitapKategori> KitapKategori { get; set; }
        public DbSet<YayinEvi> YayinEvleri { get; set; }
        public DbSet<OduncVerme> OduncVerme { get; set; }
        public DbSet<Ceza> Cezalar { get; set; }
    }
}
