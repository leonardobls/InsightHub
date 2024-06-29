using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationForPesquisadores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisador_SubareaConhecimento_SubareaId",
                table: "Pesquisador");

            migrationBuilder.DropColumn(
                name: "SubareaKey",
                table: "Pesquisador");

            migrationBuilder.AlterColumn<int>(
                name: "SubareaId",
                table: "Pesquisador",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pesquisador_SubareaConhecimento_SubareaId",
                table: "Pesquisador",
                column: "SubareaId",
                principalTable: "SubareaConhecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pesquisador_SubareaConhecimento_SubareaId",
                table: "Pesquisador");

            migrationBuilder.AlterColumn<int>(
                name: "SubareaId",
                table: "Pesquisador",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "SubareaKey",
                table: "Pesquisador",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Pesquisador_SubareaConhecimento_SubareaId",
                table: "Pesquisador",
                column: "SubareaId",
                principalTable: "SubareaConhecimento",
                principalColumn: "Id");
        }
    }
}
