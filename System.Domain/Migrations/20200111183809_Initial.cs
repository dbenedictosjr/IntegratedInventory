using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace System.Domain.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category1s",
                columns: table => new
                {
                    Cat1ID = table.Column<Guid>(nullable: false),
                    Cat1Code = table.Column<string>(type: "varchar(10)", nullable: true),
                    Cat1Desc = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cat1Img = table.Column<string>(type: "varchar(max)", nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category1s", x => x.Cat1ID);
                });

            migrationBuilder.CreateTable(
                name: "Category2s",
                columns: table => new
                {
                    Cat2ID = table.Column<Guid>(nullable: false),
                    Cat2Code = table.Column<string>(type: "varchar(10)", nullable: true),
                    Cat2Desc = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cat2Img = table.Column<string>(type: "varchar(max)", nullable: true),
                    Cat1ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category2s", x => x.Cat2ID);
                    table.ForeignKey(
                        name: "FK_Category2s_Category1s_Cat1ID",
                        column: x => x.Cat1ID,
                        principalTable: "Category1s",
                        principalColumn: "Cat1ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category3s",
                columns: table => new
                {
                    Cat3ID = table.Column<Guid>(nullable: false),
                    Cat3Code = table.Column<string>(type: "varchar(10)", nullable: true),
                    Cat3Desc = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cat3Img = table.Column<string>(type: "varchar(max)", nullable: true),
                    Cat2ID = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category3s", x => x.Cat3ID);
                    table.ForeignKey(
                        name: "FK_Category3s_Category2s_Cat2ID",
                        column: x => x.Cat2ID,
                        principalTable: "Category2s",
                        principalColumn: "Cat2ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProdID = table.Column<Guid>(nullable: false),
                    ProdCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    ShortDesc = table.Column<string>(type: "varchar(40)", nullable: true),
                    LongDesc = table.Column<string>(type: "varchar(100)", nullable: true),
                    Cat3ID = table.Column<Guid>(nullable: false),
                    Mintock = table.Column<double>(nullable: false),
                    MaxStock = table.Column<double>(nullable: false),
                    Cost = table.Column<double>(nullable: false),
                    MarkupAmount = table.Column<double>(nullable: false),
                    MarkupPercent = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Vatable = table.Column<bool>(nullable: true),
                    Barcode = table.Column<string>(type: "varchar(20)", nullable: true),
                    Stock = table.Column<double>(nullable: false),
                    Active = table.Column<bool>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProdID);
                    table.ForeignKey(
                        name: "FK_Products_Category3s_Cat3ID",
                        column: x => x.Cat3ID,
                        principalTable: "Category3s",
                        principalColumn: "Cat3ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category2s_Cat1ID",
                table: "Category2s",
                column: "Cat1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Category3s_Cat2ID",
                table: "Category3s",
                column: "Cat2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Cat3ID",
                table: "Products",
                column: "Cat3ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category3s");

            migrationBuilder.DropTable(
                name: "Category2s");

            migrationBuilder.DropTable(
                name: "Category1s");
        }
    }
}
