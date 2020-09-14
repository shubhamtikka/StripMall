using Microsoft.EntityFrameworkCore.Migrations;

namespace StripMall.Migrations
{
    public partial class updateFB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FeedBackText",
                table: "Feedbacks",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FeedBackText",
                table: "Feedbacks",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
