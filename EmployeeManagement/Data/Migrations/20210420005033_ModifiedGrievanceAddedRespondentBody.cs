using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class ModifiedGrievanceAddedRespondentBody : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Employees_EmployeeId",
                table: "Absences");

            migrationBuilder.AddColumn<string>(
                name: "RespondentBody",
                table: "Grievances",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbsenceTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Absences",
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
                name: "FK_Absences_Employees_EmployeeId",
                table: "Absences",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Employees_EmployeeId",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "RespondentBody",
                table: "Grievances");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbsenceTypes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Absences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 4, 11, 2, 6, 49, 218, DateTimeKind.Local).AddTicks(6301));

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2021, 4, 14, 2, 6, 49, 221, DateTimeKind.Local).AddTicks(440));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "526a2d7d-57bb-41a6-bec2-de73ad0ff7cf", "2aa9ba10-989e-47be-8171-e04c6b52bba1" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4e4a424c-6f0f-4738-8f03-d9e0972b677b", "810b94a2-9002-48e9-8e9d-2e249e437a51" });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 4, 8, 2, 6, 49, 221, DateTimeKind.Local).AddTicks(1814), new DateTime(2021, 4, 7, 2, 6, 49, 221, DateTimeKind.Local).AddTicks(1585) });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 4, 11, 2, 6, 49, 221, DateTimeKind.Local).AddTicks(2362), new DateTime(2021, 4, 10, 2, 6, 49, 221, DateTimeKind.Local).AddTicks(2352) });

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Employees_EmployeeId",
                table: "Absences",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
