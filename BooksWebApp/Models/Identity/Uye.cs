using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApp.Models.Identity
{
    //public class Kullanici:IdentityUser<int> { }
    public class Uye : IdentityUser<int>
    {
        [Column(TypeName = "date")]
        public DateTime CezaBitisTarihi { get; set; }

        public ICollection<Ceza> Cezalar { get; set; }
        public ICollection<OduncVerme> OduncVermeler { get; set; }
    }
}
