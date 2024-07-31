using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trello.Api.Migrations
{
    /// <inheritdoc />
    public partial class ColumnMarkAsDoneItemDoneDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DoneDate",
                table: "Items",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "MarkAsDone",
                table: "Columns",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Columns",
                keyColumn: "ID",
                keyValue: 1,
                column: "MarkAsDone",
                value: false);

            migrationBuilder.UpdateData(
                table: "Columns",
                keyColumn: "ID",
                keyValue: 2,
                column: "MarkAsDone",
                value: false);

            migrationBuilder.UpdateData(
                table: "Columns",
                keyColumn: "ID",
                keyValue: 3,
                column: "MarkAsDone",
                value: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 1,
                column: "DoneDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 2,
                column: "DoneDate",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 3,
                column: "DoneDate",
                value: new DateOnly(2024, 7, 31));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoneDate",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MarkAsDone",
                table: "Columns");
        }
    }
}
