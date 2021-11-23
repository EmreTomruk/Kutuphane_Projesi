using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWebApp.Models
{
    //public class KitapKategori
    public class KitapKategori
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KitapKategoriID { get; set; }
        public int KitapID { get; set; }
        public int KategoriID { get; set; }

        public Kategori Kategori { get; set; }
        public Kitap Kitap { get; set; }
    }
}
