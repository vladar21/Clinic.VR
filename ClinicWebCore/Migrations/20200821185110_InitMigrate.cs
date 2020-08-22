using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClinicWebCore.Migrations
{
    public partial class InitMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    parent_id = table.Column<int>(nullable: true),
                    name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "timestamp", maxLength: 255, nullable: false),
                    middle_name = table.Column<string>(type: "timestamp", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "timestamp", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    address_id = table.Column<int>(nullable: false),
                    birthday = table.Column<DateTime>(type: "timestamp", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false)
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Docs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    contact_id = table.Column<int>(nullable: false),
                    department_id = table.Column<int>(nullable: false),
                    specialty = table.Column<string>(type: "varchar(255)", nullable: true),
                    office = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    hired_at = table.Column<DateTime>(type: "timestamp", nullable: false)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    contact_id = table.Column<int>(nullable: false),
                    medical_history_registore_number = table.Column<string>(maxLength: 255, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    patient_id = table.Column<int>(nullable: true),
                    is_visit_patient = table.Column<bool>(type: "tinyint", nullable: false),
                    doc_id = table.Column<int>(nullable: true),
                    department_id = table.Column<int>(nullable: true),
                    doc_schedule_year = table.Column<int>(nullable: true),
                    week_number = table.Column<int>(nullable: true),
                    week_day = table.Column<int>(nullable: true),
                    start_appointment_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    finish_appointment_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "id", "apartment", "country", "house", "locality", "region", "street", "zipcode" },
                values: new object[] { 1, "24", "Україна", "151", "Запоріжжя", "Запорізька область", "пр. Соборний", "69000" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "id", "apartment", "country", "house", "locality", "region", "street", "zipcode" },
                values: new object[] { 2, "7", "Україна", "11", "Запоріжжя", "Запорізька область", "площф Маяковського", "69001" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "id", "apartment", "country", "house", "locality", "region", "street", "zipcode" },
                values: new object[] { 3, "112", "Україна", "230", "Запоріжжя", "Запорізька область", "пр. Ювілейний", "69003" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "id", "apartment", "country", "house", "locality", "region", "street", "zipcode" },
                values: new object[] { 4, "19", "Україна", "10", "Запоріжжя", "Запорізька область", "бульвар Шевченка", "69004" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "id", "apartment", "country", "house", "locality", "region", "street", "zipcode" },
                values: new object[] { 5, "129", "Україна", "97", "Запоріжжя", "Запорізька область", "вулиця Перемоги ", "69005" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "id", "apartment", "country", "house", "locality", "region", "street", "zipcode" },
                values: new object[] { 6, "39", "Україна", "117", "Запоріжжя", "Запорізька область", "вулиця Запорізького Козацтва", "69003" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "id", "created_at", "name", "parent_id", "updated_at" },
                values: new object[] { 1, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "Адміністрація", null, new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "id", "created_at", "name", "parent_id", "updated_at" },
                values: new object[] { 2, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "Головний лікарь", 1, new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "id", "created_at", "name", "parent_id", "updated_at" },
                values: new object[] { 3, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "Стаціонар", null, new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "id", "created_at", "name", "parent_id", "updated_at" },
                values: new object[] { 4, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "хірургічне відділення", 3, new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "id", "created_at", "name", "parent_id", "updated_at" },
                values: new object[] { 5, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "Амбулаторно-поліклінічна служба", null, new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "id", "created_at", "name", "parent_id", "updated_at" },
                values: new object[] { 6, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "амбулаторне ортопедично-травматологічне відділення", 5, new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "id", "created_at", "name", "parent_id", "updated_at" },
                values: new object[] { 7, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "терапевтичне відділення", 3, new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "id", "address_id", "birthday", "created_at", "email", "first_name", "last_name", "middle_name", "phone", "updated_at" },
                values: new object[] { 1, 1, new DateTime(1950, 3, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified), "olga@com.ua", "Ольга", "Бородіна", "Вікторівна", "(068) 234-23-21", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "id", "address_id", "birthday", "created_at", "email", "first_name", "last_name", "middle_name", "phone", "updated_at" },
                values: new object[] { 4, 1, new DateTime(1951, 8, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified), "ivan@com.ua", "Іван", "Бородін", "Володимирович", "(067) 622-84-96", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "id", "address_id", "birthday", "created_at", "email", "first_name", "last_name", "middle_name", "phone", "updated_at" },
                values: new object[] { 2, 2, new DateTime(1955, 11, 23, 21, 5, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified), "mariya@com.ua", "Марія", "Колесник", "Олександрівна", "(061) 233-21-22", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "id", "address_id", "birthday", "created_at", "email", "first_name", "last_name", "middle_name", "phone", "updated_at" },
                values: new object[] { 5, 2, new DateTime(1954, 5, 4, 13, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified), "gnat@com.ua", "Гнат", "Колесник", "Миколайович", "(050) 230-30-20", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "id", "address_id", "birthday", "created_at", "email", "first_name", "last_name", "middle_name", "phone", "updated_at" },
                values: new object[] { 6, 2, new DateTime(1981, 2, 9, 8, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "alena@com.ua", "Олена", "Колесник", "Гнатовна", "(063) 333-77-55", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "id", "address_id", "birthday", "created_at", "email", "first_name", "last_name", "middle_name", "phone", "updated_at" },
                values: new object[] { 3, 3, new DateTime(1970, 7, 15, 14, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified), "semen@com.ua", "Семен", "Коротич", "Павлович", "(050) 842-32-62", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "id", "address_id", "birthday", "created_at", "email", "first_name", "last_name", "middle_name", "phone", "updated_at" },
                values: new object[] { 7, 4, new DateTime(1981, 3, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified), "vitaly@com.ua", "Віталій", "Чуб", "Сергійович", "(098) 543-32-12", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "id", "address_id", "birthday", "created_at", "email", "first_name", "last_name", "middle_name", "phone", "updated_at" },
                values: new object[] { 8, 5, new DateTime(2014, 9, 14, 10, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified), "ganna@com.ua", "Ганна", "Сумська", "Іванівна", "(068) 467-33-20", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "id", "address_id", "birthday", "created_at", "email", "first_name", "last_name", "middle_name", "phone", "updated_at" },
                values: new object[] { 9, 6, new DateTime(1991, 12, 12, 18, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "olesyaa@com.ua", "Олеся", "Богдан", "Романівна", "(061) 220-83-21", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "id", "contact_id", "department_id", "hired_at", "office", "specialty" },
                values: new object[] { 1, 2, 1, new DateTime(1978, 1, 1, 10, 30, 1, 0, DateTimeKind.Unspecified), "101", "терапевт" });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "id", "contact_id", "department_id", "hired_at", "office", "specialty" },
                values: new object[] { 2, 5, 2, new DateTime(1985, 3, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), "207", "хірург" });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "id", "contact_id", "department_id", "hired_at", "office", "specialty" },
                values: new object[] { 3, 6, 1, new DateTime(2010, 12, 27, 14, 0, 15, 0, DateTimeKind.Unspecified), "101", "педіатр" });

            migrationBuilder.InsertData(
                table: "Docs",
                columns: new[] { "id", "contact_id", "department_id", "hired_at", "office", "specialty" },
                values: new object[] { 4, 3, 3, new DateTime(2000, 7, 12, 8, 37, 0, 0, DateTimeKind.Unspecified), "23", "кардіолог" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "contact_id", "created_at", "medical_history_registore_number", "updated_at" },
                values: new object[] { 1, 1, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "MHR-001", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "contact_id", "created_at", "medical_history_registore_number", "updated_at" },
                values: new object[] { 2, 4, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "MHR-002", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "contact_id", "created_at", "medical_history_registore_number", "updated_at" },
                values: new object[] { 3, 7, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "MHR-003", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "contact_id", "created_at", "medical_history_registore_number", "updated_at" },
                values: new object[] { 4, 8, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "MHR-004", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "id", "contact_id", "created_at", "medical_history_registore_number", "updated_at" },
                values: new object[] { 5, 9, new DateTime(2019, 8, 20, 15, 18, 0, 0, DateTimeKind.Unspecified), "MHR-005", new DateTime(2020, 8, 19, 15, 18, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DepartmentDocs");

            migrationBuilder.DropTable(
                name: "DocSchedules");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
