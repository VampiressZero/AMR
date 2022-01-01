using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class AnimeListProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_ListAnimes_ListAnimesId",
                table: "Animes");

            migrationBuilder.DropIndex(
                name: "IX_Animes_ListAnimesId",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "ListAnimesId",
                table: "Animes");

            migrationBuilder.CreateTable(
                name: "AnimeListAnimes",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "int", nullable: false),
                    ListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeListAnimes", x => new { x.AnimesId, x.ListId });
                    table.ForeignKey(
                        name: "FK_AnimeListAnimes_Animes_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeListAnimes_ListAnimes_ListId",
                        column: x => x.ListId,
                        principalTable: "ListAnimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeListAnimes_ListId",
                table: "AnimeListAnimes",
                column: "ListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeListAnimes");

            migrationBuilder.AddColumn<int>(
                name: "ListAnimesId",
                table: "Animes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animes_ListAnimesId",
                table: "Animes",
                column: "ListAnimesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_ListAnimes_ListAnimesId",
                table: "Animes",
                column: "ListAnimesId",
                principalTable: "ListAnimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
