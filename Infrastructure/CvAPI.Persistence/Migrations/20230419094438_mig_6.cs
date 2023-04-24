using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Educations_EducationId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_EducationId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "EducationId",
                table: "Files");

            migrationBuilder.CreateTable(
                name: "EducationEducationImageFile",
                columns: table => new
                {
                    EducationImageFilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationEducationImageFile", x => new { x.EducationImageFilesId, x.EducationsId });
                    table.ForeignKey(
                        name: "FK_EducationEducationImageFile_Educations_EducationsId",
                        column: x => x.EducationsId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EducationEducationImageFile_Files_EducationImageFilesId",
                        column: x => x.EducationImageFilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationEducationImageFile_EducationsId",
                table: "EducationEducationImageFile",
                column: "EducationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EducationEducationImageFile");

            migrationBuilder.AddColumn<Guid>(
                name: "EducationId",
                table: "Files",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_EducationId",
                table: "Files",
                column: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Educations_EducationId",
                table: "Files",
                column: "EducationId",
                principalTable: "Educations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
