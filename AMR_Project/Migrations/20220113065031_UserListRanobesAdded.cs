using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class UserListRanobesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ListRanobes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListRanobes_UserId",
                table: "ListRanobes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListRanobes_AspNetUsers_UserId",
                table: "ListRanobes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListRanobes_AspNetUsers_UserId",
                table: "ListRanobes");

            migrationBuilder.DropIndex(
                name: "IX_ListRanobes_UserId",
                table: "ListRanobes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ListRanobes");
        }
    }
}
