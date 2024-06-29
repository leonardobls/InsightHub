using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterSubareasModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubareaConhecimento_AreaConhecimento_AreaConhecimentoId",
                table: "SubareaConhecimento");

            migrationBuilder.AlterColumn<int>(
                name: "AreaConhecimentoId",
                table: "SubareaConhecimento",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_SubareaConhecimento_AreaConhecimento_AreaConhecimentoId",
                table: "SubareaConhecimento",
                column: "AreaConhecimentoId",
                principalTable: "AreaConhecimento",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubareaConhecimento_AreaConhecimento_AreaConhecimentoId",
                table: "SubareaConhecimento");

            migrationBuilder.AlterColumn<int>(
                name: "AreaConhecimentoId",
                table: "SubareaConhecimento",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SubareaConhecimento_AreaConhecimento_AreaConhecimentoId",
                table: "SubareaConhecimento",
                column: "AreaConhecimentoId",
                principalTable: "AreaConhecimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
