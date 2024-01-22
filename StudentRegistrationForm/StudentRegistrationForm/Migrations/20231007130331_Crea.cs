using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentRegistrationForm.Migrations
{
    /// <inheritdoc />
    public partial class Crea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_addresses_country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    StateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.StateID);
                    table.ForeignKey(
                        name: "FK_states_country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_city_states_StateID",
                        column: x => x.StateID,
                        principalTable: "states",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reservation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupToStudy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualifyingExamination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Board = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HallTicketNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonthYearOfPassing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AverageMarks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PreferredCollegeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAddressID = table.Column<int>(type: "int", nullable: false),
                    PermanentAddressID = table.Column<int>(type: "int", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    StateID = table.Column<int>(type: "int", nullable: false),
                    CityID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_students_addresses_CurrentAddressID",
                        column: x => x.CurrentAddressID,
                        principalTable: "addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_students_addresses_PermanentAddressID",
                        column: x => x.PermanentAddressID,
                        principalTable: "addresses",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_students_city_CityID",
                        column: x => x.CityID,
                        principalTable: "city",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_students_country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_students_states_StateID",
                        column: x => x.StateID,
                        principalTable: "states",
                        principalColumn: "StateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marks = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.SubjectID);
                    table.ForeignKey(
                        name: "FK_subjects_students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "country",
                columns: new[] { "CountryID", "Name" },
                values: new object[,]
                {
                    { 1, "India" },
                    { 2, "Japan" }
                });

            migrationBuilder.InsertData(
                table: "states",
                columns: new[] { "StateID", "CityID", "CountryID", "StateName" },
                values: new object[,]
                {
                    { 1, 0, 1, "Hyderabad" },
                    { 2, 0, 1, "Mumbai" }
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "CityID", "CityName", "StateID" },
                values: new object[,]
                {
                    { 1, "Tokyo", 1 },
                    { 2, "Japanese", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_CountryID",
                table: "addresses",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_city_StateID",
                table: "city",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_states_CountryID",
                table: "states",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_students_CityID",
                table: "students",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_students_CountryID",
                table: "students",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_students_CurrentAddressID",
                table: "students",
                column: "CurrentAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_students_PermanentAddressID",
                table: "students",
                column: "PermanentAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_students_StateID",
                table: "students",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_StudentID",
                table: "subjects",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
