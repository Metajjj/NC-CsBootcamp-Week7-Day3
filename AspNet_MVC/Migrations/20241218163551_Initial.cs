using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspNet_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    authorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTable_AuthorTable_authorId",
                        column: x => x.authorId,
                        principalTable: "AuthorTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuthorTable",
                columns: new[] { "Id", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1, "George Orwell", "British" },
                    { 2, "Confucius", "Chinese" },
                    { 3, "Evie Pom", "German" },
                    { 4, "Leo Tolstoy", "Russian" },
                    { 5, "Jane Austen", "British" },
                    { 6, "Gabriel Garcia Marquez", "Colombian" },
                    { 7, "Homer", "Ancient Greek" },
                    { 8, "Mark Twain", "American" },
                    { 9, "Virginia Woolf", "British" },
                    { 10, "Haruki Murakami", "Japanese" },
                    { 11, "Name1", "N" }
                });

            migrationBuilder.InsertData(
                table: "BookTable",
                columns: new[] { "Id", "Author", "Title", "Year", "authorId" },
                values: new object[,]
                {
                    { 1, "Confucius", "The Analects", -475, 2 },
                    { 2, "Evie Pom", "Evie�s Adventure", 2024, 3 },
                    { 3, "Leo Tolstoy", "War and Peace", 1869, 4 },
                    { 4, "Jane Austen", "Pride and Prejudice", 1813, 5 },
                    { 5, "Gabriel Garcia Marquez", "One Hundred Years of Solitude", 1967, 6 },
                    { 6, "Homer", "The Odyssey", -800, 7 },
                    { 7, "Mark Twain", "The Adventures of Tom Sawyer", 1876, 8 },
                    { 8, "Virginia Woolf", "Mrs Dalloway", 1925, 9 },
                    { 9, "Haruki Murakami", "Norwegian Wood", 1987, 10 },
                    { 11, "Confucius", "NUL", 0, 2 },
                    { 12, "George Orwell", "1984", 1949, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTable_authorId",
                table: "BookTable",
                column: "authorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTable");

            migrationBuilder.DropTable(
                name: "AuthorTable");
        }
    }
}
