using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMROOM_emproj.Migrations
{
    /// <inheritdoc />
    public partial class EMROOM_Updated_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EMROOM_Symptoms",
                table: "EMROOM_Emergency_Cases",
                newName: "EMROOM_Additional_Notes");

            migrationBuilder.AddColumn<string>(
                name: "EMROOM_Color_Code",
                table: "EMROOM_Triage_Levels",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EMROOM_Description",
                table: "EMROOM_Triage_Levels",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EMROOM_Base_Severity_Weight",
                table: "EMROOM_Symptoms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EMROOM_Category",
                table: "EMROOM_Symptoms",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EMROOM_Description",
                table: "EMROOM_Symptoms",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EMROOM_Calculated_Priority",
                table: "EMROOM_Emergency_Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EMROOM_Triage_Time",
                table: "EMROOM_Emergency_Cases",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EMROOM_Triaged_By_Nurse_Id",
                table: "EMROOM_Emergency_Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EMROOM_Case_Symptoms",
                columns: table => new
                {
                    EMROOM_Case_Symptom_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMROOM_Case_Id = table.Column<int>(type: "int", nullable: false),
                    EMROOM_Symptom_Id = table.Column<int>(type: "int", nullable: false),
                    EMROOM_Severity_Level = table.Column<int>(type: "int", nullable: false),
                    EMROOM_Notes = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EMROOM_Recorded_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMROOM_Case_Symptoms", x => x.EMROOM_Case_Symptom_Id);
                    table.ForeignKey(
                        name: "FK_EMROOM_Case_Symptoms_EMROOM_Emergency_Cases_EMROOM_Case_Id",
                        column: x => x.EMROOM_Case_Id,
                        principalTable: "EMROOM_Emergency_Cases",
                        principalColumn: "EMROOM_Case_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EMROOM_Case_Symptoms_EMROOM_Symptoms_EMROOM_Symptom_Id",
                        column: x => x.EMROOM_Symptom_Id,
                        principalTable: "EMROOM_Symptoms",
                        principalColumn: "EMROOM_Symptom_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMROOM_Emergency_Cases_EMROOM_Triaged_By_Nurse_Id",
                table: "EMROOM_Emergency_Cases",
                column: "EMROOM_Triaged_By_Nurse_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EMROOM_Case_Symptoms_EMROOM_Case_Id",
                table: "EMROOM_Case_Symptoms",
                column: "EMROOM_Case_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EMROOM_Case_Symptoms_EMROOM_Symptom_Id",
                table: "EMROOM_Case_Symptoms",
                column: "EMROOM_Symptom_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EMROOM_Emergency_Cases_EMROOM_Users_EMROOM_Triaged_By_Nurse_Id",
                table: "EMROOM_Emergency_Cases",
                column: "EMROOM_Triaged_By_Nurse_Id",
                principalTable: "EMROOM_Users",
                principalColumn: "EMROOM_User_Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EMROOM_Emergency_Cases_EMROOM_Users_EMROOM_Triaged_By_Nurse_Id",
                table: "EMROOM_Emergency_Cases");

            migrationBuilder.DropTable(
                name: "EMROOM_Case_Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_EMROOM_Emergency_Cases_EMROOM_Triaged_By_Nurse_Id",
                table: "EMROOM_Emergency_Cases");

            migrationBuilder.DropColumn(
                name: "EMROOM_Color_Code",
                table: "EMROOM_Triage_Levels");

            migrationBuilder.DropColumn(
                name: "EMROOM_Description",
                table: "EMROOM_Triage_Levels");

            migrationBuilder.DropColumn(
                name: "EMROOM_Base_Severity_Weight",
                table: "EMROOM_Symptoms");

            migrationBuilder.DropColumn(
                name: "EMROOM_Category",
                table: "EMROOM_Symptoms");

            migrationBuilder.DropColumn(
                name: "EMROOM_Description",
                table: "EMROOM_Symptoms");

            migrationBuilder.DropColumn(
                name: "EMROOM_Calculated_Priority",
                table: "EMROOM_Emergency_Cases");

            migrationBuilder.DropColumn(
                name: "EMROOM_Triage_Time",
                table: "EMROOM_Emergency_Cases");

            migrationBuilder.DropColumn(
                name: "EMROOM_Triaged_By_Nurse_Id",
                table: "EMROOM_Emergency_Cases");

            migrationBuilder.RenameColumn(
                name: "EMROOM_Additional_Notes",
                table: "EMROOM_Emergency_Cases",
                newName: "EMROOM_Symptoms");
        }
    }
}
