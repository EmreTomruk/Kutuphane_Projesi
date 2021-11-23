using BooksWebApp.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWebApp.Models
{
    public class OduncVerme
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OduncVermeID { get; set; } //BekleyenIslemler'deki "Onay" butonundan gelir...
        public int UyeID { get; set; }
        public int KitapID { get; set; }
        public DateTime OduncVerildigiTarih { get; set; }
        public DateTime BeklenenIadeTarihi { get; set; }
        public DateTime GerceklesenIadeTarihi { get; set; }
        public bool IadeEdildi { get; set; }


        public Uye Uye { get; set; }
        public Kitap Kitap { get; set; }
    }
}
