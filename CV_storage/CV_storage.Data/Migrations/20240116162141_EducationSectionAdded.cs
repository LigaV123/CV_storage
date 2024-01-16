using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_storage.Data.Migrations
{
    /// <inheritdoc />
    public partial class EducationSectionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EducationalEstablishment = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Faculty = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Department = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    EducationForm = table.Column<int>(type: "INTEGER", nullable: false),
                    Degree = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    EducationStartDate = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    EducationEndDate = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    CurriculumVitaeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_CurriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_CurriculumVitaeId",
                table: "Education",
                column: "CurriculumVitaeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");
        }
    }
}
