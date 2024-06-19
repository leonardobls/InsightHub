using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InsightHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateProjetoPesquisadorPivot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Producao",
                newName: "Titulo");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Producao",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Producao",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "Producao",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProjetoPesquisadorPivot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjetoId = table.Column<int>(type: "integer", nullable: false),
                    PesquisadorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoPesquisadorPivot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjetoPesquisadorPivot_Pesquisador_PesquisadorId",
                        column: x => x.PesquisadorId,
                        principalTable: "Pesquisador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjetoPesquisadorPivot_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoTipo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoPesquisadorPivot_PesquisadorId",
                table: "ProjetoPesquisadorPivot",
                column: "PesquisadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoPesquisadorPivot_ProjetoId",
                table: "ProjetoPesquisadorPivot",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjetoPesquisadorPivot");

            migrationBuilder.DropTable(
                name: "ProjetoTipo");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "Producao");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Producao",
                newName: "Tipo");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "Producao",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
