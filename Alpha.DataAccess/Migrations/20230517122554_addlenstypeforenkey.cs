using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alpha.DataAccess.Migrations
{
    public partial class addlenstypeforenkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LenstypeId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "LenstypeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "LenstypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "LenstypeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "LenstypeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "LenstypeId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_products_LenstypeId",
                table: "products",
                column: "LenstypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_lenstypes_LenstypeId",
                table: "products",
                column: "LenstypeId",
                principalTable: "lenstypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_lenstypes_LenstypeId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_LenstypeId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "LenstypeId",
                table: "products");
        }
    }
}
