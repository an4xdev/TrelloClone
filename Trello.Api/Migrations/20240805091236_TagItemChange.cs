using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trello.Api.Migrations
{
    /// <inheritdoc />
    public partial class TagItemChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTags");

            migrationBuilder.AddColumn<int>(
                name: "TagID",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 1,
                column: "TagID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 2,
                column: "TagID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 3,
                column: "TagID",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Items_TagID",
                table: "Items",
                column: "TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Tags_TagID",
                table: "Items",
                column: "TagID",
                principalTable: "Tags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Tags_TagID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TagID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TagID",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "ItemTags",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTags", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemTags_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTags_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ItemTags",
                columns: new[] { "ID", "ItemID", "TagID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 5 },
                    { 3, 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTags_ItemID",
                table: "ItemTags",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTags_TagID",
                table: "ItemTags",
                column: "TagID");
        }
    }
}
