using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class AddedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payroll_Employees_EmployeeId",
                table: "Payroll");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employees_EmployeeId",
                table: "Salaries");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Salaries",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Payroll",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 5, 7, 17, 42, 0, 855, DateTimeKind.Local).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2021, 5, 10, 17, 42, 0, 857, DateTimeKind.Local).AddTicks(6387));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6f3489a4-bc6d-492f-9ebb-e1ed1d851b3e", "09d6f2f0-deea-4537-9be7-7a38a9ae84ab" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3fd6fc31-f81f-4691-8ca6-223fa4948a89", "5e6e21a5-94c2-4445-8dc6-ac751205fff9" });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 5, 4, 17, 42, 0, 857, DateTimeKind.Local).AddTicks(8502), new DateTime(2021, 5, 3, 17, 42, 0, 857, DateTimeKind.Local).AddTicks(8079) });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 5, 7, 17, 42, 0, 857, DateTimeKind.Local).AddTicks(9694), new DateTime(2021, 5, 6, 17, 42, 0, 857, DateTimeKind.Local).AddTicks(9684) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ecba666-f093-4510-81ad-2d8eb1dd943b", "55f40eb2-e4bc-4efb-a00d-36c72fba4ef4", "User", null },
                    { "a90e80b9-21e8-432e-a657-6ed0a81055b9", "ddeda458-55f6-4ea7-9cc3-35f9fc0151db", "Admin", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Payroll_Employees_EmployeeId",
                table: "Payroll",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employees_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payroll_Employees_EmployeeId",
                table: "Payroll");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employees_EmployeeId",
                table: "Salaries");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7ecba666-f093-4510-81ad-2d8eb1dd943b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a90e80b9-21e8-432e-a657-6ed0a81055b9");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Salaries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Payroll",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 4, 16, 20, 50, 32, 474, DateTimeKind.Local).AddTicks(4053));

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2021, 4, 19, 20, 50, 32, 476, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "150ce72a-1a32-47ca-875d-d066166d093c", "f31096df-b88c-4576-b61d-7927722094fe" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "efed77c4-6388-4caf-81d0-5f7f31821cc6", "110f4c13-2a50-4e8c-87a7-5e2903066ce7" });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 4, 13, 20, 50, 32, 476, DateTimeKind.Local).AddTicks(7461), new DateTime(2021, 4, 12, 20, 50, 32, 476, DateTimeKind.Local).AddTicks(7032) });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 4, 16, 20, 50, 32, 476, DateTimeKind.Local).AddTicks(8588), new DateTime(2021, 4, 15, 20, 50, 32, 476, DateTimeKind.Local).AddTicks(8578) });

            migrationBuilder.AddForeignKey(
                name: "FK_Payroll_Employees_EmployeeId",
                table: "Payroll",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employees_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
