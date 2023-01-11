using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.EF.Migrations
{
    /// <inheritdoc />
    public partial class dataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
              table: "Books",
              columns: new[] { "Title", "Category", "Rate", "Price" },
              values: new object[,]
              {
                    { "The Great Gatsby", "Fiction", 4, 9.99m },
                    { "Moby-Dick", "Fiction", 5, 12.99m },
                    { "War and Peace", "Fiction", 3, 14.99m },
                    { "The Catcher in the Rye", "Fiction", 4, 8.99m },
                    { "Pride and Prejudice", "Fiction", 5, 11.99m },
                    { "To Kill a Mockingbird", "Fiction", 4, 10.99m },
                    { "The Odyssey", "Classics", 5, 15.99m },
                    { "The Iliad", "Classics", 4, 16.99m },
                    { "The Republic", "Classics", 3, 12.99m },
                    { "The Divine Comedy", "Classics", 4, 14.99m }
              });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Title",
                keyValues: new object[] { "The Great Gatsby", "Moby-Dick", "War and Peace", "The Catcher in the Rye", "Pride and Prejudice", "To Kill a Mockingbird", "The Odyssey", "The Iliad", "The Republic", "The Divine Comedy" });
        }
    }
}
