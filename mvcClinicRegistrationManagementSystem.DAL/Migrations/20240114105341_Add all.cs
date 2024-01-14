using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvcClinicRegistrationManagementSystem.DAL.Migrations
{
    public partial class Addall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    PatientsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientsName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactDetails = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.PatientsID);
                });

            migrationBuilder.CreateTable(
                name: "Specialization",
                columns: table => new
                {
                    SpecializationsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialization", x => x.SpecializationsID);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    AppoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializationsID = table.Column<int>(type: "int", nullable: false),
                    SpecializationsID1 = table.Column<int>(type: "int", nullable: false),
                    PatientsID = table.Column<int>(type: "int", nullable: false),
                    PatientsID1 = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DoctorId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.AppoID);
                    table.ForeignKey(
                        name: "FK_Appointment_Doctor_DoctorId1",
                        column: x => x.DoctorId1,
                        principalTable: "Doctor",
                        principalColumn: "DoctorId");
                    table.ForeignKey(
                        name: "FK_Appointment_Patient_PatientsID1",
                        column: x => x.PatientsID1,
                        principalTable: "Patient",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Specialization_SpecializationsID1",
                        column: x => x.SpecializationsID1,
                        principalTable: "Specialization",
                        principalColumn: "SpecializationsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_DoctorId1",
                table: "Appointment",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientsID1",
                table: "Appointment",
                column: "PatientsID1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_SpecializationsID1",
                table: "Appointment",
                column: "SpecializationsID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Specialization");
        }
    }
}
