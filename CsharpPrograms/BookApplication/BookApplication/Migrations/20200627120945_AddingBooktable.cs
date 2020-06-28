using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookApplication.Migrations
{
    public partial class AddingBooktable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    BookId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    BookName = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false),
                    CoverPhoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
