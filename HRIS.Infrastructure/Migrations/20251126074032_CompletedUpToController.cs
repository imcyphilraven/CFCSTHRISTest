using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRIS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CompletedUpToController : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                schema: "hris",
                table: "Employees",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 2,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 3,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 4,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 5,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 6,
                column: "IsActive",
                value: true);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 7,
                column: "IsActive",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                schema: "hris",
                table: "Employees");

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 1,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 2,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 3,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 4,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 5,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 6,
                column: "IsActive",
                value: false);

            migrationBuilder.UpdateData(
                schema: "lookup",
                table: "IdentificationTypes",
                keyColumn: "IdentificationTypeID",
                keyValue: 7,
                column: "IsActive",
                value: false);
        }
    }
}
