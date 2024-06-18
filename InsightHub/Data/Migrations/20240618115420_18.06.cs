using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class _1806 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QualquerCoisaId",
                table: "Projeto",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_QualquerCoisaId",
                table: "Projeto",
                column: "QualquerCoisaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projeto_SubareaConhecimento_QualquerCoisaId",
                table: "Projeto",
                column: "QualquerCoisaId",
                principalTable: "SubareaConhecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projeto_SubareaConhecimento_QualquerCoisaId",
                table: "Projeto");

            migrationBuilder.DropIndex(
                name: "IX_Projeto_QualquerCoisaId",
                table: "Projeto");

            migrationBuilder.DropColumn(
                name: "QualquerCoisaId",
                table: "Projeto");
        }
    }
}
