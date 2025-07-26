using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stream.Migrations
{
    /// <inheritdoc />
    public partial class Atualizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "Episodios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Episodios_SerieId",
                table: "Episodios",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodios_Series_SerieId",
                table: "Episodios",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodios_Series_SerieId",
                table: "Episodios");

            migrationBuilder.DropIndex(
                name: "IX_Episodios_SerieId",
                table: "Episodios");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "Episodios");
        }
    }
}
