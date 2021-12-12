using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class ToGenreAddedListAnime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Animes_AnimeId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_AnimeId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "AnimeGenre",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeGenre", x => new { x.AnimesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_AnimeGenre_Animes_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeGenre_GenresId",
                table: "AnimeGenre",
                column: "GenresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeGenre");

            migrationBuilder.AddColumn<int>(
                name: "AnimeId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_AnimeId",
                table: "Genres",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Animes_AnimeId",
                table: "Genres",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
