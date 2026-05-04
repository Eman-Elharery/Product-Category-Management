using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace lab3.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothes" },
                    { 3, "Books" },
                    { 4, "Home Appliances" },
                    { 5, "Sports" },
                    { 6, "Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Count", "Description", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, 5, "Gaming Laptop", 15000m, "Laptop" },
                    { 2, 1, 10, "Android Smartphone", 9000m, "Smartphone" },
                    { 3, 1, 15, "Wireless Headphones", 1200m, "Headphones" },
                    { 4, 2, 20, "Cotton T-Shirt", 300m, "T-Shirt" },
                    { 5, 2, 12, "Blue Denim Jeans", 800m, "Jeans" },
                    { 6, 2, 7, "Winter Jacket", 1500m, "Jacket" },
                    { 7, 3, 25, "Learn C# Programming", 450m, "C# Book" },
                    { 8, 3, 18, "Master ASP.NET Core", 550m, "ASP.NET Core Book" },
                    { 9, 4, 6, "800W Microwave Oven", 3200m, "Microwave" },
                    { 10, 4, 4, "Double Door Fridge", 12000m, "Refrigerator" },
                    { 11, 5, 30, "Professional Football", 250m, "Football" },
                    { 12, 5, 9, "Carbon Fiber Racket", 1100m, "Tennis Racket" },
                    { 13, 6, 14, "Digital Wrist Watch", 600m, "Watch" },
                    { 14, 6, 16, "Laptop Backpack", 700m, "Backpack" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
