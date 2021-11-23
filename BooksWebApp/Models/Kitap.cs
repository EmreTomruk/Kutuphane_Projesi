using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BooksWebApp.Models;

namespace BooksWebApp.Models
{
    public class Kitap
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KitapID { get; set; }

        [StringLength(200)]
        [Required]
        public string KitapAdi { get; set; }
        public int YazarID { get; set; }
        public int YayinEviID { get; set; }
        public short SayfaSayisi { get; set; }
        public bool OduncDurumu { get; set; }
        [StringLength(300)]
        public string Ozet { get; set; }
        [StringLength(30)]
        public string KapakResmi { get; set; }
        public short BaskiNo { get; set; }
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0: MM-YY}", ApplyFormatInEditMode = true)]
        public DateTime BasimTarihi { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime KayitTarihi { get; set; } = DateTime.Now;


        public Yazar Yazar { get; set; }
        public YayinEvi YayinEvi { get; set; }
        public ICollection<KitapKategori> KitapKategoriler { get; set; }
    }
}
