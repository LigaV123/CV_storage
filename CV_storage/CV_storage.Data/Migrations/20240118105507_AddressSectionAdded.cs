using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_storage.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddressSectionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    Region = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    StreetAddress = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    House = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Address_CurriculumVitaeId",
                table: "Address",
                column: "CurriculumVitaeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
