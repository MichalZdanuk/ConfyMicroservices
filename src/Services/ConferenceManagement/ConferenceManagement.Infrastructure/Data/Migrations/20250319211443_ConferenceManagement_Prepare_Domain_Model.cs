using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceManagement.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConferenceManagement_Prepare_Domain_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                schema: "conferencemanagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConferenceDetails_Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConferenceDetails_EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConferenceDetails_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prelegents",
                schema: "conferencemanagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prelegents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                schema: "conferencemanagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LectureDetails_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LectureDetails_StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LectureDetails_EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Conferences_ConferenceId",
                        column: x => x.ConferenceId,
                        principalSchema: "conferencemanagement",
                        principalTable: "Conferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureAssignments",
                schema: "conferencemanagement",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LectureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrelegentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LectureAssignments_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalSchema: "conferencemanagement",
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LectureAssignments_Prelegents_PrelegentId",
                        column: x => x.PrelegentId,
                        principalSchema: "conferencemanagement",
                        principalTable: "Prelegents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LectureAssignments_LectureId",
                schema: "conferencemanagement",
                table: "LectureAssignments",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_LectureAssignments_PrelegentId",
                schema: "conferencemanagement",
                table: "LectureAssignments",
                column: "PrelegentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_ConferenceId",
                schema: "conferencemanagement",
                table: "Lectures",
                column: "ConferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureAssignments",
                schema: "conferencemanagement");

            migrationBuilder.DropTable(
                name: "Lectures",
                schema: "conferencemanagement");

            migrationBuilder.DropTable(
                name: "Prelegents",
                schema: "conferencemanagement");

            migrationBuilder.DropTable(
                name: "Conferences",
                schema: "conferencemanagement");
        }
    }
}
