using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApp.Models.ViewModel
{
    public class KitapVM
    {
        public int KitapID { get; set; }
        public string KitapAdi { get; set; }
        public string KapakResmi { get; set; }
        public string YazarAdi { get; set; }
        public bool OduncDurumu { get; set; }
    }
}
