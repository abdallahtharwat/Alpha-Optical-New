using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpha.DataAccess.Migrations
{
    public partial class seedproducttoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price5 = table.Column<double>(type: "float", nullable: false),
                    Price10 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Color", "Description", "ISBN", "ListPrice", "Price", "Price10", "Price5", "Title" },
                values: new object[,]
                {
                    { 1, "Black", "\r\nFashion TR90 Square Computer Glasses Anti-blue Ray Eyewear Frame-5025-ShiningBlac ", "SWD9999001", 2250.0, 1970.0, 1420.0, 1630.0, "Dalston" },
                    { 2, "Black Noir", "\r\nFashion TR90 Square Computer Glasses Anti-blue Ray Eyewear Frame-5025-ShiningBlac ", "CAW777777701", 1920.0, 1830.0, 1350.0, 1660.0, "Dalston Sun" },
                    { 3, "Dark Green", "\r\nFashion TR90 Square Computer Glasses Anti-blue Ray Eyewear Frame-5025-ShiningBlac ", "RITO5555501", 750.0, 690.0, 440.0, 510.0, "Le Marais Sun" },
                    { 4, "Navy Blue", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "WS3333333301", 970.0, 830.0, 580.0, 700.0, "Osterbro" },
                    { 5, "Silver Matte", "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ", "SOTJ1111111101", 300.0, 270.0, 120.0, 175.0, "Ginza Sun" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
