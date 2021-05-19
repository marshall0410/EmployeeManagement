using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class ModifiedDataTypeAndRemovedFieldPayrollTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payroll_Employee_EmployeeId1",
                table: "Payroll");

            migrationBuilder.DropIndex(
                name: "IX_Payroll_EmployeeId1",
                table: "Payroll");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Payroll");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Payroll");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Payroll",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AbsenceTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Called In" },
                    { 2, "Sick" },
                    { 3, "Optional" },
                    { 4, "Vacation" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Human Resources" },
                    { 2, "Information Technology" },
                    { 3, "Accounting" },
                    { 4, "Operations" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "5b736860-81b6-4f09-bf2b-bc1da8427fe8", 2, "george@gmail.com", true, true, null, null, null, null, "9149526677", false, "e14d25d4-1b2f-4791-8c92-6a6313187a24", false, "george@gmail.com" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "c7c154aa-af00-4d49-a155-b0a6999fd7ac", 2, "smith@gmail.com", true, true, null, null, null, null, "9149526588", false, "715ee4b7-a6a1-4326-8670-ba797e29cb3e", false, "smith@gmail.com" });

            migrationBuilder.InsertData(
                table: "Absences",
                columns: new[] { "Id", "AbsenceTypeId", "EmployeeId", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 1L, 2, "1", new DateTime(2021, 4, 6, 9, 59, 40, 167, DateTimeKind.Local).AddTicks(8486), new DateTime(2021, 4, 3, 9, 59, 40, 165, DateTimeKind.Local).AddTicks(5427) },
                    { 2L, 4, "2", new DateTime(2021, 4, 6, 9, 59, 40, 167, DateTimeKind.Local).AddTicks(9443), new DateTime(2021, 4, 3, 9, 59, 40, 167, DateTimeKind.Local).AddTicks(9430) }
                });

            migrationBuilder.InsertData(
                table: "Grievances",
                columns: new[] { "Id", "Body", "DateAnswered", "DateSubmitted", "EmployeeId", "RespondantId" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(2021, 3, 31, 9, 59, 40, 168, DateTimeKind.Local).AddTicks(1736), new DateTime(2021, 3, 30, 9, 59, 40, 168, DateTimeKind.Local).AddTicks(1309), "2", "1" },
                    { 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", new DateTime(2021, 4, 3, 9, 59, 40, 168, DateTimeKind.Local).AddTicks(2963), new DateTime(2021, 4, 2, 9, 59, 40, 168, DateTimeKind.Local).AddTicks(2954), "2", "1" }
                });

            migrationBuilder.InsertData(
                table: "Payroll",
                columns: new[] { "Id", "EmployeeId", "Month", "PaidSalary", "Year" },
                values: new object[,]
                {
                    { 1L, "1", (short)5, 2698.08f, (short)2020 },
                    { 2L, "1", (short)6, 2698.08f, (short)0 },
                    { 3L, "2", (short)6, 3498.08f, (short)0 },
                    { 4L, "2", (short)7, 3498.08f, (short)0 }
                });

            migrationBuilder.InsertData(
                table: "Salaries",
                columns: new[] { "Id", "Allowance", "AnnualSalary", "EmployeeId", "GrossSalary", "NetSalary", "Tax" },
                values: new object[,]
                {
                    { 1, 0f, 32376.96f, "1", 44652.43f, 37376.96f, 5.05f },
                    { 2, 0f, 41976.96f, "1", 53552.43f, 46576.96f, 5.05f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_EmployeeId",
                table: "Payroll",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payroll_Employee_EmployeeId",
                table: "Payroll",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payroll_Employee_EmployeeId",
                table: "Payroll");

            migrationBuilder.DropIndex(
                name: "IX_Payroll_EmployeeId",
                table: "Payroll");

            migrationBuilder.DeleteData(
                table: "AbsenceTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AbsenceTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Payroll",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Payroll",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Payroll",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Payroll",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Salaries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AbsenceTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AbsenceTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Payroll",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Payroll",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "Payroll",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_EmployeeId1",
                table: "Payroll",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Payroll_Employee_EmployeeId1",
                table: "Payroll",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
