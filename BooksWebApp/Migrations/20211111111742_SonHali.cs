using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksWebApp.Migrations
{
    public partial class SonHali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CezaBitisTarihi = table.Column<DateTime>(type: "date", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "YayinEvleri",
                columns: table => new
                {
                    YayinEviID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YayinEviAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EPosta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YayinEvleri", x => x.YayinEviID);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    YazarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OzetBiyografi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.YazarID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cezalar",
                columns: table => new
                {
                    CezaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CezaTarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cezalar", x => x.CezaID);
                    table.ForeignKey(
                        name: "FK_Cezalar_AspNetUsers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapAdi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    YazarID = table.Column<int>(type: "int", nullable: false),
                    YayinEviID = table.Column<int>(type: "int", nullable: false),
                    SayfaSayisi = table.Column<short>(type: "smallint", nullable: false),
                    OduncDurumu = table.Column<bool>(type: "bit", nullable: false),
                    Ozet = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    KapakResmi = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BaskiNo = table.Column<short>(type: "smallint", nullable: false),
                    BasimTarihi = table.Column<DateTime>(type: "date", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.KitapID);
                    table.ForeignKey(
                        name: "FK_Kitaplar_YayinEvleri_YayinEviID",
                        column: x => x.YayinEviID,
                        principalTable: "YayinEvleri",
                        principalColumn: "YayinEviID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Yazarlar_YazarID",
                        column: x => x.YazarID,
                        principalTable: "Yazarlar",
                        principalColumn: "YazarID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KitapKategori",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    KitapKategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapKategori", x => new { x.KitapID, x.KategoriID });
                    table.ForeignKey(
                        name: "FK_KitapKategori_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapKategori_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OduncVerme",
                columns: table => new
                {
                    OduncVermeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UyeID = table.Column<int>(type: "int", nullable: false),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    OduncVerildigiTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeklenenIadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GerceklesenIadeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IadeEdildi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OduncVerme", x => x.OduncVermeID);
                    table.ForeignKey(
                        name: "FK_OduncVerme_AspNetUsers_UyeID",
                        column: x => x.UyeID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OduncVerme_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "ba990bf5-68e7-4369-adeb-39be8450b645", "Admin", "ADMIN" },
                    { 2, "e8749113-a193-4aa7-a83f-19a5822e0fb8", "Uye", "UYE" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cezalar_UyeID",
                table: "Cezalar",
                column: "UyeID");

            migrationBuilder.CreateIndex(
                name: "IX_KitapKategori_KategoriID",
                table: "KitapKategori",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YayinEviID",
                table: "Kitaplar",
                column: "YayinEviID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YazarID",
                table: "Kitaplar",
                column: "YazarID");

            migrationBuilder.CreateIndex(
                name: "IX_OduncVerme_KitapID",
                table: "OduncVerme",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_OduncVerme_UyeID",
                table: "OduncVerme",
                column: "UyeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Cezalar");

            migrationBuilder.DropTable(
                name: "KitapKategori");

            migrationBuilder.DropTable(
                name: "OduncVerme");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "YayinEvleri");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
