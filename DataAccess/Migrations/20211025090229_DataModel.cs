using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class DataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    Alt = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPhotos_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPhotos_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypePropertySets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MediaTypeId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypePropertySets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypePropertySets_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypePropertySets_Types_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPhotoPropertySets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemPhotoId = table.Column<int>(type: "int", nullable: false),
                    PropertyId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPhotoPropertySets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPhotoPropertySets_ItemPhotos_ItemPhotoId",
                        column: x => x.ItemPhotoId,
                        principalTable: "ItemPhotos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPhotoPropertySets_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Engagment ring" },
                    { 2, "Wedding ring" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Metal" },
                    { 2, "Shape" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Photo" },
                    { 2, "Thumb" }
                });

            migrationBuilder.InsertData(
                table: "ItemPhotos",
                columns: new[] { "Id", "Alt", "CreatedAt", "FileName", "IsActive", "ItemId", "ModifiedAt", "Position", "TypeId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2021, 10, 25, 10, 2, 29, 13, DateTimeKind.Local).AddTicks(1170), "Photo1.jpg", true, 1, null, 1, 1 },
                    { 2, null, new DateTime(2021, 10, 25, 10, 2, 29, 16, DateTimeKind.Local).AddTicks(2625), "Photo2.jpg", true, 1, null, 2, 1 },
                    { 3, null, new DateTime(2021, 10, 25, 10, 2, 29, 16, DateTimeKind.Local).AddTicks(2667), "Thumb1.jpg", true, 1, null, 1, 2 },
                    { 4, null, new DateTime(2021, 10, 25, 10, 2, 29, 16, DateTimeKind.Local).AddTicks(2673), "Thumb2.jpg", true, 1, null, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "TypePropertySets",
                columns: new[] { "Id", "MediaTypeId", "PropertyId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 },
                    { 4, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ItemPhotoPropertySets",
                columns: new[] { "Id", "ItemPhotoId", "PropertyId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, "Yellow Gold" },
                    { 2, 1, 2, "Round" },
                    { 3, 2, 1, "Yellow Gold" },
                    { 4, 2, 2, "Cushion" },
                    { 5, 3, 1, "Rose Gold" },
                    { 6, 3, 2, "Round" },
                    { 7, 4, 1, "Rose Gold" },
                    { 8, 4, 2, "Cushion" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemPhotoPropertySets_ItemPhotoId",
                table: "ItemPhotoPropertySets",
                column: "ItemPhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPhotoPropertySets_PropertyId",
                table: "ItemPhotoPropertySets",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPhotos_ItemId",
                table: "ItemPhotos",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPhotos_TypeId",
                table: "ItemPhotos",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypePropertySets_MediaTypeId",
                table: "TypePropertySets",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TypePropertySets_PropertyId",
                table: "TypePropertySets",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPhotoPropertySets");

            migrationBuilder.DropTable(
                name: "TypePropertySets");

            migrationBuilder.DropTable(
                name: "ItemPhotos");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
