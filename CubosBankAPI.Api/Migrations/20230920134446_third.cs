using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CubosBankAPI.Api.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_people_document",
                table: "people",
                column: "document",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_people_document",
                table: "people");
        }
    }
}
