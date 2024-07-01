using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKeyForId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Captacao_Projeto_ProjId",
                table: "Captacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Producao_Projeto_ProjetoId",
                table: "Producao");

            migrationBuilder.DropIndex(
                name: "IX_Captacao_ProjId",
                table: "Captacao");

            migrationBuilder.DropColumn(
                name: "ProjetoKey",
                table: "Producao");

            migrationBuilder.DropColumn(
                name: "ProjId",
                table: "Captacao");

            migrationBuilder.RenameColumn(
                name: "AreaKey",
                table: "SubareaConhecimento",
                newName: "AreaId");

            migrationBuilder.RenameColumn(
                name: "ProjetoKey",
                table: "Captacao",
                newName: "ProjetoId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Producao",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Captacao_ProjetoId",
                table: "Captacao",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Captacao_Projeto_ProjetoId",
                table: "Captacao",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Producao_Projeto_ProjetoId",
                table: "Producao",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Captacao_Projeto_ProjetoId",
                table: "Captacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Producao_Projeto_ProjetoId",
                table: "Producao");

            migrationBuilder.DropIndex(
                name: "IX_Captacao_ProjetoId",
                table: "Captacao");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "SubareaConhecimento",
                newName: "AreaKey");

            migrationBuilder.RenameColumn(
                name: "ProjetoId",
                table: "Captacao",
                newName: "ProjetoKey");

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

            migrationBuilder.AddColumn<int>(
                name: "ProjId",
                table: "Captacao",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Captacao_ProjId",
                table: "Captacao",
                column: "ProjId");

            migrationBuilder.AddForeignKey(
                name: "FK_Captacao_Projeto_ProjId",
                table: "Captacao",
                column: "ProjId",
                principalTable: "Projeto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Producao_Projeto_ProjetoId",
                table: "Producao",
                column: "ProjetoId",
                principalTable: "Projeto",
                principalColumn: "Id");
        }
    }
}
