using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trello.Api.Migrations
{
    /// <inheritdoc />
    public partial class TagColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagColorID",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TagColor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagColor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagColorID",
                table: "Tag",
                column: "TagColorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_TagColor_TagColorID",
                table: "Tag",
                column: "TagColorID",
                principalTable: "TagColor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_TagColor_TagColorID",
                table: "Tag");

            migrationBuilder.DropTable(
                name: "TagColor");

            migrationBuilder.DropIndex(
                name: "IX_Tag_TagColorID",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "TagColorID",
                table: "Tag");
        }
    }
}
