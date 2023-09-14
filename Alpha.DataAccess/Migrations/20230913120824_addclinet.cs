using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpha.DataAccess.Migrations
{
    public partial class addclinet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ourClients",
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
                    table.PrimaryKey("PK_ourClients", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ourClients",
                columns: new[] { "Id", "Description", "Image", "Title" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet consectetur adipisicing elit. Veritatis libero reprehenderit, enim iure debitis doloremque nulla perspiciatis natus impedit obcaecati molestias sunt voluptate sed ipsa?", " ", " Clients are happy to do business with us" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ourClients");
        }
    }
}
