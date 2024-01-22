using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_storage.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdditionalInfoSectionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AboutYou = table.Column<string>(type: "TEXT", maxLength: 1875, nullable: true),
                    MessageToHiringManager = table.Column<string>(type: "TEXT", maxLength: 1875, nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInformation_CurriculumVitaeId",
                table: "AdditionalInformation",
                column: "CurriculumVitaeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalInformation");
        }
    }
}
