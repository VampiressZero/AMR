using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class ScheduleAnimeFinished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfTheWeek",
                table: "ScheduleAnimes");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "ScheduleAnimes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DayOfTheWeek",
                table: "ScheduleAnimes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "ScheduleAnimes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
