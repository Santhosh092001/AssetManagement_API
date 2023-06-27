using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManagement.Migrations
{
    public partial class AddDocumentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedBy",
                table: "UserAssetMaps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedOn",
                table: "UserAssetMaps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "UserAssetMaps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filesize = table.Column<long>(type: "bigint", nullable: false),
                    Filetype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Filecontent = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserAssetMaps_DocumentId",
                table: "UserAssetMaps",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAssetMaps_Documents_DocumentId",
                table: "UserAssetMaps",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAssetMaps_Documents_DocumentId",
                table: "UserAssetMaps");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_UserAssetMaps_DocumentId",
                table: "UserAssetMaps");

            migrationBuilder.DropColumn(
                name: "AssignedBy",
                table: "UserAssetMaps");

            migrationBuilder.DropColumn(
                name: "AssignedOn",
                table: "UserAssetMaps");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "UserAssetMaps");
        }
    }
}
