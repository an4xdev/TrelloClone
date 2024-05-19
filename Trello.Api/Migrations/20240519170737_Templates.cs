using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trello.Api.Migrations
{
    /// <inheritdoc />
    public partial class Templates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    TemplateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.TemplateID);
                });

            migrationBuilder.CreateTable(
                name: "Columns",
                columns: table => new
                {
                    ColumnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Columns", x => x.ColumnID);
                    table.ForeignKey(
                        name: "FK_Columns_Templates_TemplateID",
                        column: x => x.TemplateID,
                        principalTable: "Templates",
                        principalColumn: "TemplateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Columns_TemplateID",
                table: "Columns",
                column: "TemplateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Columns");

            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
