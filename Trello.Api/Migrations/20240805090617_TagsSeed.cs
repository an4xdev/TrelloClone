using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trello.Api.Migrations
{
    /// <inheritdoc />
    public partial class TagsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTags_Items_ItemId",
                table: "ItemTags");

            migrationBuilder.DropColumn(
                name: "TagsId",
                table: "ItemTags");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "ItemTags",
                newName: "ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTags_ItemId",
                table: "ItemTags",
                newName: "IX_ItemTags_ItemID");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "ID", "Color", "Name" },
                values: new object[,]
                {
                    { 1, "#FF5733", "High Priority" },
                    { 2, "#FFC300", "Medium Priority" },
                    { 3, "#DAF7A6", "Low Priority" },
                    { 4, "#33FF57", "Completed" },
                    { 5, "#33C1FF", "In Progress" },
                    { 6, "#8E44AD", "On Hold" },
                    { 7, "#FF33A6", "Review" },
                    { 8, "#2E4053", "New" },
                    { 9, "#7DCEA0", "Scheduled" },
                    { 10, "#F39C12", "Urgent" }
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

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTags_Items_ItemID",
                table: "ItemTags",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTags_Items_ItemID",
                table: "ItemTags");

            migrationBuilder.DeleteData(
                table: "ItemTags",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ItemTags",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ItemTags",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "ItemID",
                table: "ItemTags",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTags_ItemID",
                table: "ItemTags",
                newName: "IX_ItemTags_ItemId");

            migrationBuilder.AddColumn<int>(
                name: "TagsId",
                table: "ItemTags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTags_Items_ItemId",
                table: "ItemTags",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
