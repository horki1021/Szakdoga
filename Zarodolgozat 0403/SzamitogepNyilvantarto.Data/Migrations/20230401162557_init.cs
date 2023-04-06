using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SzamitogepNyilvantarto.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allapotok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Elnevezes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allapotok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Felhasznalok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FelhasznaloNev = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Jelszo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DokumentumTipus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Felhasznalok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Szamitogepek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Azonosito = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Processzor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MemoriaTipusa = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    MemoriaMerete = table.Column<int>(type: "int", nullable: false),
                    HattertarTipusa = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    HatertarMerete = table.Column<int>(type: "int", nullable: false),
                    Terem = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AllapotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szamitogepek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Szamitogepek_Allapotok_AllapotId",
                        column: x => x.AllapotId,
                        principalTable: "Allapotok",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Hibak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BejelentesDatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HibaLeiras = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    JavitasLeiras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisszakerulesDatum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Terem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllapotId = table.Column<int>(type: "int", nullable: false),
                    HibasGepId = table.Column<int>(type: "int", nullable: false),
                    CsereGepId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hibak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hibak_Allapotok_AllapotId",
                        column: x => x.AllapotId,
                        principalTable: "Allapotok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hibak_Szamitogepek_CsereGepId",
                        column: x => x.CsereGepId,
                        principalTable: "Szamitogepek",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hibak_Szamitogepek_HibasGepId",
                        column: x => x.HibasGepId,
                        principalTable: "Szamitogepek",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Allapotok",
                columns: new[] { "Id", "Elnevezes" },
                values: new object[,]
                {
                    { 1, "Használatban" },
                    { 2, "Használatra kész" },
                    { 3, "Hibás" },
                    { 4, "Javítás alatt" },
                    { 5, "Leselejtezve" },
                    { 6, "Megoldódott" }
                });

            migrationBuilder.InsertData(
                table: "Felhasznalok",
                columns: new[] { "Id", "DokumentumTipus", "FelhasznaloNev", "Jelszo" },
                values: new object[] { 1, "pdf", "Admin", "136115117218236981692404550166601582019910026154138662282501431011442351461411516818112318151222934126776423914526192488911188226191219120166324018314414820623266861245" });

            migrationBuilder.CreateIndex(
                name: "IX_Hibak_AllapotId",
                table: "Hibak",
                column: "AllapotId");

            migrationBuilder.CreateIndex(
                name: "IX_Hibak_CsereGepId",
                table: "Hibak",
                column: "CsereGepId");

            migrationBuilder.CreateIndex(
                name: "IX_Hibak_HibasGepId",
                table: "Hibak",
                column: "HibasGepId");

            migrationBuilder.CreateIndex(
                name: "IX_Szamitogepek_AllapotId",
                table: "Szamitogepek",
                column: "AllapotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Felhasznalok");

            migrationBuilder.DropTable(
                name: "Hibak");

            migrationBuilder.DropTable(
                name: "Szamitogepek");

            migrationBuilder.DropTable(
                name: "Allapotok");
        }
    }
}
