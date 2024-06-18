using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class migracaopp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Pesquisador",
                newName: "SubareaKey");

            migrationBuilder.AddColumn<int>(
                name: "SubareaId",
                table: "Pesquisador",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pesquisador_SubareaId",
                table: "Pesquisador",
                column: "SubareaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pesquisador_SubareaConhecimento_SubareaId",
                table: "Pesquisador",
                column: "SubareaId",
                principalTable: "SubareaConhecimento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisador_SubareaConhecimento_SubareaId",
                table: "Pesquisador");

            migrationBuilder.DropIndex(
                name: "IX_Pesquisador_SubareaId",
                table: "Pesquisador");

            migrationBuilder.DropColumn(
                name: "SubareaId",
                table: "Pesquisador");

            migrationBuilder.RenameColumn(
                name: "SubareaKey",
                table: "Pesquisador",
                newName: "AreaId");
        }
    }
}
