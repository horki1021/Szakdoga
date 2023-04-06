using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SzamitogepNyilvantarto.Data.Migrations
{
    /// <inheritdoc />
    public partial class hiba2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hibak_Allapotok_AllapotId",
                table: "Hibak");

            migrationBuilder.AlterColumn<int>(
                name: "AllapotId",
                table: "Hibak",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Hibak_Allapotok_AllapotId",
                table: "Hibak",
                column: "AllapotId",
                principalTable: "Allapotok",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hibak_Allapotok_AllapotId",
                table: "Hibak");

            migrationBuilder.AlterColumn<int>(
                name: "AllapotId",
                table: "Hibak",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Hibak_Allapotok_AllapotId",
                table: "Hibak",
                column: "AllapotId",
                principalTable: "Allapotok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
