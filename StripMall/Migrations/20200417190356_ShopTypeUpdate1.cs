using Microsoft.EntityFrameworkCore.Migrations;

namespace StripMall.Migrations
{
    public partial class ShopTypeUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeName",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeName",
                table: "AspNetUsers");
        }
    }
}
