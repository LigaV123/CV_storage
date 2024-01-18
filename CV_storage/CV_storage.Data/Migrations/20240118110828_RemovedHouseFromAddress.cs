using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CV_storage.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedHouseFromAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "House",
                table: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "House",
                table: "Address",
                type: "TEXT",
                maxLength: 1024,
                nullable: true);
        }
    }
}
