using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpha.DataAccess.Migrations
{
    public partial class addaboutus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AboutUs",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[] { 1, "Based in Barcelona, Barner was founded in early 2017 by two friends. After living their lives totally immersed in the digital world, they had identified a problem that was not only affecting them, but millions of people all around the globe: overexposure to blue light. As hard workers and technology lovers, their eyes couldn’t withstand the long hours spent every day in front of screens. They wanted to find a solution that would protect their eyes and improve their quality of life without sacrificing their style. After realizing that current solutions on the market weren’t good enough, they decided to create their own. !", " ", " About as" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");
        }
    }
}
