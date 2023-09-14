using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpha.DataAccess.Migrations
{
    public partial class addotherfeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "otherFeatures",
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
                    table.PrimaryKey("PK_otherFeatures", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "otherFeatures",
                columns: new[] { "Id", "Description", "Icon", "Title" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Asperiores voluptatum ab a inventore neque. Tempora?..", "<i class=\"fa fa-dot-circle fs-2\"></i>", " It adapts to your needs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "otherFeatures");
        }
    }
}
