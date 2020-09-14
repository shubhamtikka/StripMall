using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StripMall.Migrations
{
    public partial class ShopTypeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TLToken",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopType",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShopType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ShopType",
                table: "AspNetUsers",
                column: "ShopType");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShopType_ShopType",
                table: "AspNetUsers",
                column: "ShopType",
                principalTable: "ShopType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShopType_ShopType",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ShopType");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ShopType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ShopType",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "TLToken",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
