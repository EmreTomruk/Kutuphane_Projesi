using BooksWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using BooksWebApp.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using BooksWebApp.Data;
using System.Text.Json;

namespace BooksWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KutuphaneDbContext _context;

        public HomeController(ILogger<HomeController> logger, KutuphaneDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        
        public IActionResult Index()
        {
            List<KitapVM> kitaplarVM = new List<KitapVM>();
            var kitaplar = _context.Kitaplar.Include("Yazar");

            if (User.Identity.IsAuthenticated)
            {                
                int uyeID = UyeIDBul();
                ViewBag.LinkleriKapat = UyeIkiKitapAliyorMu(uyeID);
                ViewBag.CezaliMi = UyeCezaliMi(uyeID);
            }
            else
            {
                ViewBag.LinkleriKapat = false;
                ViewBag.CezaliMi = false;
            }

            foreach (var kitap in kitaplar)
            {
                var kitapVM = new KitapVM { KitapID = kitap.KitapID, KitapAdi = kitap.KitapAdi, KapakResmi = kitap.KapakResmi, YazarAdi = kitap.Yazar.YazarAdi, OduncDurumu = kitap.OduncDurumu };

                kitaplarVM.Add(kitapVM);
            }
            return View(kitaplarVM);
        }

        public IActionResult OduncAl(int id)
        {
            _context.OduncVerme.Add(new OduncVerme { UyeID = UyeIDBul(), KitapID = id });
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Detay(int id)
        {
            var kitap = _context.Kitaplar.Include("Yazar").Include("YayinEvi").Where(k => k.KitapID == id).SingleOrDefault();

            var kategoriler = _context.KitapKategori.Include("Kategori").Where(kk => kk.KitapID == id).Select(k => k.Kategori.KategoriAdi).ToList();

            var kitapDetay = new KitapDetayVM()
            {
                KitapID = kitap.KitapID,
                KitapAdi = kitap.KitapAdi,
                YazarAdi = kitap.Yazar.YazarAdi,
                YayinEviAdi = kitap.YayinEvi.YayinEviAdi,
                SayfaSayisi = kitap.SayfaSayisi,
                Ozet = kitap.Ozet,
                KapakResmi = kitap.KapakResmi,
                BaskiNo = kitap.BaskiNo,
                BasimTarihi = kitap.BasimTarihi,

                Kategoriler = kategoriler
            };
            return View(kitapDetay);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool UyeIkiKitapAliyorMu(int uyeID)
        {
            var adet = _context.OduncVerme.Where(u => u.UyeID == uyeID && !u.IadeEdildi).Count();
            return adet < 2;
        }

        private bool UyeCezaliMi(int uyeID)
        {
            var uye = _context.Users.Find(uyeID);
            return uye.CezaBitisTarihi > DateTime.Now;
        }

        private int UyeIDBul()
        {
            var eposta = User.Identity.Name;
            var uye = _context.Users.Where(u => u.Email == eposta).SingleOrDefault();

            return uye.Id;
        }
    }    
}
