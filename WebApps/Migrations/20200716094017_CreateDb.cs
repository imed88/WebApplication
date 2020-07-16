using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApps.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    idAdmin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    emailAdmin = table.Column<string>(nullable: false),
                    nameAdmin = table.Column<string>(nullable: true),
                    passwordAdmin = table.Column<string>(nullable: false),
                    phoneAdmin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.idAdmin);
                });

            migrationBuilder.CreateTable(
                name: "doctors",
                columns: table => new
                {
                    idDoctors = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    emailDoctors = table.Column<string>(nullable: false),
                    gender = table.Column<int>(nullable: true),
                    nameDoctors = table.Column<string>(nullable: false),
                    phoneDoctors = table.Column<string>(nullable: true),
                    specialist = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctors", x => x.idDoctors);
                });

            migrationBuilder.CreateTable(
                name: "nurses",
                columns: table => new
                {
                    idNurse = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    emailNurse = table.Column<string>(nullable: true),
                    nameNurse = table.Column<string>(nullable: true),
                    passwordNurse = table.Column<string>(nullable: true),
                    phoneNurse = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nurses", x => x.idNurse);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    idPatients = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    doctor_id = table.Column<int>(nullable: true),
                    doctorsidDoctors = table.Column<int>(nullable: true),
                    gender = table.Column<int>(nullable: true),
                    health_condition = table.Column<string>(nullable: true),
                    namePatients = table.Column<string>(nullable: true),
                    nurse_id = table.Column<int>(nullable: true),
                    nursesidNurse = table.Column<int>(nullable: true),
                    phonePatients = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.idPatients);
                    table.ForeignKey(
                        name: "FK_patients_doctors_doctorsidDoctors",
                        column: x => x.doctorsidDoctors,
                        principalTable: "doctors",
                        principalColumn: "idDoctors",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_patients_nurses_nursesidNurse",
                        column: x => x.nursesidNurse,
                        principalTable: "nurses",
                        principalColumn: "idNurse",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_patients_doctorsidDoctors",
                table: "patients",
                column: "doctorsidDoctors");

            migrationBuilder.CreateIndex(
                name: "IX_patients_nursesidNurse",
                table: "patients",
                column: "nursesidNurse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "patients");

            migrationBuilder.DropTable(
                name: "doctors");

            migrationBuilder.DropTable(
                name: "nurses");
        }
    }
}
