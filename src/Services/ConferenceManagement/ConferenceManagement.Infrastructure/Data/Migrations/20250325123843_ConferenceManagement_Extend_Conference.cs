using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConferenceManagement_Extend_Conference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConferenceDetails_IsOnline",
                schema: "conferencemanagement",
                table: "Conferences",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ConferenceLinks_FacebookUrl",
                schema: "conferencemanagement",
                table: "Conferences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConferenceLinks_InstagramUrl",
                schema: "conferencemanagement",
                table: "Conferences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConferenceLinks_WebsiteUrl",
                schema: "conferencemanagement",
                table: "Conferences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                schema: "conferencemanagement",
                table: "Conferences",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConferenceDetails_IsOnline",
                schema: "conferencemanagement",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "ConferenceLinks_FacebookUrl",
                schema: "conferencemanagement",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "ConferenceLinks_InstagramUrl",
                schema: "conferencemanagement",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "ConferenceLinks_WebsiteUrl",
                schema: "conferencemanagement",
                table: "Conferences");

            migrationBuilder.DropColumn(
                name: "Language",
                schema: "conferencemanagement",
                table: "Conferences");
        }
    }
}
