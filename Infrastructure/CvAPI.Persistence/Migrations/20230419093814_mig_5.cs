using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchollImage",
                table: "Files");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "SchollImage",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
