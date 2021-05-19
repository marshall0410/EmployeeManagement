using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class UpdatedIdentityRoleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceCodes");

            migrationBuilder.DropTable(
                name: "PersistedGrants");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7ecba666-f093-4510-81ad-2d8eb1dd943b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a90e80b9-21e8-432e-a657-6ed0a81055b9");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Date",
                value: new DateTime(2021, 5, 15, 4, 11, 33, 500, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Date",
                value: new DateTime(2021, 5, 18, 4, 11, 33, 502, DateTimeKind.Local).AddTicks(9505));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "96d75242-3359-48e9-98e4-799ce6cfc9b2", "9cf00be8-f13a-4fb4-8b5d-ad4ad317a753" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fbb78d78-af20-4df4-866f-ed56eadd7ac1", "dd6f0054-625c-437a-b8a0-8277982d3353" });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 5, 12, 4, 11, 33, 503, DateTimeKind.Local).AddTicks(2172), new DateTime(2021, 5, 11, 4, 11, 33, 503, DateTimeKind.Local).AddTicks(1689) });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 5, 15, 4, 11, 33, 503, DateTimeKind.Local).AddTicks(3482), new DateTime(2021, 5, 14, 4, 11, 33, 503, DateTimeKind.Local).AddTicks(3471) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c62a9c3-fd47-4f40-ad3c-b1ae1910d399", "394c0e74-ee1c-4faf-b9f5-1a1a3f3701fa", "User", "USER" },
                    { "4759f383-5322-435f-9b2c-ee98632b6b33", "3d93ef29-623d-426b-9897-ce0dc5a201d5", "Admin", "ADMIN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4759f383-5322-435f-9b2c-ee98632b6b33");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6c62a9c3-fd47-4f40-ad3c-b1ae1910d399");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "DeviceCodes",
                columns: table => new
                {
                    UserCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DeviceCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
                });

            migrationBuilder.CreateTable(
                name: "PersistedGrants",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ConsumedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", maxLength: 50000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubjectId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersistedGrants", x => x.Key);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_DeviceCode",
                table: "DeviceCodes",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeviceCodes_Expiration",
                table: "DeviceCodes",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_Expiration",
                table: "PersistedGrants",
                column: "Expiration");

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_ClientId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "ClientId", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_PersistedGrants_SubjectId_SessionId_Type",
                table: "PersistedGrants",
                columns: new[] { "SubjectId", "SessionId", "Type" });
        }
    }
}
