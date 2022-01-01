using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class ScheduleForAnime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountEpisodesForNow",
                table: "Animes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "Animes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScheduleAnimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayOfTheWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleAnimes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animes_ScheduleId",
                table: "Animes",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_ScheduleAnimes_ScheduleId",
                table: "Animes",
                column: "ScheduleId",
                principalTable: "ScheduleAnimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_ScheduleAnimes_ScheduleId",
                table: "Animes");

            migrationBuilder.DropTable(
                name: "ScheduleAnimes");

            migrationBuilder.DropIndex(
                name: "IX_Animes_ScheduleId",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "CountEpisodesForNow",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "Animes");
        }
    }
}
