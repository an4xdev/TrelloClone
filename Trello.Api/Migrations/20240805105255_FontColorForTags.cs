using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trello.Api.Migrations
{
    /// <inheritdoc />
    public partial class FontColorForTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Tags",
                newName: "FontColor");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "BackgroundColor", "FontColor" },
                values: new object[] { "#FF5733", "#FFFFFF" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "BackgroundColor", "FontColor" },
                values: new object[] { "#FFC300", "#000000" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "BackgroundColor", "FontColor" },
                values: new object[] { "#DAF7A6", "#000000" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "BackgroundColor", "FontColor" },
                values: new object[] { "#33FF57", "#000000" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "BackgroundColor", "FontColor" },
                values: new object[] { "#33C1FF", "#FFFFFF" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "BackgroundColor", "FontColor" },
                values: new object[] { "#8E44AD", "#FFFFFF" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 7,
                columns: new[] { "BackgroundColor", "FontColor" },
                values: new object[] { "#FF33A6", "#FFFFFF" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "BackgroundColor", "FontColor" },
                values: new object[] { "#2E4053", "#FFFFFF" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "BackgroundColor", "FontColor" },
                values: new object[] { "#7DCEA0", "#000000" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "BackgroundColor", "FontColor" },
                values: new object[] { "#F39C12", "#000000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "FontColor",
                table: "Tags",
                newName: "Color");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 1,
                column: "Color",
                value: "#FF5733");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 2,
                column: "Color",
                value: "#FFC300");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 3,
                column: "Color",
                value: "#DAF7A6");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 4,
                column: "Color",
                value: "#33FF57");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 5,
                column: "Color",
                value: "#33C1FF");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 6,
                column: "Color",
                value: "#8E44AD");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 7,
                column: "Color",
                value: "#FF33A6");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 8,
                column: "Color",
                value: "#2E4053");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 9,
                column: "Color",
                value: "#7DCEA0");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "ID",
                keyValue: 10,
                column: "Color",
                value: "#F39C12");
        }
    }
}
