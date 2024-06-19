using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InsightHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoConhecimento");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Captacao");

            migrationBuilder.AddColumn<int>(
                name: "AreaKey",
                table: "SubareaConhecimento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "SubareaConhecimento",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubareaId",
                table: "Projeto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pesquisador",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pesquisador",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "SubareaId",
                table: "Pesquisador",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubareaKey",
                table: "Pesquisador",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "Data",
                table: "Captacao",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "ProjId",
                table: "Captacao",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjetoKey",
                table: "Captacao",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "AreaConhecimento",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_SubareaId",
                table: "Projeto",
                column: "SubareaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesquisador_SubareaId",
                table: "Pesquisador",
                column: "SubareaId");

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
                name: "FK_Pesquisador_SubareaConhecimento_SubareaId",
                table: "Pesquisador",
                column: "SubareaId",
                principalTable: "SubareaConhecimento",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_SubareaConhecimento_SubareaId",
                table: "Projeto",
                column: "SubareaId",
                principalTable: "SubareaConhecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Captacao_Projeto_ProjId",
                table: "Captacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisador_SubareaConhecimento_SubareaId",
                table: "Pesquisador");

            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_SubareaConhecimento_SubareaId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_SubareaId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Pesquisador_SubareaId",
                table: "Pesquisador");

            migrationBuilder.DropIndex(
                name: "IX_Captacao_ProjId",
                table: "Captacao");

            migrationBuilder.DropColumn(
                name: "AreaKey",
                table: "SubareaConhecimento");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "SubareaConhecimento");

            migrationBuilder.DropColumn(
                name: "SubareaId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "SubareaId",
                table: "Pesquisador");

            migrationBuilder.DropColumn(
                name: "SubareaKey",
                table: "Pesquisador");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Captacao");

            migrationBuilder.DropColumn(
                name: "ProjId",
                table: "Captacao");

            migrationBuilder.DropColumn(
                name: "ProjetoKey",
                table: "Captacao");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "AreaConhecimento");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Pesquisador",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pesquisador",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Captacao",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CursoConhecimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoConhecimento", x => x.Id);
                });
        }
    }
}
