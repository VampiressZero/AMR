using Microsoft.EntityFrameworkCore.Migrations;

namespace AMR_Project.Migrations
{
    public partial class RanobeFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranobes_MangaAuthors_AuthorId",
                table: "Ranobes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranobes_MangaTranslators_TranslatorId",
                table: "Ranobes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranobes_RanobeAuthors_RanobeAuthorId",
                table: "Ranobes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranobes_RanobeTranslators_RanobeTranslatorId",
                table: "Ranobes");

            migrationBuilder.DropIndex(
                name: "IX_Ranobes_RanobeAuthorId",
                table: "Ranobes");

            migrationBuilder.DropIndex(
                name: "IX_Ranobes_RanobeTranslatorId",
                table: "Ranobes");

            migrationBuilder.DropColumn(
                name: "RanobeAuthorId",
                table: "Ranobes");

            migrationBuilder.DropColumn(
                name: "RanobeTranslatorId",
                table: "Ranobes");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranobes_RanobeAuthors_AuthorId",
                table: "Ranobes",
                column: "AuthorId",
                principalTable: "RanobeAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranobes_RanobeTranslators_TranslatorId",
                table: "Ranobes",
                column: "TranslatorId",
                principalTable: "RanobeTranslators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ranobes_RanobeAuthors_AuthorId",
                table: "Ranobes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ranobes_RanobeTranslators_TranslatorId",
                table: "Ranobes");

            migrationBuilder.AddColumn<int>(
                name: "RanobeAuthorId",
                table: "Ranobes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RanobeTranslatorId",
                table: "Ranobes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ranobes_RanobeAuthorId",
                table: "Ranobes",
                column: "RanobeAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranobes_RanobeTranslatorId",
                table: "Ranobes",
                column: "RanobeTranslatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ranobes_MangaAuthors_AuthorId",
                table: "Ranobes",
                column: "AuthorId",
                principalTable: "MangaAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranobes_MangaTranslators_TranslatorId",
                table: "Ranobes",
                column: "TranslatorId",
                principalTable: "MangaTranslators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranobes_RanobeAuthors_RanobeAuthorId",
                table: "Ranobes",
                column: "RanobeAuthorId",
                principalTable: "RanobeAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ranobes_RanobeTranslators_RanobeTranslatorId",
                table: "Ranobes",
                column: "RanobeTranslatorId",
                principalTable: "RanobeTranslators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
