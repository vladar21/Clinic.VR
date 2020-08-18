using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicContextLib.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zipcode = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    country = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    region = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    locality = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    street = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    house = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    apartment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parent_id = table.Column<int>(nullable: true),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<byte[]>(type: "timestamp", nullable: false),
                    updated_at = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<byte[]>(type: "timestamp", maxLength: 255, nullable: false),
                    middle_name = table.Column<byte[]>(type: "timestamp", maxLength: 255, nullable: false),
                    last_name = table.Column<byte[]>(type: "timestamp", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    address_id = table.Column<int>(nullable: false),
                    zipcode = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Contacts_Addresses_address_id",
                        column: x => x.address_id,
                        principalTable: "Addresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contact_id = table.Column<int>(nullable: false),
                    department_id = table.Column<int>(nullable: false),
                    office = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    hired_at = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Docs_Contacts_contact_id",
                        column: x => x.contact_id,
                        principalTable: "Contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contact_id = table.Column<int>(nullable: false),
                    MedicalHistoryRegistoreNumber = table.Column<string>(maxLength: 255, nullable: false),
                    created_at = table.Column<byte[]>(type: "timestamp", nullable: false),
                    updated_at = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id);
                    table.ForeignKey(
                        name: "FK_Patients_Contacts_contact_id",
                        column: x => x.contact_id,
                        principalTable: "Contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentDocs",
                columns: table => new
                {
                    department_id = table.Column<int>(nullable: false),
                    doc_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentDocs", x => new { x.department_id, x.doc_id });
                    table.ForeignKey(
                        name: "FK_DepartmentDocs_Departments_department_id",
                        column: x => x.department_id,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentDocs_Docs_doc_id",
                        column: x => x.doc_id,
                        principalTable: "Docs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocSchedules",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<int>(nullable: true),
                    is_visit_patient = table.Column<byte>(type: "tinyint", nullable: false),
                    doc_id = table.Column<int>(nullable: true),
                    department_id = table.Column<int>(nullable: true),
                    doc_schedule_year = table.Column<int>(nullable: true),
                    week_number = table.Column<int>(nullable: true),
                    week_day = table.Column<int>(nullable: true),
                    start_appointment_at = table.Column<byte[]>(type: "timestamp", nullable: false),
                    finish_appointment_at = table.Column<byte[]>(type: "timestamp", nullable: false),
                    created_at = table.Column<byte[]>(type: "timestamp", nullable: false),
                    updated_at = table.Column<byte[]>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocSchedules", x => x.id);
                    table.ForeignKey(
                        name: "FK_DocSchedules_Departments_department_id",
                        column: x => x.department_id,
                        principalTable: "Departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocSchedules_Docs_doc_id",
                        column: x => x.doc_id,
                        principalTable: "Docs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocSchedules_Patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "Patients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_address_id",
                table: "Contacts",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDocs_doc_id",
                table: "DepartmentDocs",
                column: "doc_id");

            migrationBuilder.CreateIndex(
                name: "IX_Docs_contact_id",
                table: "Docs",
                column: "contact_id");

            migrationBuilder.CreateIndex(
                name: "IX_DocSchedules_department_id",
                table: "DocSchedules",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_DocSchedules_doc_id",
                table: "DocSchedules",
                column: "doc_id");

            migrationBuilder.CreateIndex(
                name: "IX_DocSchedules_patient_id",
                table: "DocSchedules",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_contact_id",
                table: "Patients",
                column: "contact_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentDocs");

            migrationBuilder.DropTable(
                name: "DocSchedules");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Docs");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
