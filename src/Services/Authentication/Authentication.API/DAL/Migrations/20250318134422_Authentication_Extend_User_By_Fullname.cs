using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.API.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Authentication_Extend_User_By_Fullname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullName_FirstName",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FullName_LastName",
                schema: "auth",
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
                schema: "auth",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FullName_LastName",
                schema: "auth",
                table: "Users");
        }
    }
}
