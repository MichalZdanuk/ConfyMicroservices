using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConferenceManagement_Change_ConferenceLanguage_ToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Language",
                schema: "conferencemanagement",
                table: "Conferences",
                newName: "ConferenceLanguage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConferenceLanguage",
                schema: "conferencemanagement",
                table: "Conferences",
                newName: "Language");
        }
    }
}
