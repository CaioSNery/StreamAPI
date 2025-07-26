using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stream.Migrations
{
    /// <inheritdoc />
    public partial class MapVisualizacaoFilme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VizualizacaoFIlmes_Clientes_ClienteId",
                table: "VizualizacaoFIlmes");

            migrationBuilder.DropForeignKey(
                name: "FK_VizualizacaoFIlmes_Filmes_FilmeId",
                table: "VizualizacaoFIlmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VizualizacaoFIlmes",
                table: "VizualizacaoFIlmes");

            migrationBuilder.RenameTable(
                name: "VizualizacaoFIlmes",
                newName: "VisualizacoesFilmes");

            migrationBuilder.RenameIndex(
                name: "IX_VizualizacaoFIlmes_FilmeId",
                table: "VisualizacoesFilmes",
                newName: "IX_VisualizacoesFilmes_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_VizualizacaoFIlmes_ClienteId",
                table: "VisualizacoesFilmes",
                newName: "IX_VisualizacoesFilmes_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisualizacoesFilmes",
                table: "VisualizacoesFilmes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisualizacoesFilmes_Clientes_ClienteId",
                table: "VisualizacoesFilmes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisualizacoesFilmes_Filmes_FilmeId",
                table: "VisualizacoesFilmes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisualizacoesFilmes_Clientes_ClienteId",
                table: "VisualizacoesFilmes");

            migrationBuilder.DropForeignKey(
                name: "FK_VisualizacoesFilmes_Filmes_FilmeId",
                table: "VisualizacoesFilmes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VisualizacoesFilmes",
                table: "VisualizacoesFilmes");

            migrationBuilder.RenameTable(
                name: "VisualizacoesFilmes",
                newName: "VizualizacaoFIlmes");

            migrationBuilder.RenameIndex(
                name: "IX_VisualizacoesFilmes_FilmeId",
                table: "VizualizacaoFIlmes",
                newName: "IX_VizualizacaoFIlmes_FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_VisualizacoesFilmes_ClienteId",
                table: "VizualizacaoFIlmes",
                newName: "IX_VizualizacaoFIlmes_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VizualizacaoFIlmes",
                table: "VizualizacaoFIlmes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VizualizacaoFIlmes_Clientes_ClienteId",
                table: "VizualizacaoFIlmes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VizualizacaoFIlmes_Filmes_FilmeId",
                table: "VizualizacaoFIlmes",
                column: "FilmeId",
                principalTable: "Filmes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
