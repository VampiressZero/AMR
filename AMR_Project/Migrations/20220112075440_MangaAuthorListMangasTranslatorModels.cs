using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class MangaAuthorListMangasTranslatorModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MangaId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MangaId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListMangas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListMangas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListMangas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MangaAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MangaTranslators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MangaTranslators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mangas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JapanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NextChapterTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ChapterCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusOfTranslate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AgeRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    RatingPeopleCount = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    Painter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mangas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mangas_MangaAuthors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "MangaAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mangas_MangaTranslators_TranslatorId",
                        column: x => x.TranslatorId,
                        principalTable: "MangaTranslators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListMangasManga",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false),
                    MangasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListMangasManga", x => new { x.ListId, x.MangasId });
                    table.ForeignKey(
                        name: "FK_ListMangasManga_ListMangas_ListId",
                        column: x => x.ListId,
                        principalTable: "ListMangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListMangasManga_Mangas_MangasId",
                        column: x => x.MangasId,
                        principalTable: "Mangas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_MangaId",
                table: "Tags",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MangaId",
                table: "Genres",
                column: "MangaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListMangas_UserId",
                table: "ListMangas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ListMangasManga_MangasId",
                table: "ListMangasManga",
                column: "MangasId");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_AuthorId",
                table: "Mangas",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mangas_TranslatorId",
                table: "Mangas",
                column: "TranslatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Mangas_MangaId",
                table: "Genres",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Mangas_MangaId",
                table: "Tags",
                column: "MangaId",
                principalTable: "Mangas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Mangas_MangaId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Mangas_MangaId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "ListMangasManga");

            migrationBuilder.DropTable(
                name: "ListMangas");

            migrationBuilder.DropTable(
                name: "Mangas");

            migrationBuilder.DropTable(
                name: "MangaAuthors");

            migrationBuilder.DropTable(
                name: "MangaTranslators");

            migrationBuilder.DropIndex(
                name: "IX_Tags_MangaId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Genres_MangaId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "MangaId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "MangaId",
                table: "Genres");
        }
    }
}
