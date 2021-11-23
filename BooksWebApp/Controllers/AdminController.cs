using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BooksWebApp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using BooksWebApp.Models.Identity;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace BooksWebApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly KutuphaneDbContext _db;
        private readonly IWebHostEnvironment _host;

        public AdminController(KutuphaneDbContext db, IWebHostEnvironment host)
        {
            _db = db;
            _host = host;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KitapEkle()
        {
            ViewBag.YazarID = new SelectList(_db.Yazarlar.ToList(), "YazarID", "YazarAdi");
            ViewBag.YayinEviID = new SelectList(_db.YayinEvleri.ToList(), "YayinEviID", "YayinEviAdi");

            return View();
        }

        [HttpPost]
        public IActionResult KitapEkle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _db.Kitaplar.Add(kitap);
                _db.SaveChangesAsync();
            }
            return View();
        }

        public IActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult YazarEkle(Yazar yazar)
        {
            if (ModelState.IsValid)
            {
                _db.Yazarlar.Add(yazar);
                _db.SaveChangesAsync();
            }
            return RedirectToAction("YazarEkle");
        }

        public IActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KategoriEkle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _db.Kategoriler.Add(kategori);
                _db.SaveChangesAsync();
            }
            return RedirectToAction("KategoriEkle");
        }

        public IActionResult BekleyenIslemler()
        {
            var OduncVerilecekKitaplar = _db.OduncVerme.Include("Kitap").Include("Uye").Where(o => o.OduncVerildigiTarih.Year == 1).ToList();
            return View(OduncVerilecekKitaplar);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="Onayla"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> BekleyenIslemler(IFormCollection frm, string Onayla)
        {
            //Onayla : OduncVermeID
            string ovt = frm["ovt_" + Onayla].ToString();
            string bit = frm["bit_" + Onayla].ToString();

            var oduncVerme = await _db.FindAsync<OduncVerme>(int.Parse(Onayla));
            oduncVerme.OduncVerildigiTarih = DateTime.Parse(ovt);
            oduncVerme.BeklenenIadeTarihi = DateTime.Parse(bit);
            _db.Entry<OduncVerme>(oduncVerme).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            //TODO: Kitap Tablosundaki OduncVerme alanını true yap...
            //TODO: Listeleme yaparken kullanıcıya odunc verme...

            //var kitap = await _db.FindAsync<Kitap>(oduncVerme.KitapID);

            Kitap kitap = await _db.Kitaplar.Where(k => k.KitapID == oduncVerme.KitapID).SingleOrDefaultAsync();
            kitap.OduncDurumu = true;
            _db.Entry<Kitap>(kitap).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return RedirectToAction("BekleyenIslemler");
        }

        public IActionResult IadeIslemleri(string uyeAdi, string kitapAdi)
        {
            //TODO: Arama
            //todo: Onay
            //Kitap tablosunu guncelle(Odunc Durumu)...
            //TODO: Ceza durumu var mı?

            IEnumerable<OduncVerme> list;
            if (uyeAdi != null)
            {
                list = _db.OduncVerme.Include("Kitap").Include("Uye").Where(o => o.Uye.UserName == uyeAdi && o.GerceklesenIadeTarihi.Year == 1).ToList();
            }
            else if (kitapAdi != null)
            {
                list = _db.OduncVerme.Include("Kitap").Include("Uye").Where(o => o.Kitap.KitapAdi == kitapAdi && o.GerceklesenIadeTarihi.Year == 1).ToList();
            }
            else
                list = _db.OduncVerme.Include("Kitap").Include("Uye").Where(o => o.GerceklesenIadeTarihi.Year == 1).ToList();

            return View(list);
        }

        [HttpPost]
        public IActionResult IadeIslemleri(string Onay)
        {
            //TODO: Arama
            //TODO: Onay
            //Kitap tablosunu guncelle(Odunc Durumu)...
            //TODO: Ceza durumu var mı?
            //TODO: Uye cezali mi?

            //Odunc verme tablosu
            var odunc = _db.OduncVerme.Find(int.Parse(Onay));
            odunc.GerceklesenIadeTarihi = DateTime.Now;
            odunc.IadeEdildi = true;
            _db.Entry<OduncVerme>(odunc).State = EntityState.Modified;
            _db.SaveChanges();

            //Kitap tablosunu guncelle
            var kitap = _db.Kitaplar.Find(odunc.KitapID);
            kitap.OduncDurumu = false;
            _db.Entry<Kitap>(kitap).State = EntityState.Modified;
            _db.SaveChanges();

            //Ceza
            if (odunc.GerceklesenIadeTarihi > odunc.BeklenenIadeTarihi)
            {
                var uye = _db.Users.Find(odunc.UyeID);
                uye.CezaBitisTarihi = DateTime.Now.AddMonths(1);
                _db.Entry<Uye>(uye).State = EntityState.Modified;
                _db.SaveChanges();
            }

            return RedirectToAction("IadeIslemleri");
        }

        //Dosya Yukleme
        public IActionResult KapakResmiYukle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KapakResmiYukle(IFormFile file)
        {
            FileStream fs = new FileStream(_host.ContentRootPath + "/wwwroot/images/" + file.FileName, FileMode.Create);

            file.CopyTo(fs);
            fs.Close();

            return RedirectToAction("KapakResmiYukle");
        }
    }
}
