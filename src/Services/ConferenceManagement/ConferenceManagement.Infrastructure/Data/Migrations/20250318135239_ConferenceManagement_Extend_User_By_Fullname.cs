using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConferenceManagement_Extend_User_By_Fullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName_FirstName",
                schema: "conferencemanagement",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName_LastName",
                schema: "conferencemanagement",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName_FirstName",
                schema: "conferencemanagement",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName_LastName",
                schema: "conferencemanagement",
                table: "Users");
        }
    }
}
