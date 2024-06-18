using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracaocap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Captacao");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Captacao_Projeto_ProjId",
                table: "Captacao");

            migrationBuilder.DropIndex(
                name: "IX_Captacao_ProjId",
                table: "Captacao");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Captacao");

            migrationBuilder.DropColumn(
                name: "ProjId",
                table: "Captacao");

            migrationBuilder.DropColumn(
                name: "ProjetoKey",
                table: "Captacao");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Captacao",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
