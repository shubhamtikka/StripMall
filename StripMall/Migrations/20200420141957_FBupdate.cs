using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StripMall.Migrations
{
    public partial class FBupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ShopType_ShopType",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopType",
                table: "ShopType");

            migrationBuilder.RenameTable(
                name: "ShopType",
                newName: "shopTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shopTypes",
                table: "shopTypes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<string>(nullable: true),
                    FeedBackText = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_shopTypes_ShopType",
                table: "AspNetUsers",
                column: "ShopType",
                principalTable: "shopTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_shopTypes_ShopType",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shopTypes",
                table: "shopTypes");

            migrationBuilder.RenameTable(
                name: "shopTypes",
                newName: "ShopType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopType",
                table: "ShopType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ShopType_ShopType",
                table: "AspNetUsers",
                column: "ShopType",
                principalTable: "ShopType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
