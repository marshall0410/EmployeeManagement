using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class AbsenceRemovedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Absences");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Absences",
                newName: "Date");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Absences",
                newName: "StartTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Absences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 4, 10, 22, 48, 18, 643, DateTimeKind.Local).AddTicks(5478), new DateTime(2021, 4, 7, 22, 48, 18, 640, DateTimeKind.Local).AddTicks(8597) });

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 4, 10, 22, 48, 18, 643, DateTimeKind.Local).AddTicks(6720), new DateTime(2021, 4, 7, 22, 48, 18, 643, DateTimeKind.Local).AddTicks(6702) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fb4ea8c2-4673-4b4b-89ab-8cb3d086d4b1", "385eae5e-2565-4b1d-84d9-085c880d4fea" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a2a38f71-e7e3-4359-9feb-3ef2205f898b", "fe3ed8fb-f2c7-4b02-8c9e-05e76aed09aa" });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 4, 4, 22, 48, 18, 643, DateTimeKind.Local).AddTicks(9805), new DateTime(2021, 4, 3, 22, 48, 18, 643, DateTimeKind.Local).AddTicks(9067) });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 4, 7, 22, 48, 18, 644, DateTimeKind.Local).AddTicks(1218), new DateTime(2021, 4, 6, 22, 48, 18, 644, DateTimeKind.Local).AddTicks(1206) });
        }
    }
}
