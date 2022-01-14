using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class MangaChapterModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MangaChapterId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MangaChapters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tome = table.Column<int>(type: "int", nullable: false),
                    Chapter = table.Column<int>(type: "int", nullable: false),
                    MangaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaChapters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MangaChapters_Mangas_MangaId",
                        column: x => x.MangaId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_MangaChapterId",
                table: "Images",
                column: "MangaChapterId");

            migrationBuilder.CreateIndex(
                name: "IX_MangaChapters_MangaId",
                table: "MangaChapters",
                column: "MangaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_MangaChapters_MangaChapterId",
                table: "Images",
                column: "MangaChapterId",
                principalTable: "MangaChapters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_MangaChapters_MangaChapterId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "MangaChapters");

            migrationBuilder.DropIndex(
                name: "IX_Images_MangaChapterId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "MangaChapterId",
                table: "Images");
        }
    }
}
