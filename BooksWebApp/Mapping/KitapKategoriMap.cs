using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BooksWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI_I.Mapping
{
    public class KitapKategoriMap : IEntityTypeConfiguration<KitapKategori>
    {
        public void Configure(EntityTypeBuilder<KitapKategori> builder)
        {
            builder.ToTable("KitapKategoriler");
        }
    }
}
