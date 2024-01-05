using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_storage.Data.Migrations
{
    /// <inheritdoc />
    public partial class LanguageSectionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageKnowledge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Language = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    LanguageLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    CurriculumVitaeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageKnowledge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageKnowledge_CurriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageKnowledge_CurriculumVitaeId",
                table: "LanguageKnowledge",
                column: "CurriculumVitaeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageKnowledge");
        }
    }
}
