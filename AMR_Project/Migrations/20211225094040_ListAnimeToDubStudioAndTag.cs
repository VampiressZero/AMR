using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class ListAnimeToDubStudioAndTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DubStudios_Animes_AnimeId",
                table: "DubStudios");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Animes_AnimeId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_AnimeId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_DubStudios_AnimeId",
                table: "DubStudios");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "DubStudios");

            migrationBuilder.CreateTable(
                name: "AnimeDubStudio",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "int", nullable: false),
                    DubStudiosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeDubStudio", x => new { x.AnimesId, x.DubStudiosId });
                    table.ForeignKey(
                        name: "FK_AnimeDubStudio_Animes_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeDubStudio_DubStudios_DubStudiosId",
                        column: x => x.DubStudiosId,
                        principalTable: "DubStudios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimeTag",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeTag", x => new { x.AnimesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_AnimeTag_Animes_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeDubStudio_DubStudiosId",
                table: "AnimeDubStudio",
                column: "DubStudiosId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeTag_TagsId",
                table: "AnimeTag",
                column: "TagsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeDubStudio");

            migrationBuilder.DropTable(
                name: "AnimeTag");

            migrationBuilder.AddColumn<int>(
                name: "AnimeId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnimeId",
                table: "DubStudios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tags_AnimeId",
                table: "Tags",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_DubStudios_AnimeId",
                table: "DubStudios",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DubStudios_Animes_AnimeId",
                table: "DubStudios",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Animes_AnimeId",
                table: "Tags",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
