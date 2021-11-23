using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWebApp.Models
{
    public class YayinEvi
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int YayinEviID { get; set; }
        public string YayinEviAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string EPosta { get; set; }

        [NotMapped]
        public string Iletisim { get => YayinEviAdi + " " + Adres + " " + Telefon + " " + EPosta; }
        public List<Kitap> Kitap { get; set; }
    }
}
