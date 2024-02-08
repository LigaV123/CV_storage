using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_storage.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurriculumVitae",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurriculumVitae", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AboutYou = table.Column<string>(type: "TEXT", maxLength: 1875, nullable: true),
                    HobbiesAndInterests = table.Column<string>(type: "TEXT", maxLength: 1875, nullable: true),
                    CurriculumVitaeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalInformation_CurriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    Region = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    StreetAddress = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    CurriculumVitaeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_CurriculumVitae_CurriculumVitaeId",
                        column: x => x.CurriculumVitaeId,
                        principalTable: "CurriculumVitae",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EducationalEstablishment = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Faculty = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Department = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    EducationForm = table.Column<int>(type: "INTEGER", nullable: true),
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
                    Workload = table.Column<int>(type: "INTEGER", nullable: true),
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
                name: "IX_AdditionalInformation_CurriculumVitaeId",
                table: "AdditionalInformation",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CurriculumVitaeId",
                table: "Address",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_CurriculumVitaeId",
                table: "Education",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_GainedSkill_CurriculumVitaeId",
                table: "GainedSkill",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobExperience_CurriculumVitaeId",
                table: "JobExperience",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageKnowledge_CurriculumVitaeId",
                table: "LanguageKnowledge",
                column: "CurriculumVitaeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalInformation");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "GainedSkill");

            migrationBuilder.DropTable(
                name: "JobExperience");

            migrationBuilder.DropTable(
                name: "LanguageKnowledge");

            migrationBuilder.DropTable(
                name: "CurriculumVitae");
        }
    }
}
