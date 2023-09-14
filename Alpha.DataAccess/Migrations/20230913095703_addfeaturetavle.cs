using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpha.DataAccess.Migrations
{
    public partial class addfeaturetavle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_features", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "features",
                columns: new[] { "Id", "Description", "Icon", "Title" },
                values: new object[] { 1, "The best high-quality lenses are made from durable materials and use a series of treatments to help resist scratching and damage, while providing protection from UV rays. Prescription lenses are the best lenses for people who need one kind of vision correction that can be addressed with a single pair of lenses..", "<i class=\"far fa-heart fs-3\"></i>", " Quality" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "features");
        }
    }
}
