using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BooksWebApp.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksWebApp.Models
{
    public class Ceza
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CezaID { get; set; }
        public int UyeID { get; set; }
        public string Aciklama { get; set; }
        public DateTime CezaTarih { get; set; }


        public Uye Uye { get; set; }
    }
}
