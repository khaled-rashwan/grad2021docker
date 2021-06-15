using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace grad2021.Migrations
{
    public partial class PrepYearStudentsAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicYears",
                columns: table => new
                {
                    AcademicYearID = table.Column<int>(type: "int", nullable: false),
                    FirstSemesterStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstSemesterExamsStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstSemesterControlStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstSemesterObjectionStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstSemesterObjectionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondSemesterStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondSemesterExamsStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondSemesterControlStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondSemesterObjectionStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecondSemesterObjectionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NovemberExamsStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NovemberControlStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NovemberObjectionStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NovemberObjectionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicYears", x => x.AcademicYearID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentName);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Branches",
                columns: table => new
                {
                    BranchName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BranchDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullCapacity = table.Column<int>(type: "int", nullable: false),
                    CurrentCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchName);
                    table.ForeignKey(
                        name: "FK_Branches_Departments_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Departments",
                        principalColumn: "DepartmentName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentCodes",
                columns: table => new
                {
                    DepartmentCodeValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCodes", x => x.DepartmentCodeValue);
                    table.ForeignKey(
                        name: "FK_DepartmentCodes_Departments_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Departments",
                        principalColumn: "DepartmentName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    InstructorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.InstructorNatId);
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_DepartmentName",
                        column: x => x.DepartmentName,
                        principalTable: "Departments",
                        principalColumn: "DepartmentName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<long>(type: "bigint", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SeatNo = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelName = table.Column<int>(type: "int", nullable: true),
                    BranchName1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentNatId);
                    table.ForeignKey(
                        name: "FK_Students_Branches_BranchName1",
                        column: x => x.BranchName1,
                        principalTable: "Branches",
                        principalColumn: "BranchName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    DepartmentCodeValue = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CourseDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LectureWeeklyDuration = table.Column<int>(type: "int", nullable: true),
                    SectionWeeklyDuration = table.Column<int>(type: "int", nullable: true),
                    CourseWorkMaxScore = table.Column<double>(type: "float", nullable: false),
                    MidTermExamMaxScore = table.Column<double>(type: "float", nullable: false),
                    OralExamMaxScore = table.Column<double>(type: "float", nullable: false),
                    TermExamMaxScore = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseName);
                    table.ForeignKey(
                        name: "FK_Courses_DepartmentCodes_DepartmentCodeValue",
                        column: x => x.DepartmentCodeValue,
                        principalTable: "DepartmentCodes",
                        principalColumn: "DepartmentCodeValue",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorProfessions",
                columns: table => new
                {
                    InstructorProfessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    ProfessionDegree = table.Column<int>(type: "int", nullable: false),
                    PromotionDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorProfessions", x => x.InstructorProfessionID);
                    table.ForeignKey(
                        name: "FK_InstructorProfessions_Instructors_InstructorNatId",
                        column: x => x.InstructorNatId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorNatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEnrollments",
                columns: table => new
                {
                    StudentNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AcademicYearID = table.Column<int>(type: "int", nullable: false),
                    LevelName = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsNovember = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEnrollments", x => new { x.StudentNatId, x.AcademicYearID });
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_AcademicYears_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Branches_BranchName",
                        column: x => x.BranchName,
                        principalTable: "Branches",
                        principalColumn: "BranchName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentEnrollments_Students_StudentNatId",
                        column: x => x.StudentNatId,
                        principalTable: "Students",
                        principalColumn: "StudentNatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollments",
                columns: table => new
                {
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LevelName = table.Column<int>(type: "int", nullable: false),
                    Term = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollments", x => new { x.CourseName, x.BranchName });
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_Branches_BranchName",
                        column: x => x.BranchName,
                        principalTable: "Branches",
                        principalColumn: "BranchName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_Courses_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Courses",
                        principalColumn: "CourseName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Selection",
                columns: table => new
                {
                    SelectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AcademicYearID = table.Column<int>(type: "int", nullable: false),
                    SelectionNo = table.Column<int>(type: "int", nullable: false),
                    CurrentBranchName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SelectionBranchName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StudentNatId1 = table.Column<decimal>(type: "decimal(20,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selection", x => x.SelectionID);
                    table.ForeignKey(
                        name: "FK_Selection_AcademicYears_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Selection_Branches_CurrentBranchName",
                        column: x => x.CurrentBranchName,
                        principalTable: "Branches",
                        principalColumn: "BranchName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selection_Branches_SelectionBranchName",
                        column: x => x.SelectionBranchName,
                        principalTable: "Branches",
                        principalColumn: "BranchName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selection_StudentEnrollments_StudentNatId_AcademicYearID",
                        columns: x => new { x.StudentNatId, x.AcademicYearID },
                        principalTable: "StudentEnrollments",
                        principalColumns: new[] { "StudentNatId", "AcademicYearID" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selection_Students_StudentNatId1",
                        column: x => x.StudentNatId1,
                        principalTable: "Students",
                        principalColumn: "StudentNatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorEnrollments",
                columns: table => new
                {
                    InstructorEnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstructorNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    AcademicYearID = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorEnrollments", x => x.InstructorEnrollmentID);
                    table.ForeignKey(
                        name: "FK_InstructorEnrollments_AcademicYears_AcademicYearID",
                        column: x => x.AcademicYearID,
                        principalTable: "AcademicYears",
                        principalColumn: "AcademicYearID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorEnrollments_CourseEnrollments_CourseName_BranchName",
                        columns: x => new { x.CourseName, x.BranchName },
                        principalTable: "CourseEnrollments",
                        principalColumns: new[] { "CourseName", "BranchName" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorEnrollments_Instructors_InstructorNatId",
                        column: x => x.InstructorNatId,
                        principalTable: "Instructors",
                        principalColumn: "InstructorNatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentCourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AcademicYearID = table.Column<int>(type: "int", nullable: false),
                    BranchName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StudentNatId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    MidTermMark = table.Column<double>(type: "float", nullable: false),
                    CourseWorkMark = table.Column<double>(type: "float", nullable: false),
                    OralExamMark = table.Column<double>(type: "float", nullable: false),
                    FinalExamMark = table.Column<double>(type: "float", nullable: false),
                    MerciMark = table.Column<double>(type: "float", nullable: false),
                    IsNovember = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.StudentCourseID);
                    table.ForeignKey(
                        name: "FK_StudentCourses_CourseEnrollments_CourseName_BranchName",
                        columns: x => new { x.CourseName, x.BranchName },
                        principalTable: "CourseEnrollments",
                        principalColumns: new[] { "CourseName", "BranchName" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourses_StudentEnrollments_StudentNatId_AcademicYearID",
                        columns: x => new { x.StudentNatId, x.AcademicYearID },
                        principalTable: "StudentEnrollments",
                        principalColumns: new[] { "StudentNatId", "AcademicYearID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicYears",
                columns: new[] { "AcademicYearID", "FirstSemesterControlStartDate", "FirstSemesterExamsStartDate", "FirstSemesterObjectionEndDate", "FirstSemesterObjectionStartDate", "FirstSemesterStartDate", "NovemberControlStartDate", "NovemberExamsStartDate", "NovemberObjectionEndDate", "NovemberObjectionStartDate", "SecondSemesterControlStartDate", "SecondSemesterExamsStartDate", "SecondSemesterObjectionEndDate", "SecondSemesterObjectionStartDate", "SecondSemesterStartDate" },
                values: new object[,]
                {
                    { 2020, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 2021, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 2022, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 2023, null, null, null, null, null, null, null, null, null, null, null, null, null, null },
                    { 2024, null, null, null, null, null, null, null, null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentName", "DepartmentDescription" },
                values: new object[,]
                {
                    { "الرياضيات والفيزيقا الهندسية", "وصف قسم الرياضيات والفيزيقا الهندسية" },
                    { "الهندسة المدنية", "وصف قسم الهندسة المدنية" },
                    { "الهندسة الكهربية", "وصف قسم الهندسة الكهربية" },
                    { "الهندسة المعمارية", "وصف قسم الهندسة المعمارية" },
                    { "الهندسة الميكانيكية", "وصف قسم الهندسة الميكانيكية" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNatId", "BirthDate", "BirthPlace", "Discriminator", "EnrollmentDate", "Gender", "Phone", "SeatNo", "StudentName" },
                values: new object[,]
                {
                    { 77m, null, null, "Student", null, 0, null, null, "StudentName 77" },
                    { 78m, null, null, "Student", null, 1, null, null, "StudentName 78" },
                    { 79m, null, null, "Student", null, 0, null, null, "StudentName 79" },
                    { 80m, null, null, "Student", null, 1, null, null, "StudentName 80" },
                    { 81m, null, null, "Student", null, 0, null, null, "StudentName 81" },
                    { 86m, null, null, "Student", null, 1, null, null, "StudentName 86" },
                    { 83m, null, null, "Student", null, 0, null, null, "StudentName 83" },
                    { 84m, null, null, "Student", null, 1, null, null, "StudentName 84" },
                    { 85m, null, null, "Student", null, 0, null, null, "StudentName 85" },
                    { 76m, null, null, "Student", null, 1, null, null, "StudentName 76" },
                    { 87m, null, null, "Student", null, 0, null, null, "StudentName 87" },
                    { 82m, null, null, "Student", null, 1, null, null, "StudentName 82" },
                    { 75m, null, null, "Student", null, 0, null, null, "StudentName 75" },
                    { 70m, null, null, "Student", null, 1, null, null, "StudentName 70" },
                    { 73m, null, null, "Student", null, 0, null, null, "StudentName 73" },
                    { 72m, null, null, "Student", null, 1, null, null, "StudentName 72" },
                    { 71m, null, null, "Student", null, 0, null, null, "StudentName 71" },
                    { 88m, null, null, "Student", null, 1, null, null, "StudentName 88" },
                    { 69m, null, null, "Student", null, 0, null, null, "StudentName 69" },
                    { 68m, null, null, "Student", null, 1, null, null, "StudentName 68" },
                    { 67m, null, null, "Student", null, 0, null, null, "StudentName 67" },
                    { 66m, null, null, "Student", null, 1, null, null, "StudentName 66" },
                    { 65m, null, null, "Student", null, 0, null, null, "StudentName 65" },
                    { 64m, null, null, "Student", null, 1, null, null, "StudentName 64" },
                    { 63m, null, null, "Student", null, 0, null, null, "StudentName 63" },
                    { 62m, null, null, "Student", null, 1, null, null, "StudentName 62" },
                    { 74m, null, null, "Student", null, 1, null, null, "StudentName 74" },
                    { 89m, null, null, "Student", null, 0, null, null, "StudentName 89" },
                    { 94m, null, null, "Student", null, 1, null, null, "StudentName 94" },
                    { 91m, null, null, "Student", null, 0, null, null, "StudentName 91" },
                    { 118m, null, null, "Student", null, 1, null, null, "StudentName 118" },
                    { 117m, null, null, "Student", null, 0, null, null, "StudentName 117" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNatId", "BirthDate", "BirthPlace", "Discriminator", "EnrollmentDate", "Gender", "Phone", "SeatNo", "StudentName" },
                values: new object[,]
                {
                    { 116m, null, null, "Student", null, 1, null, null, "StudentName 116" },
                    { 115m, null, null, "Student", null, 0, null, null, "StudentName 115" },
                    { 114m, null, null, "Student", null, 1, null, null, "StudentName 114" },
                    { 113m, null, null, "Student", null, 0, null, null, "StudentName 113" },
                    { 112m, null, null, "Student", null, 1, null, null, "StudentName 112" },
                    { 111m, null, null, "Student", null, 0, null, null, "StudentName 111" },
                    { 110m, null, null, "Student", null, 1, null, null, "StudentName 110" },
                    { 109m, null, null, "Student", null, 0, null, null, "StudentName 109" },
                    { 108m, null, null, "Student", null, 1, null, null, "StudentName 108" },
                    { 107m, null, null, "Student", null, 0, null, null, "StudentName 107" },
                    { 106m, null, null, "Student", null, 1, null, null, "StudentName 106" },
                    { 105m, null, null, "Student", null, 0, null, null, "StudentName 105" },
                    { 104m, null, null, "Student", null, 1, null, null, "StudentName 104" },
                    { 103m, null, null, "Student", null, 0, null, null, "StudentName 103" },
                    { 102m, null, null, "Student", null, 1, null, null, "StudentName 102" },
                    { 101m, null, null, "Student", null, 0, null, null, "StudentName 101" },
                    { 100m, null, null, "Student", null, 1, null, null, "StudentName 100" },
                    { 99m, null, null, "Student", null, 0, null, null, "StudentName 99" },
                    { 98m, null, null, "Student", null, 1, null, null, "StudentName 98" },
                    { 97m, null, null, "Student", null, 0, null, null, "StudentName 97" },
                    { 96m, null, null, "Student", null, 1, null, null, "StudentName 96" },
                    { 95m, null, null, "Student", null, 0, null, null, "StudentName 95" },
                    { 61m, null, null, "Student", null, 0, null, null, "StudentName 61" },
                    { 93m, null, null, "Student", null, 0, null, null, "StudentName 93" },
                    { 92m, null, null, "Student", null, 1, null, null, "StudentName 92" },
                    { 90m, null, null, "Student", null, 1, null, null, "StudentName 90" },
                    { 60m, null, null, "Student", null, 1, null, null, "StudentName 60" },
                    { 55m, null, null, "Student", null, 0, null, null, "StudentName 55" },
                    { 58m, null, null, "Student", null, 1, null, null, "StudentName 58" },
                    { 26m, null, null, "Student", null, 1, null, null, "StudentName 26" },
                    { 25m, null, null, "Student", null, 0, null, null, "StudentName 25" },
                    { 24m, null, null, "Student", null, 1, null, null, "StudentName 24" },
                    { 23m, null, null, "Student", null, 0, null, null, "StudentName 23" },
                    { 22m, null, null, "Student", null, 1, null, null, "StudentName 22" },
                    { 21m, null, null, "Student", null, 0, null, null, "StudentName 21" },
                    { 20m, null, null, "Student", null, 1, null, null, "StudentName 20" },
                    { 19m, null, null, "Student", null, 0, null, null, "StudentName 19" },
                    { 18m, null, null, "Student", null, 1, null, null, "StudentName 18" },
                    { 17m, null, null, "Student", null, 0, null, null, "StudentName 17" },
                    { 16m, null, null, "Student", null, 1, null, null, "StudentName 16" },
                    { 15m, null, null, "Student", null, 0, null, null, "StudentName 15" },
                    { 27m, null, null, "Student", null, 0, null, null, "StudentName 27" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNatId", "BirthDate", "BirthPlace", "Discriminator", "EnrollmentDate", "Gender", "Phone", "SeatNo", "StudentName" },
                values: new object[,]
                {
                    { 14m, null, null, "Student", null, 1, null, null, "StudentName 14" },
                    { 12m, null, null, "Student", null, 1, null, null, "StudentName 12" },
                    { 11m, null, null, "Student", null, 0, null, null, "StudentName 11" },
                    { 10m, null, null, "Student", null, 1, null, null, "StudentName 10" },
                    { 9m, null, null, "Student", null, 0, null, null, "StudentName 9" },
                    { 8m, null, null, "Student", null, 1, null, null, "StudentName 8" },
                    { 7m, null, null, "Student", null, 0, null, null, "StudentName 7" },
                    { 6m, null, null, "Student", null, 1, null, null, "StudentName 6" },
                    { 5m, null, null, "Student", null, 0, null, null, "StudentName 5" },
                    { 4m, null, null, "Student", null, 1, null, null, "StudentName 4" },
                    { 3m, null, null, "Student", null, 0, null, null, "StudentName 3" },
                    { 2m, null, null, "Student", null, 1, null, null, "StudentName 2" },
                    { 1m, null, null, "Student", null, 0, null, null, "StudentName 1" },
                    { 13m, null, null, "Student", null, 0, null, null, "StudentName 13" },
                    { 28m, null, null, "Student", null, 1, null, null, "StudentName 28" },
                    { 29m, null, null, "Student", null, 0, null, null, "StudentName 29" },
                    { 30m, null, null, "Student", null, 1, null, null, "StudentName 30" },
                    { 57m, null, null, "Student", null, 0, null, null, "StudentName 57" },
                    { 56m, null, null, "Student", null, 1, null, null, "StudentName 56" },
                    { 119m, null, null, "Student", null, 0, null, null, "StudentName 119" },
                    { 54m, null, null, "Student", null, 1, null, null, "StudentName 54" },
                    { 53m, null, null, "Student", null, 0, null, null, "StudentName 53" },
                    { 52m, null, null, "Student", null, 1, null, null, "StudentName 52" },
                    { 51m, null, null, "Student", null, 0, null, null, "StudentName 51" },
                    { 50m, null, null, "Student", null, 1, null, null, "StudentName 50" },
                    { 49m, null, null, "Student", null, 0, null, null, "StudentName 49" },
                    { 48m, null, null, "Student", null, 1, null, null, "StudentName 48" },
                    { 47m, null, null, "Student", null, 0, null, null, "StudentName 47" },
                    { 46m, null, null, "Student", null, 1, null, null, "StudentName 46" },
                    { 45m, null, null, "Student", null, 0, null, null, "StudentName 45" },
                    { 44m, null, null, "Student", null, 1, null, null, "StudentName 44" },
                    { 43m, null, null, "Student", null, 0, null, null, "StudentName 43" },
                    { 42m, null, null, "Student", null, 1, null, null, "StudentName 42" },
                    { 41m, null, null, "Student", null, 0, null, null, "StudentName 41" },
                    { 40m, null, null, "Student", null, 1, null, null, "StudentName 40" },
                    { 39m, null, null, "Student", null, 0, null, null, "StudentName 39" },
                    { 38m, null, null, "Student", null, 1, null, null, "StudentName 38" },
                    { 37m, null, null, "Student", null, 0, null, null, "StudentName 37" },
                    { 36m, null, null, "Student", null, 1, null, null, "StudentName 36" },
                    { 35m, null, null, "Student", null, 0, null, null, "StudentName 35" },
                    { 34m, null, null, "Student", null, 1, null, null, "StudentName 34" },
                    { 33m, null, null, "Student", null, 0, null, null, "StudentName 33" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNatId", "BirthDate", "BirthPlace", "Discriminator", "EnrollmentDate", "Gender", "Phone", "SeatNo", "StudentName" },
                values: new object[,]
                {
                    { 32m, null, null, "Student", null, 1, null, null, "StudentName 32" },
                    { 31m, null, null, "Student", null, 0, null, null, "StudentName 31" },
                    { 59m, null, null, "Student", null, 0, null, null, "StudentName 59" },
                    { 120m, null, null, "Student", null, 1, null, null, "StudentName 120" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchName", "BranchDescription", "CurrentCapacity", "DepartmentName", "FullCapacity" },
                values: new object[,]
                {
                    { "الرياضيات والفيزيقا الهندسية", "وصف قسم الرياضيات والفيزيقا الهندسية", 0, "الرياضيات والفيزيقا الهندسية", 20 },
                    { "هندسة القوى الميكانيكية", "وصف شعبة هندسة القوى الميكانيكية", 0, "الهندسة الميكانيكية", 20 },
                    { "الهندسة الصناعية", "وصف شعبة الهندسة الصناعية", 0, "الهندسة الميكانيكية", 20 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "وصف شعبة هندسة الإنتاج والتصميم الميكانيكي", 0, "الهندسة الميكانيكية", 20 },
                    { "الهندسة الميكانيكية", "وصف قسم الهندسة الميكانيكية", 0, "الهندسة الميكانيكية", 20 },
                    { "الهندسة المدنية", "وصف قسم الهندسة المدنية", 0, "الهندسة المدنية", 20 },
                    { "هندسة القوى والآلات الكهربية", "وصف شعبة هندسة القوى والآلات الكهربية", 0, "الهندسة الكهربية", 20 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "وصف شعبة هندسة الإلكترونيات والاتصالات الكهربية", 0, "الهندسة الكهربية", 20 },
                    { "هندسة الحاسبات والنظم", "وصف شعبة هندسة الحاسبات والنظم", 0, "الهندسة الكهربية", 20 },
                    { "الهندسة المعمارية", "وصف قسم الهندسة المعمارية", 0, "الهندسة المعمارية", 20 }
                });

            migrationBuilder.InsertData(
                table: "DepartmentCodes",
                columns: new[] { "DepartmentCodeValue", "DepartmentName" },
                values: new object[,]
                {
                    { "تمج", "الهندسة الميكانيكية" },
                    { "عمر", "الهندسة المعمارية" },
                    { "كهح", "الهندسة الكهربية" },
                    { "كھع", "الهندسة الكهربية" },
                    { "كهق", "الهندسة الكهربية" },
                    { "صنع", "الهندسة الميكانيكية" },
                    { "مدن", "الهندسة المدنية" },
                    { "هند", "الرياضيات والفيزيقا الهندسية" },
                    { "عام", "الرياضيات والفيزيقا الهندسية" },
                    { "ميك", "الرياضيات والفيزيقا الهندسية" },
                    { "فيز", "الرياضيات والفيزيقا الهندسية" },
                    { "ريض", "الرياضيات والفيزيقا الهندسية" },
                    { "كهت", "الهندسة الكهربية" },
                    { "قوى", "الهندسة الميكانيكية" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseName", "CourseCode", "CourseDescription", "CourseWorkMaxScore", "DepartmentCodeValue", "LectureWeeklyDuration", "MidTermExamMaxScore", "OralExamMaxScore", "SectionWeeklyDuration", "TermExamMaxScore" },
                values: new object[,]
                {
                    { "CourseName 103", "103", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 274", "274", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 260", "260", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 246", "246", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 232", "232", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 218", "218", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 204", "204", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 190", "190", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 176", "176", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 162", "162", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 148", "148", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 134", "134", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 120", "120", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 106", "106", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 92", "92", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 78", "78", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 64", "64", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 50", "50", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 36", "36", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 22", "22", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 8", "8", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 315", "315", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 301", "301", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 287", "287", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 288", "288", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 302", "302", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 316", "316", null, 10.0, "كهق", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 9", "9", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 24", "24", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 10", "10", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 317", "317", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 303", "303", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 289", "289", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 275", "275", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 261", "261", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 247", "247", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 233", "233", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 219", "219", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 205", "205", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 273", "273", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 191", "191", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 163", "163", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseName", "CourseCode", "CourseDescription", "CourseWorkMaxScore", "DepartmentCodeValue", "LectureWeeklyDuration", "MidTermExamMaxScore", "OralExamMaxScore", "SectionWeeklyDuration", "TermExamMaxScore" },
                values: new object[,]
                {
                    { "CourseName 149", "149", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 135", "135", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 121", "121", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 107", "107", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 93", "93", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 79", "79", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 65", "65", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 51", "51", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 37", "37", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 23", "23", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 177", "177", null, 10.0, "كهت", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 259", "259", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 245", "245", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 231", "231", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 146", "146", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 132", "132", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 118", "118", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 104", "104", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 90", "90", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 76", "76", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 62", "62", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 48", "48", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 34", "34", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 20", "20", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 6", "6", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 160", "160", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 313", "313", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 285", "285", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 271", "271", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 257", "257", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 243", "243", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 229", "229", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 215", "215", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 201", "201", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 187", "187", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 173", "173", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 159", "159", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 145", "145", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 299", "299", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 38", "38", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 174", "174", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 202", "202", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseName", "CourseCode", "CourseDescription", "CourseWorkMaxScore", "DepartmentCodeValue", "LectureWeeklyDuration", "MidTermExamMaxScore", "OralExamMaxScore", "SectionWeeklyDuration", "TermExamMaxScore" },
                values: new object[,]
                {
                    { "CourseName 217", "217", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 203", "203", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 189", "189", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 175", "175", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 161", "161", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 147", "147", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 133", "133", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 119", "119", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 105", "105", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 91", "91", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 77", "77", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 188", "188", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 63", "63", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 35", "35", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 21", "21", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 7", "7", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 314", "314", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 300", "300", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 286", "286", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 272", "272", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 258", "258", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 244", "244", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 230", "230", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 216", "216", null, 10.0, "مدن", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 49", "49", null, 10.0, "كھع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 131", "131", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 52", "52", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 80", "80", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 223", "223", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 209", "209", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 195", "195", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 181", "181", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 167", "167", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 153", "153", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 139", "139", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 125", "125", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 111", "111", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 97", "97", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 83", "83", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 69", "69", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 55", "55", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 41", "41", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseName", "CourseCode", "CourseDescription", "CourseWorkMaxScore", "DepartmentCodeValue", "LectureWeeklyDuration", "MidTermExamMaxScore", "OralExamMaxScore", "SectionWeeklyDuration", "TermExamMaxScore" },
                values: new object[,]
                {
                    { "CourseName 27", "27", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 13", "13", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 320", "320", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 306", "306", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 292", "292", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 278", "278", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 264", "264", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 250", "250", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 236", "236", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 237", "237", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 251", "251", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 265", "265", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 279", "279", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 291", "291", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 277", "277", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 263", "263", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 249", "249", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 235", "235", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 221", "221", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 207", "207", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 193", "193", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 179", "179", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 165", "165", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 151", "151", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 222", "222", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 137", "137", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 109", "109", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 95", "95", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 81", "81", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 67", "67", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 53", "53", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 39", "39", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 25", "25", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 11", "11", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 321", "321", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 307", "307", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 293", "293", null, 10.0, "صنع", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 123", "123", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 208", "208", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 194", "194", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 180", "180", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 98", "98", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseName", "CourseCode", "CourseDescription", "CourseWorkMaxScore", "DepartmentCodeValue", "LectureWeeklyDuration", "MidTermExamMaxScore", "OralExamMaxScore", "SectionWeeklyDuration", "TermExamMaxScore" },
                values: new object[,]
                {
                    { "CourseName 84", "84", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 70", "70", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 56", "56", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 42", "42", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 28", "28", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 14", "14", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 318", "318", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 304", "304", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 290", "290", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 276", "276", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 112", "112", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 262", "262", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 234", "234", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 220", "220", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 206", "206", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 192", "192", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 178", "178", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 164", "164", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 150", "150", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 136", "136", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 122", "122", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 108", "108", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 94", "94", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 248", "248", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 66", "66", null, 10.0, "كهح", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 126", "126", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 154", "154", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 166", "166", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 152", "152", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 138", "138", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 124", "124", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 110", "110", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 96", "96", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 82", "82", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 68", "68", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 54", "54", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 40", "40", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 26", "26", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 140", "140", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 12", "12", null, 10.0, "تمج", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 308", "308", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 294", "294", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseName", "CourseCode", "CourseDescription", "CourseWorkMaxScore", "DepartmentCodeValue", "LectureWeeklyDuration", "MidTermExamMaxScore", "OralExamMaxScore", "SectionWeeklyDuration", "TermExamMaxScore" },
                values: new object[,]
                {
                    { "CourseName 280", "280", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 266", "266", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 252", "252", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 238", "238", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 224", "224", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 210", "210", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 196", "196", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 182", "182", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 168", "168", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 322", "322", null, 10.0, "عمر", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 117", "117", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 319", "319", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 89", "89", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 30", "30", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 44", "44", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 58", "58", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 72", "72", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 86", "86", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 100", "100", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 114", "114", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 128", "128", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 142", "142", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 156", "156", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 16", "16", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 170", "170", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 198", "198", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 212", "212", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 226", "226", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 240", "240", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 254", "254", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 268", "268", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 282", "282", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 296", "296", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 310", "310", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 324", "324", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 184", "184", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 3", "3", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 2", "2", null, 10.0, "فيز", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 309", "309", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 305", "305", null, 10.0, "قوى", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 1", "1", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 15", "15", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseName", "CourseCode", "CourseDescription", "CourseWorkMaxScore", "DepartmentCodeValue", "LectureWeeklyDuration", "MidTermExamMaxScore", "OralExamMaxScore", "SectionWeeklyDuration", "TermExamMaxScore" },
                values: new object[,]
                {
                    { "CourseName 29", "29", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 43", "43", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 57", "57", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 71", "71", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 85", "85", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 99", "99", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 113", "113", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 323", "323", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 127", "127", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 155", "155", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 169", "169", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 183", "183", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 197", "197", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 211", "211", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 225", "225", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 239", "239", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 253", "253", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 267", "267", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 295", "295", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 141", "141", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 17", "17", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 281", "281", null, 10.0, "ريض", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 45", "45", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 102", "102", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 116", "116", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 130", "130", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 144", "144", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 158", "158", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 172", "172", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 186", "186", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 200", "200", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 214", "214", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 228", "228", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 88", "88", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 256", "256", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 284", "284", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 298", "298", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 312", "312", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 5", "5", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 19", "19", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 33", "33", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 47", "47", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseName", "CourseCode", "CourseDescription", "CourseWorkMaxScore", "DepartmentCodeValue", "LectureWeeklyDuration", "MidTermExamMaxScore", "OralExamMaxScore", "SectionWeeklyDuration", "TermExamMaxScore" },
                values: new object[,]
                {
                    { "CourseName 61", "61", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 31", "31", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 75", "75", null, 10.0, "هند", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 270", "270", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 74", "74", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 242", "242", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 46", "46", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 59", "59", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 73", "73", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 60", "60", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 87", "87", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 101", "101", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 115", "115", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 129", "129", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 157", "157", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 171", "171", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 185", "185", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 199", "199", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 213", "213", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 143", "143", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 227", "227", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 32", "32", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 4", "4", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 311", "311", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 297", "297", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 18", "18", null, 10.0, "عام", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 269", "269", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 255", "255", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 241", "241", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 },
                    { "CourseName 283", "283", null, 10.0, "ميك", null, 20.0, 10.0, null, 60.0 }
                });

            migrationBuilder.InsertData(
                table: "StudentEnrollments",
                columns: new[] { "AcademicYearID", "StudentNatId", "BranchName", "IsNovember", "LevelName" },
                values: new object[,]
                {
                    { 2024, 44m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 43m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 42m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 41m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 40m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 33m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 38m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 37m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 34m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 36m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 35m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 39m, "الرياضيات والفيزيقا الهندسية", false, 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentEnrollments",
                columns: new[] { "AcademicYearID", "StudentNatId", "BranchName", "IsNovember", "LevelName" },
                values: new object[,]
                {
                    { 2024, 45m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 55m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 47m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 48m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 49m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 50m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 51m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 52m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 53m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 54m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 56m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 57m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 32m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 58m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 46m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 31m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 7m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 29m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 59m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 2m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 3m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 4m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 5m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 6m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 8m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 9m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 10m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 11m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 12m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 13m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 14m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 15m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 16m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 17m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 18m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 19m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 20m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 21m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 22m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 23m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 24m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 25m, "الرياضيات والفيزيقا الهندسية", false, 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentEnrollments",
                columns: new[] { "AcademicYearID", "StudentNatId", "BranchName", "IsNovember", "LevelName" },
                values: new object[,]
                {
                    { 2024, 26m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 27m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 28m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 30m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 60m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 111m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 62m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 94m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 95m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 96m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 97m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 98m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 99m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 100m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 101m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 102m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 103m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 104m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 105m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 93m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 106m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 108m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 109m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 110m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 112m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 113m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 114m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 115m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 116m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 117m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 118m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 119m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 120m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 107m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 92m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 91m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 90m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 63m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 64m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 65m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 66m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 67m, "الرياضيات والفيزيقا الهندسية", false, 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentEnrollments",
                columns: new[] { "AcademicYearID", "StudentNatId", "BranchName", "IsNovember", "LevelName" },
                values: new object[,]
                {
                    { 2024, 68m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 69m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 70m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 71m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 72m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 73m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 74m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 75m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 76m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 77m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 78m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 79m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 80m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 81m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 82m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 83m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 84m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 85m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 86m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 87m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 88m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 89m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 61m, "الرياضيات والفيزيقا الهندسية", false, 0 },
                    { 2024, 1m, "الرياضيات والفيزيقا الهندسية", false, 0 }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollments",
                columns: new[] { "BranchName", "CourseName", "LevelName", "Term" },
                values: new object[,]
                {
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 1", 0, 0 },
                    { "الهندسة المعمارية", "CourseName 164", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 150", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 136", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 122", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 108", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 94", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 80", 2, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 178", 1, 1 },
                    { "الهندسة الميكانيكية", "CourseName 66", 3, 1 },
                    { "الهندسة المعمارية", "CourseName 38", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 24", 3, 1 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 10", 0, 1 },
                    { "هندسة الحاسبات والنظم", "CourseName 317", 4, 0 },
                    { "الهندسة الصناعية", "CourseName 303", 4, 0 },
                    { "الهندسة المدنية", "CourseName 289", 4, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 275", 4, 0 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 52", 1, 1 },
                    { "هندسة الحاسبات والنظم", "CourseName 261", 4, 0 },
                    { "الهندسة الميكانيكية", "CourseName 192", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 220", 1, 1 },
                    { "الهندسة الميكانيكية", "CourseName 126", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 112", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 98", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 84", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 70", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 56", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 42", 3, 1 },
                    { "الهندسة المعمارية", "CourseName 206", 2, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 28", 1, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 318", 4, 1 },
                    { "هندسة القوى الميكانيكية", "CourseName 304", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 290", 4, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 276", 4, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 262", 4, 1 },
                    { "هندسة القوى الميكانيكية", "CourseName 248", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 234", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 14", 2, 1 },
                    { "الهندسة الصناعية", "CourseName 247", 4, 0 },
                    { "الهندسة المدنية", "CourseName 233", 4, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 219", 3, 0 },
                    { "هندسة القوى الميكانيكية", "CourseName 232", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollments",
                columns: new[] { "BranchName", "CourseName", "LevelName", "Term" },
                values: new object[,]
                {
                    { "الهندسة المعمارية", "CourseName 218", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 204", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 190", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 176", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 162", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 148", 1, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 246", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 134", 2, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 106", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 92", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 78", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 64", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 50", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 36", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 22", 1, 1 },
                    { "الهندسة الميكانيكية", "CourseName 120", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 260", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 274", 4, 1 },
                    { "هندسة القوى الميكانيكية", "CourseName 288", 4, 1 },
                    { "الهندسة المدنية", "CourseName 205", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 191", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 177", 3, 0 },
                    { "الهندسة المدنية", "CourseName 163", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 149", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 135", 3, 0 },
                    { "الهندسة المدنية", "CourseName 121", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 107", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 93", 3, 0 },
                    { "الهندسة المدنية", "CourseName 79", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 65", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 51", 3, 0 },
                    { "الهندسة المدنية", "CourseName 37", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 23", 2, 0 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 9", 0, 0 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 316", 4, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 302", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 140", 2, 1 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 8", 0, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 154", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 182", 2, 1 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 11", 0, 0 },
                    { "الهندسة المدنية", "CourseName 321", 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollments",
                columns: new[] { "BranchName", "CourseName", "LevelName", "Term" },
                values: new object[,]
                {
                    { "هندسة القوى والآلات الكهربية", "CourseName 307", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 293", 4, 0 },
                    { "الهندسة الصناعية", "CourseName 279", 4, 0 },
                    { "الهندسة المدنية", "CourseName 265", 4, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 251", 4, 0 },
                    { "الهندسة المدنية", "CourseName 25", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 237", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 209", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 195", 3, 0 },
                    { "الهندسة المدنية", "CourseName 181", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 167", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 153", 3, 0 },
                    { "الهندسة المدنية", "CourseName 139", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 125", 2, 0 },
                    { "الهندسة المدنية", "CourseName 223", 1, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 111", 3, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 39", 3, 0 },
                    { "الهندسة المدنية", "CourseName 67", 1, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 291", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 277", 4, 0 },
                    { "الهندسة الصناعية", "CourseName 263", 4, 0 },
                    { "الهندسة المدنية", "CourseName 249", 4, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 235", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 221", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 207", 3, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 53", 2, 0 },
                    { "الهندسة المدنية", "CourseName 193", 1, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 165", 3, 0 },
                    { "الهندسة المدنية", "CourseName 151", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 137", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 123", 3, 0 },
                    { "الهندسة المدنية", "CourseName 109", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 95", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 81", 3, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 179", 2, 0 },
                    { "الهندسة المدنية", "CourseName 97", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 83", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 69", 3, 0 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 82", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 68", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 54", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 40", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollments",
                columns: new[] { "BranchName", "CourseName", "LevelName", "Term" },
                values: new object[,]
                {
                    { "الهندسة المعمارية", "CourseName 26", 2, 1 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 12", 0, 1 },
                    { "الهندسة المعمارية", "CourseName 322", 4, 1 },
                    { "الهندسة الميكانيكية", "CourseName 96", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 308", 4, 1 },
                    { "هندسة القوى الميكانيكية", "CourseName 280", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 266", 4, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 252", 4, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 238", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 224", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 210", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 196", 1, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 294", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 110", 2, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 124", 1, 1 },
                    { "الهندسة الميكانيكية", "CourseName 138", 3, 1 },
                    { "الهندسة المدنية", "CourseName 55", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 41", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 27", 3, 0 },
                    { "الهندسة المدنية", "CourseName 13", 1, 0 },
                    { "هندسة القوى الميكانيكية", "CourseName 320", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 306", 4, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 292", 4, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 278", 4, 1 },
                    { "هندسة القوى الميكانيكية", "CourseName 264", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 250", 4, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 236", 4, 1 },
                    { "الهندسة الميكانيكية", "CourseName 222", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 208", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 194", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 180", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 166", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 152", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 168", 3, 1 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 315", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 301", 4, 0 },
                    { "الهندسة الصناعية", "CourseName 287", 4, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 129", 3, 0 },
                    { "الهندسة المدنية", "CourseName 115", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 101", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 87", 3, 0 },
                    { "الهندسة المدنية", "CourseName 73", 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollments",
                columns: new[] { "BranchName", "CourseName", "LevelName", "Term" },
                values: new object[,]
                {
                    { "هندسة الحاسبات والنظم", "CourseName 59", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 45", 3, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 143", 2, 0 },
                    { "الهندسة المدنية", "CourseName 31", 1, 0 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 3", 0, 0 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 324", 4, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 310", 4, 1 },
                    { "هندسة القوى الميكانيكية", "CourseName 296", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 282", 4, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 268", 4, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 254", 4, 1 },
                    { "هندسة الحاسبات والنظم", "CourseName 17", 2, 0 },
                    { "هندسة القوى الميكانيكية", "CourseName 240", 4, 1 },
                    { "الهندسة المدنية", "CourseName 157", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 185", 2, 0 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 88", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 74", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 60", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 46", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 32", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 18", 3, 1 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 4", 0, 1 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 171", 3, 0 },
                    { "الهندسة الصناعية", "CourseName 311", 4, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 283", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 269", 4, 0 },
                    { "الهندسة الصناعية", "CourseName 255", 4, 0 },
                    { "الهندسة المدنية", "CourseName 241", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 227", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 213", 3, 0 },
                    { "الهندسة المدنية", "CourseName 199", 1, 0 },
                    { "الهندسة المدنية", "CourseName 297", 4, 0 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 226", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 212", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 198", 3, 1 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 225", 3, 0 },
                    { "الهندسة المدنية", "CourseName 211", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 197", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 183", 3, 0 },
                    { "الهندسة المدنية", "CourseName 169", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 155", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 141", 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollments",
                columns: new[] { "BranchName", "CourseName", "LevelName", "Term" },
                values: new object[,]
                {
                    { "الهندسة الصناعية", "CourseName 239", 4, 0 },
                    { "الهندسة المدنية", "CourseName 127", 1, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 99", 3, 0 },
                    { "الهندسة المدنية", "CourseName 85", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 71", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 57", 3, 0 },
                    { "الهندسة المدنية", "CourseName 43", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 29", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 15", 3, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 113", 2, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 253", 4, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 267", 4, 0 },
                    { "الهندسة المدنية", "CourseName 281", 4, 0 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 184", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 170", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 156", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 142", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 128", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 114", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 100", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 86", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 72", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 58", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 44", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 30", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 16", 1, 1 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 2", 0, 1 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 323", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 309", 4, 0 },
                    { "الهندسة الصناعية", "CourseName 295", 4, 0 },
                    { "الهندسة الميكانيكية", "CourseName 102", 3, 1 },
                    { "الهندسة المعمارية", "CourseName 116", 2, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 130", 1, 1 },
                    { "الهندسة الميكانيكية", "CourseName 144", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 300", 4, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 286", 4, 1 },
                    { "هندسة القوى الميكانيكية", "CourseName 272", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 258", 4, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 244", 4, 1 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 230", 4, 1 },
                    { "الهندسة الميكانيكية", "CourseName 216", 3, 1 },
                    { "الهندسة المعمارية", "CourseName 314", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollments",
                columns: new[] { "BranchName", "CourseName", "LevelName", "Term" },
                values: new object[,]
                {
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 202", 1, 1 },
                    { "الهندسة الميكانيكية", "CourseName 174", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 160", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 146", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 132", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 118", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 104", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 90", 3, 1 },
                    { "الهندسة المعمارية", "CourseName 188", 2, 1 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 7", 0, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 21", 3, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 35", 2, 0 },
                    { "الهندسة المدنية", "CourseName 273", 4, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 259", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 245", 4, 0 },
                    { "الهندسة الصناعية", "CourseName 231", 4, 0 },
                    { "الهندسة المدنية", "CourseName 217", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 203", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 189", 3, 0 },
                    { "الهندسة المدنية", "CourseName 175", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 161", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 147", 3, 0 },
                    { "الهندسة المدنية", "CourseName 133", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 119", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 105", 3, 0 },
                    { "الهندسة المدنية", "CourseName 91", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 77", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 63", 3, 0 },
                    { "الهندسة المدنية", "CourseName 49", 1, 0 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 76", 1, 1 },
                    { "الهندسة المدنية", "CourseName 305", 4, 0 },
                    { "الهندسة المعمارية", "CourseName 62", 2, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 34", 1, 1 },
                    { "هندسة الحاسبات والنظم", "CourseName 47", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 33", 3, 0 },
                    { "الهندسة المدنية", "CourseName 19", 1, 0 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 5", 0, 0 },
                    { "هندسة القوى الميكانيكية", "CourseName 312", 4, 1 },
                    { "الهندسة المعمارية", "CourseName 298", 4, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 284", 4, 1 },
                    { "الهندسة المدنية", "CourseName 61", 1, 0 },
                    { "هندسة الإنتاج والتصميم الميكانيكي", "CourseName 270", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollments",
                columns: new[] { "BranchName", "CourseName", "LevelName", "Term" },
                values: new object[,]
                {
                    { "الهندسة المعمارية", "CourseName 242", 4, 1 },
                    { "الهندسة الميكانيكية", "CourseName 228", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 214", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 200", 2, 1 },
                    { "الهندسة الميكانيكية", "CourseName 186", 3, 1 },
                    { "هندسة الإلكترونيات والاتصالات الكهربية", "CourseName 172", 1, 1 },
                    { "الهندسة المعمارية", "CourseName 158", 2, 1 },
                    { "هندسة القوى الميكانيكية", "CourseName 256", 4, 1 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 75", 3, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 89", 2, 0 },
                    { "الهندسة المدنية", "CourseName 103", 1, 0 },
                    { "الهندسة المعمارية", "CourseName 20", 2, 1 },
                    { "الرياضيات والفيزيقا الهندسية", "CourseName 6", 0, 1 },
                    { "الهندسة المدنية", "CourseName 313", 4, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 299", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 285", 4, 0 },
                    { "الهندسة الصناعية", "CourseName 271", 4, 0 },
                    { "الهندسة المدنية", "CourseName 257", 4, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 243", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 229", 4, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 215", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 201", 3, 0 },
                    { "الهندسة المدنية", "CourseName 187", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 173", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 159", 3, 0 },
                    { "الهندسة المدنية", "CourseName 145", 1, 0 },
                    { "هندسة الحاسبات والنظم", "CourseName 131", 2, 0 },
                    { "هندسة القوى والآلات الكهربية", "CourseName 117", 3, 0 },
                    { "الهندسة الميكانيكية", "CourseName 48", 3, 1 },
                    { "الهندسة الصناعية", "CourseName 319", 4, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DepartmentName",
                table: "Branches",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_BranchName",
                table: "CourseEnrollments",
                column: "BranchName");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentCodeValue",
                table: "Courses",
                column: "DepartmentCodeValue");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentCodes_DepartmentName",
                table: "DepartmentCodes",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorEnrollments_AcademicYearID",
                table: "InstructorEnrollments",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorEnrollments_CourseName_BranchName",
                table: "InstructorEnrollments",
                columns: new[] { "CourseName", "BranchName" });

            migrationBuilder.CreateIndex(
                name: "IX_InstructorEnrollments_InstructorNatId",
                table: "InstructorEnrollments",
                column: "InstructorNatId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorProfessions_InstructorNatId",
                table: "InstructorProfessions",
                column: "InstructorNatId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_DepartmentName",
                table: "Instructors",
                column: "DepartmentName");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_AcademicYearID",
                table: "Selection",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_CurrentBranchName",
                table: "Selection",
                column: "CurrentBranchName");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_SelectionBranchName",
                table: "Selection",
                column: "SelectionBranchName");

            migrationBuilder.CreateIndex(
                name: "IX_Selection_StudentNatId_AcademicYearID",
                table: "Selection",
                columns: new[] { "StudentNatId", "AcademicYearID" });

            migrationBuilder.CreateIndex(
                name: "IX_Selection_StudentNatId1",
                table: "Selection",
                column: "StudentNatId1");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseName_BranchName",
                table: "StudentCourses",
                columns: new[] { "CourseName", "BranchName" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentNatId_AcademicYearID",
                table: "StudentCourses",
                columns: new[] { "StudentNatId", "AcademicYearID" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_AcademicYearID",
                table: "StudentEnrollments",
                column: "AcademicYearID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEnrollments_BranchName",
                table: "StudentEnrollments",
                column: "BranchName");

            migrationBuilder.CreateIndex(
                name: "IX_Students_BranchName1",
                table: "Students",
                column: "BranchName1");
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
                name: "InstructorEnrollments");

            migrationBuilder.DropTable(
                name: "InstructorProfessions");

            migrationBuilder.DropTable(
                name: "Selection");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "CourseEnrollments");

            migrationBuilder.DropTable(
                name: "StudentEnrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AcademicYears");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "DepartmentCodes");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
