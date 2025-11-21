using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "lookup");

            migrationBuilder.EnsureSchema(
                name: "hris");

            migrationBuilder.CreateTable(
                name: "CivilStatuses",
                schema: "lookup",
                columns: table => new
                {
                    CivilStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StatusCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivilStatuses", x => x.CivilStatusID);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationTypes",
                schema: "lookup",
                columns: table => new
                {
                    IdentificationTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationTypes", x => x.IdentificationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "hris",
                columns: table => new
                {
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmploymentID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExtensionName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SexAtBirth = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    CivilStatusID = table.Column<int>(type: "int", nullable: false),
                    IsFilipino = table.Column<bool>(type: "bit", nullable: false),
                    IsDualCitizen = table.Column<bool>(type: "bit", nullable: false),
                    ImageSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_CivilStatuses_CivilStatusID",
                        column: x => x.CivilStatusID,
                        principalSchema: "lookup",
                        principalTable: "CivilStatuses",
                        principalColumn: "CivilStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIdentifications",
                schema: "hris",
                columns: table => new
                {
                    EmployeeIdentificationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentificationTypeID = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IssuedPlace = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeIdentifications", x => x.EmployeeIdentificationID);
                    table.ForeignKey(
                        name: "FK_EmployeeIdentifications_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalSchema: "hris",
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeIdentifications_IdentificationTypes_IdentificationTypeID",
                        column: x => x.IdentificationTypeID,
                        principalSchema: "lookup",
                        principalTable: "IdentificationTypes",
                        principalColumn: "IdentificationTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIdentifications_EmployeeID_IdentificationTypeID",
                schema: "hris",
                table: "EmployeeIdentifications",
                columns: new[] { "EmployeeID", "IdentificationTypeID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeIdentifications_IdentificationTypeID",
                schema: "hris",
                table: "EmployeeIdentifications",
                column: "IdentificationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CivilStatusID",
                schema: "hris",
                table: "Employees",
                column: "CivilStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmploymentID",
                schema: "hris",
                table: "Employees",
                column: "EmploymentID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeIdentifications",
                schema: "hris");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "hris");

            migrationBuilder.DropTable(
                name: "IdentificationTypes",
                schema: "lookup");

            migrationBuilder.DropTable(
                name: "CivilStatuses",
                schema: "lookup");
        }
    }
}
