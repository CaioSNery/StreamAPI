using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stream.Migrations
{
    /// <inheritdoc />
    public partial class Novo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "Temporadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genero",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "Temporadas");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Series");
        }
    }
}
