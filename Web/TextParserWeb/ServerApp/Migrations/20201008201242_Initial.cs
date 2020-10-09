using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginPath = table.Column<string>(nullable: true),
                    Filename = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    ImportDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                });

            migrationBuilder.CreateTable(
                name: "Fragments",
                columns: table => new
                {
                    FragmentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowIndex = table.Column<int>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    DestPath = table.Column<string>(nullable: true),
                    Filename = table.Column<string>(nullable: true),
                    DocumentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fragments", x => x.FragmentId);
                    table.ForeignKey(
                        name: "FK_Fragments_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fragments_DocumentId",
                table: "Fragments",
                column: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fragments");

            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
