using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.API.Dal.Migrations
{
    /// <inheritdoc />
    public partial class Authentication_Adjust_User_Model_With_Bio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                schema: "auth",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                schema: "auth",
                table: "Users");
        }
    }
}
