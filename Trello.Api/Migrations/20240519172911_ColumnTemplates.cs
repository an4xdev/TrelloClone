using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trello.Api.Migrations
{
    /// <inheritdoc />
    public partial class ColumnTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Columns_Templates_TemplateID",
                table: "Columns");

            migrationBuilder.DropIndex(
                name: "IX_Columns_TemplateID",
                table: "Columns");

            migrationBuilder.DropColumn(
                name: "TemplateID",
                table: "Columns");

            migrationBuilder.CreateTable(
                name: "ColumnTemplates",
                columns: table => new
                {
                    TID = table.Column<int>(type: "int", nullable: false),
                    CID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColumnTemplates");

            migrationBuilder.AddColumn<int>(
                name: "TemplateID",
                table: "Columns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Columns_TemplateID",
                table: "Columns",
                column: "TemplateID");

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_Templates_TemplateID",
                table: "Columns",
                column: "TemplateID",
                principalTable: "Templates",
                principalColumn: "TemplateID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
