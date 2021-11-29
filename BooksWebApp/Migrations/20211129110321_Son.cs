using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksWebApp.Migrations
{
    public partial class Son : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kategoriler",
                keyColumn: "KategoriID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategoriler",
                keyColumn: "KategoriID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kategoriler",
                keyColumn: "KategoriID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "KitapKategori",
                keyColumns: new[] { "KategoriID", "KitapID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "KitapKategori",
                keyColumns: new[] { "KategoriID", "KitapID" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "Kategoriler",
                keyColumn: "KategoriID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kategoriler",
                keyColumn: "KategoriID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "KitapID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "YayinEvleri",
                keyColumn: "YayinEviID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "YayinEvleri",
                keyColumn: "YayinEviID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Yazarlar",
                keyColumn: "YazarID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Yazarlar",
                keyColumn: "YazarID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a9636c86-7e36-441b-8908-663c2ff6b6a1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f9da7e74-6ad8-4b27-9b14-33c63d738926");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ba990bf5-68e7-4369-adeb-39be8450b645");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e8749113-a193-4aa7-a83f-19a5822e0fb8");

            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "KategoriID", "KategoriAdi" },
                values: new object[,]
                {
                    { 1, "Polisiye" },
                    { 2, "Gezi" },
                    { 3, "Bilim Kurgu" },
                    { 4, "Tarih" },
                    { 5, "Fantastik" }
                });

            migrationBuilder.InsertData(
                table: "YayinEvleri",
                columns: new[] { "YayinEviID", "Adres", "EPosta", "Telefon", "YayinEviAdi" },
                values: new object[,]
                {
                    { 1, null, null, null, "Güneş Yayınları" },
                    { 2, null, null, null, "Bulut Yayıncılık" }
                });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "YazarID", "OzetBiyografi", "YazarAdi" },
                values: new object[,]
                {
                    { 1, "...", "Fyodor Dostoevsky" },
                    { 2, "Bio", "Lev Tolstoy" }
                });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "KitapID", "BasimTarihi", "BaskiNo", "KapakResmi", "KayitTarihi", "KitapAdi", "OduncDurumu", "Ozet", "SayfaSayisi", "YayinEviID", "YazarID" },
                values: new object[] { 2, new DateTime(2000, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)4, "sucveceza.jpg", new DateTime(2021, 11, 11, 14, 17, 40, 779, DateTimeKind.Local).AddTicks(1179), "Suc ve Ceza", false, "Biri suclunun Raskolnikov...", (short)356, 2, 1 });

            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "KitapID", "BasimTarihi", "BaskiNo", "KapakResmi", "KayitTarihi", "KitapAdi", "OduncDurumu", "Ozet", "SayfaSayisi", "YayinEviID", "YazarID" },
                values: new object[] { 1, new DateTime(1960, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), (short)2, "yildiz.jpg", new DateTime(2021, 11, 11, 14, 17, 40, 779, DateTimeKind.Local).AddTicks(1179), "Yıldız Savasları", false, "Darth Vader...", (short)456, 1, 2 });

            migrationBuilder.InsertData(
                table: "KitapKategori",
                columns: new[] { "KategoriID", "KitapID" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "KitapKategori",
                columns: new[] { "KategoriID", "KitapID" },
                values: new object[] { 3, 1 });
        }
    }
}
