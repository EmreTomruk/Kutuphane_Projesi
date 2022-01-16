using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BooksWebApp.Models.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BooksWebApp.Models.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(
             new Rol { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
             new Rol { Id = 2, Name = "Uye", NormalizedName = "UYE" });
        }
    }
}
