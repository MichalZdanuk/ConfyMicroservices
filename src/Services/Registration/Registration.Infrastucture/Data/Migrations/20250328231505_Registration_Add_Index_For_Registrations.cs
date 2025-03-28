using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registration.Infrastucture.Data.Migrations
{
    /// <inheritdoc />
    public partial class Registration_Add_Index_For_Registrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registrations_UserId",
                schema: "registration",
                table: "Registrations");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_UserId_ConferenceId",
                schema: "registration",
                table: "Registrations",
                columns: new[] { "UserId", "ConferenceId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Registrations_UserId_ConferenceId",
                schema: "registration",
                table: "Registrations");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_UserId",
                schema: "registration",
                table: "Registrations",
                column: "UserId");
        }
    }
}
