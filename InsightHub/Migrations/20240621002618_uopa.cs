using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightHub.Migrations
{
    /// <inheritdoc />
    public partial class uopa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producao_Projeto_ProjetoId",
                table: "Producao");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Producao",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoKey",
                table: "Producao",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Producao_Projeto_ProjetoId",
                table: "Producao",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producao_Projeto_ProjetoId",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "ProjetoKey",
                table: "Producao");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Producao",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producao_Projeto_ProjetoId",
                table: "Producao",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
