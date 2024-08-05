using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trello.Api.Migrations
{
    /// <inheritdoc />
    public partial class TagsColorChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTag_Items_ItemId",
                table: "ItemTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTag_Tag_TagID",
                table: "ItemTag");

            migrationBuilder.DropForeignKey(
                name: "FK_Tag_TagColor_TagColorID",
                table: "Tag");

            migrationBuilder.DropTable(
                name: "TagColor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_TagColorID",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag");

            migrationBuilder.DropColumn(
                name: "TagColorID",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameTable(
                name: "ItemTag",
                newName: "ItemTags");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTag_TagID",
                table: "ItemTags",
                newName: "IX_ItemTags_TagID");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTag_ItemId",
                table: "ItemTags",
                newName: "IX_ItemTags_ItemId");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTags",
                table: "ItemTags",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 3,
                column: "DoneDate",
                value: new DateOnly(2024, 8, 5));

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTags_Items_ItemId",
                table: "ItemTags",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTags_Tags_TagID",
                table: "ItemTags",
                column: "TagID",
                principalTable: "Tags",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTags_Items_ItemId",
                table: "ItemTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTags_Tags_TagID",
                table: "ItemTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTags",
                table: "ItemTags");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameTable(
                name: "ItemTags",
                newName: "ItemTag");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTags_TagID",
                table: "ItemTag",
                newName: "IX_ItemTag_TagID");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTags_ItemId",
                table: "ItemTag",
                newName: "IX_ItemTag_ItemId");

            migrationBuilder.AddColumn<int>(
                name: "TagColorID",
                table: "Tag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTag",
                table: "ItemTag",
                column: "ID");

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

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "ID",
                keyValue: 3,
                column: "DoneDate",
                value: new DateOnly(2024, 8, 4));

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagColorID",
                table: "Tag",
                column: "TagColorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTag_Items_ItemId",
                table: "ItemTag",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTag_Tag_TagID",
                table: "ItemTag",
                column: "TagID",
                principalTable: "Tag",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_TagColor_TagColorID",
                table: "Tag",
                column: "TagColorID",
                principalTable: "TagColor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
