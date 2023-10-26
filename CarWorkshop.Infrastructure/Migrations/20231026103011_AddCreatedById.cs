using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWorkshop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedById : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "CarWorkshops",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarWorkshops_CreatedByID",
                table: "CarWorkshops",
                column: "CreatedByID");

            migrationBuilder.AddForeignKey(
                name: "FK_CarWorkshops_AspNetUsers_CreatedByID",
                table: "CarWorkshops",
                column: "CreatedByID",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarWorkshops_AspNetUsers_CreatedByID",
                table: "CarWorkshops");

            migrationBuilder.DropIndex(
                name: "IX_CarWorkshops_CreatedByID",
                table: "CarWorkshops");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "CarWorkshops");
        }
    }
}
