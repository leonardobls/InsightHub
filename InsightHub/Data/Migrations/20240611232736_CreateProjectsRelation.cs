using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsightHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateProjectsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubareaKey",
                table: "Projeto",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubareaKey",
                table: "Projeto");
        }
    }
}
