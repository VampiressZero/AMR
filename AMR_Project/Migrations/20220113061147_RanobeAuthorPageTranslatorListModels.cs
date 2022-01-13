using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class RanobeAuthorPageTranslatorListModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RanobeId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RanobeId",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ListRanobes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListRanobes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RanobeAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RanobeAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RanobeTranslators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RanobeTranslators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranobes",
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
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TranslatorId = table.Column<int>(type: "int", nullable: true),
                    RanobeAuthorId = table.Column<int>(type: "int", nullable: true),
                    RanobeTranslatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranobes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranobes_MangaAuthors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "MangaAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ranobes_MangaTranslators_TranslatorId",
                        column: x => x.TranslatorId,
                        principalTable: "MangaTranslators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ranobes_RanobeAuthors_RanobeAuthorId",
                        column: x => x.RanobeAuthorId,
                        principalTable: "RanobeAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ranobes_RanobeTranslators_RanobeTranslatorId",
                        column: x => x.RanobeTranslatorId,
                        principalTable: "RanobeTranslators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListRanobesRanobe",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false),
                    RanobesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListRanobesRanobe", x => new { x.ListId, x.RanobesId });
                    table.ForeignKey(
                        name: "FK_ListRanobesRanobe_ListRanobes_ListId",
                        column: x => x.ListId,
                        principalTable: "ListRanobes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListRanobesRanobe_Ranobes_RanobesId",
                        column: x => x.RanobesId,
                        principalTable: "Ranobes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RanobePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RanobeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RanobePages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RanobePages_Ranobes_RanobeId",
                        column: x => x.RanobeId,
                        principalTable: "Ranobes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_RanobeId",
                table: "Tags",
                column: "RanobeId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_RanobeId",
                table: "Genres",
                column: "RanobeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListRanobesRanobe_RanobesId",
                table: "ListRanobesRanobe",
                column: "RanobesId");

            migrationBuilder.CreateIndex(
                name: "IX_RanobePages_RanobeId",
                table: "RanobePages",
                column: "RanobeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranobes_AuthorId",
                table: "Ranobes",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranobes_RanobeAuthorId",
                table: "Ranobes",
                column: "RanobeAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranobes_RanobeTranslatorId",
                table: "Ranobes",
                column: "RanobeTranslatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranobes_TranslatorId",
                table: "Ranobes",
                column: "TranslatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Ranobes_RanobeId",
                table: "Genres",
                column: "RanobeId",
                principalTable: "Ranobes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Ranobes_RanobeId",
                table: "Tags",
                column: "RanobeId",
                principalTable: "Ranobes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Ranobes_RanobeId",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Ranobes_RanobeId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "ListRanobesRanobe");

            migrationBuilder.DropTable(
                name: "RanobePages");

            migrationBuilder.DropTable(
                name: "ListRanobes");

            migrationBuilder.DropTable(
                name: "Ranobes");

            migrationBuilder.DropTable(
                name: "RanobeAuthors");

            migrationBuilder.DropTable(
                name: "RanobeTranslators");

            migrationBuilder.DropIndex(
                name: "IX_Tags_RanobeId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Genres_RanobeId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "RanobeId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "RanobeId",
                table: "Genres");
        }
    }
}
