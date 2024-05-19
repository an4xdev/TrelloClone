using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trello.Api.Migrations
{
    /// <inheritdoc />
    public partial class ColumnTemplatesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "ColumnTemplates",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ColumnTemplates",
                table: "ColumnTemplates",
                column: "ID");

            migrationBuilder.InsertData(
                table: "ColumnTemplates",
                columns: new[] { "ID", "CID", "TID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "ColumnID", "Name" },
                values: new object[,]
                {
                    { 1, "TODO" },
                    { 2, "In progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "TemplateID", "Name" },
                values: new object[] { 1, "Default" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ColumnTemplates",
                table: "ColumnTemplates");

            migrationBuilder.DeleteData(
                table: "ColumnTemplates",
                keyColumn: "ID",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ColumnTemplates",
                keyColumn: "ID",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ColumnTemplates",
                keyColumn: "ID",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Columns",
                keyColumn: "ColumnID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Columns",
                keyColumn: "ColumnID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Columns",
                keyColumn: "ColumnID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Templates",
                keyColumn: "TemplateID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ID",
                table: "ColumnTemplates");
        }
    }
}
