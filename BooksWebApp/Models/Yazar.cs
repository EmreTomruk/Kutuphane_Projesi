using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApp.Models
{
    public class Yazar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YazarID { get; set; }
        public string YazarAdi { get; set; }
        public string OzetBiyografi { get; set; }
        public ICollection<Kitap> Kitaplar { get; set; }
    }
}
