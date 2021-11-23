using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApp.Models.ViewModel
{
    //[Table("Books", Schema = "Book")]
    public class KitapDetayVM
    {       
        public int KitapID { get; set; }
        public string KitapAdi { get; set; }      
        public string YazarAdi { get; set; }
        public string YayinEviAdi { get; set; }       
        public short SayfaSayisi { get; set; }        
        public string Ozet { get; set; }
        public string KapakResmi { get; set; }
        public short BaskiNo { get; set; }
        public DateTime BasimTarihi { get; set; }
        
        public List<string> Kategoriler { get; set; }
    }
}
