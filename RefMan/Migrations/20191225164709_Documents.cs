using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RefMan.Migrations
{
    public partial class Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DocumentId",
                table: "Files",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccessDate = table.Column<DateTime>(nullable: false),
                    PublishYear = table.Column<int>(nullable: true),
                    WebsiteName = table.Column<string>(nullable: true),
                    WebpageTitle = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    IconUrl = table.Column<string>(nullable: true),
                    DocumentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.Id);
                    table.ForeignKey(
                        name: "FK_References_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_DocumentId",
                table: "Files",
                column: "DocumentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_References_DocumentId",
                table: "References",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Documents_DocumentId",
                table: "Files",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Documents_DocumentId",
                table: "Files");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Files_DocumentId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Files");
        }
    }
}
