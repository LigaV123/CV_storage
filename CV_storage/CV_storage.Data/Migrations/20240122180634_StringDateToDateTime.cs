using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_storage.Data.Migrations
{
    /// <inheritdoc />
    public partial class StringDateToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_CurriculumVitaeId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInformation_CurriculumVitaeId",
                table: "AdditionalInformation");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageLevel",
                table: "LanguageKnowledge",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Education",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Degree",
                table: "Education",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CurriculumVitaeId",
                table: "Address",
                column: "CurriculumVitaeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInformation_CurriculumVitaeId",
                table: "AdditionalInformation",
                column: "CurriculumVitaeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_CurriculumVitaeId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInformation_CurriculumVitaeId",
                table: "AdditionalInformation");

            migrationBuilder.AlterColumn<int>(
                name: "LanguageLevel",
                table: "LanguageKnowledge",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Education",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Degree",
                table: "Education",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_CurriculumVitaeId",
                table: "Address",
                column: "CurriculumVitaeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInformation_CurriculumVitaeId",
                table: "AdditionalInformation",
                column: "CurriculumVitaeId",
                unique: true);
        }
    }
}
