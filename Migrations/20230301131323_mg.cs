using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doctorappointment.Migrations
{
    public partial class mg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    doctor_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Speciality = table.Column<string>(nullable: false),
                    emailid = table.Column<string>(nullable: false),
                    Phonenumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.doctor_Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientRegistrations",
                columns: table => new
                {
                    patient_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    EmailId = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    DOB = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientRegistrations", x => x.patient_id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(nullable: true),
                    DoctorId = table.Column<int>(nullable: true),
                    AppointmentTime = table.Column<DateTime>(nullable: true),
                    AppointmentType = table.Column<string>(nullable: true),
                    AppointmentNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "doctor_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_PatientRegistrations_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientRegistrations",
                        principalColumn: "patient_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "PatientRegistrations");
        }
    }
}
