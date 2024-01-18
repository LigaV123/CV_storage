using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_storage.Data.Migrations
{
    /// <inheritdoc />
    public partial class JobExperianceAndSkillsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EducationForm",
                table: "Education",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateTable(
                name: "GainedSkill",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Skill = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    SkillType = table.Column<int>(type: "INTEGER", nullable: false),
                    SkillDescription = table.Column<string>(type: "TEXT", maxLength: 1875, nullable: true),
                    CurriculumVitaeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GainedSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GainedSkill_CurriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobExperience",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Position = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Workload = table.Column<int>(type: "INTEGER", nullable: false),
                    JobDescription = table.Column<string>(type: "TEXT", maxLength: 1875, nullable: true),
                    EmploymentStartDate = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    EmploymentEndDate = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    CurriculumVitaeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobExperience_CurriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GainedSkill_CurriculumVitaeId",
                table: "GainedSkill",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobExperience_CurriculumVitaeId",
                table: "JobExperience",
                column: "CurriculumVitaeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GainedSkill");

            migrationBuilder.DropTable(
                name: "JobExperience");

            migrationBuilder.AlterColumn<int>(
                name: "EducationForm",
                table: "Education",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);
        }
    }
}
