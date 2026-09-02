using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Book_Management.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    PublishedYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Category", "Price", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "Fiction", 10.99, 1925, "The Great Gatsby" },
                    { 2, "Harper Lee", "Fiction", 12.99, 1960, "To Kill a Mockingbird" },
                    { 3, "George Orwell", "Dystopian", 9.9900000000000002, 1949, "1984" },
                    { 4, "Stephen Hawking", "Science", 15.49, 1988, "A Brief History of Time" },
                    { 5, "Yuval Noah Harari", "History", 18.0, 2011, "Sapiens" },
                    { 6, "J.R.R. Tolkien", "Fantasy", 14.949999999999999, 1937, "The Hobbit" },
                    { 7, "Daniel Kahneman", "Psychology", 16.989999999999998, 2011, "Thinking, Fast and Slow" },
                    { 8, "Robert C. Martin", "Computers", 39.990000000000002, 2008, "Clean Code" },
                    { 9, "Paulo Coelho", "Fiction", 11.5, 1988, "The Alchemist" },
                    { 10, "Tara Westover", "Biography", 13.199999999999999, 2018, "Educated" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
