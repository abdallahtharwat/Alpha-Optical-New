using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpha.DataAccess.Migrations
{
    public partial class adddetailssection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "detailsSections",
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
                    table.PrimaryKey("PK_detailsSections", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "detailsSections",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[] { 1, "We worked long and hard to create the glasses of our dreams, but before launching, we decided to test it out on two crowdfunding platforms: Kickstarter and Indiegogo.!", " ", " Our product will amaze you" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detailsSections");
        }
    }
}
