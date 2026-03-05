using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMROOM_emproj.Migrations
{
    /// <inheritdoc />
    public partial class EMROOM_Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EMROOM_Patients",
                columns: table => new
                {
                    EMROOM_Patient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMROOM_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMROOM_Age = table.Column<int>(type: "int", nullable: false),
                    EMROOM_Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EMROOM_Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EMROOM_Created_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMROOM_Patients", x => x.EMROOM_Patient_Id);
                });

            migrationBuilder.CreateTable(
                name: "EMROOM_Symptoms",
                columns: table => new
                {
                    EMROOM_Symptom_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMROOM_Symptom_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMROOM_Symptoms", x => x.EMROOM_Symptom_Id);
                });

            migrationBuilder.CreateTable(
                name: "EMROOM_Triage_Levels",
                columns: table => new
                {
                    EMROOM_Triage_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMROOM_Level_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EMROOM_Priority_Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMROOM_Triage_Levels", x => x.EMROOM_Triage_Id);
                });

            migrationBuilder.CreateTable(
                name: "EMROOM_Users",
                columns: table => new
                {
                    EMROOM_User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMROOM_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMROOM_Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EMROOM_Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EMROOM_Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMROOM_Users", x => x.EMROOM_User_Id);
                });

            migrationBuilder.CreateTable(
                name: "EMROOM_Emergency_Cases",
                columns: table => new
                {
                    EMROOM_Case_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMROOM_Patient_Id = table.Column<int>(type: "int", nullable: false),
                    EMROOM_Triage_Id = table.Column<int>(type: "int", nullable: false),
                    EMROOM_Symptoms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EMROOM_Arrival_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EMROOM_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMROOM_Emergency_Cases", x => x.EMROOM_Case_Id);
                    table.ForeignKey(
                        name: "FK_EMROOM_Emergency_Cases_EMROOM_Patients_EMROOM_Patient_Id",
                        column: x => x.EMROOM_Patient_Id,
                        principalTable: "EMROOM_Patients",
                        principalColumn: "EMROOM_Patient_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMROOM_Emergency_Cases_EMROOM_Triage_Levels_EMROOM_Triage_Id",
                        column: x => x.EMROOM_Triage_Id,
                        principalTable: "EMROOM_Triage_Levels",
                        principalColumn: "EMROOM_Triage_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EMROOM_Treatments",
                columns: table => new
                {
                    EMROOM_Treatment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EMROOM_Case_Id = table.Column<int>(type: "int", nullable: false),
                    EMROOM_Physician_Id = table.Column<int>(type: "int", nullable: false),
                    EMROOM_Diagnosis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EMROOM_Treatment_Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    EMROOM_Treated_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMROOM_Treatments", x => x.EMROOM_Treatment_Id);
                    table.ForeignKey(
                        name: "FK_EMROOM_Treatments_EMROOM_Emergency_Cases_EMROOM_Case_Id",
                        column: x => x.EMROOM_Case_Id,
                        principalTable: "EMROOM_Emergency_Cases",
                        principalColumn: "EMROOM_Case_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EMROOM_Treatments_EMROOM_Users_EMROOM_Physician_Id",
                        column: x => x.EMROOM_Physician_Id,
                        principalTable: "EMROOM_Users",
                        principalColumn: "EMROOM_User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EMROOM_Emergency_Cases_EMROOM_Patient_Id",
                table: "EMROOM_Emergency_Cases",
                column: "EMROOM_Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EMROOM_Emergency_Cases_EMROOM_Triage_Id",
                table: "EMROOM_Emergency_Cases",
                column: "EMROOM_Triage_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EMROOM_Treatments_EMROOM_Case_Id",
                table: "EMROOM_Treatments",
                column: "EMROOM_Case_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EMROOM_Treatments_EMROOM_Physician_Id",
                table: "EMROOM_Treatments",
                column: "EMROOM_Physician_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EMROOM_Symptoms");

            migrationBuilder.DropTable(
                name: "EMROOM_Treatments");

            migrationBuilder.DropTable(
                name: "EMROOM_Emergency_Cases");

            migrationBuilder.DropTable(
                name: "EMROOM_Users");

            migrationBuilder.DropTable(
                name: "EMROOM_Patients");

            migrationBuilder.DropTable(
                name: "EMROOM_Triage_Levels");
        }
    }
}
