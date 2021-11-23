using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWebApp.Models
{
    public class Kategori
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }

        public ICollection<KitapKategori> KitapKategoriler { get; set; }
    }
}
