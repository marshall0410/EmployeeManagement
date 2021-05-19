using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class ModifiedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Employee_EmployeeId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Departments_DepartmentId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Grievances_Employee_EmployeeId",
                table: "Grievances");

            migrationBuilder.DropForeignKey(
                name: "FK_Grievances_Employee_RespondantId",
                table: "Grievances");

            migrationBuilder.DropForeignKey(
                name: "FK_Payroll_Employee_EmployeeId",
                table: "Payroll");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_claim_Role_RoleId",
                table: "Role_claim");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employee_EmployeeId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_User_claim_Employee_UserId",
                table: "User_claim");

            migrationBuilder.DropForeignKey(
                name: "FK_User_login_Employee_UserId",
                table: "User_login");

            migrationBuilder.DropForeignKey(
                name: "FK_User_role_Employee_UserId",
                table: "User_role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_role_Role_RoleId",
                table: "User_role");

            migrationBuilder.DropForeignKey(
                name: "FK_User_token_Employee_UserId",
                table: "User_token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_token",
                table: "User_token");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_role",
                table: "User_role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_login",
                table: "User_login");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_claim",
                table: "User_claim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role_claim",
                table: "Role_claim");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "User_token",
                newName: "UserTokens");

            migrationBuilder.RenameTable(
                name: "User_role",
                newName: "UserRoles");

            migrationBuilder.RenameTable(
                name: "User_login",
                newName: "UserLogins");

            migrationBuilder.RenameTable(
                name: "User_claim",
                newName: "UserClaims");

            migrationBuilder.RenameTable(
                name: "Role_claim",
                newName: "RoleClaims");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_User_role_RoleId",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_User_login_UserId",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_User_claim_UserId",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Role_claim_RoleId",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Employees_EmployeeId",
                table: "Absences",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grievances_Employees_EmployeeId",
                table: "Grievances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grievances_Employees_RespondantId",
                table: "Grievances",
                column: "RespondantId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payroll_Employees_EmployeeId",
                table: "Payroll",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employees_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_Employees_UserId",
                table: "UserClaims",
                column: "UserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_Employees_UserId",
                table: "UserLogins",
                column: "UserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Employees_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_Employees_UserId",
                table: "UserTokens",
                column: "UserId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Employees_EmployeeId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Grievances_Employees_EmployeeId",
                table: "Grievances");

            migrationBuilder.DropForeignKey(
                name: "FK_Grievances_Employees_RespondantId",
                table: "Grievances");

            migrationBuilder.DropForeignKey(
                name: "FK_Payroll_Employees_EmployeeId",
                table: "Payroll");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Roles_RoleId",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employees_EmployeeId",
                table: "Salaries");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_Employees_UserId",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_Employees_UserId",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Employees_UserId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_Employees_UserId",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                table: "RoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                newName: "User_token");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                newName: "User_role");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                newName: "User_login");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                newName: "User_claim");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                newName: "Role_claim");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "User_role",
                newName: "IX_User_role_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                table: "User_login",
                newName: "IX_User_login_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                table: "User_claim",
                newName: "IX_User_claim_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                table: "Role_claim",
                newName: "IX_Role_claim_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employee",
                newName: "IX_Employee_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_token",
                table: "User_token",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_role",
                table: "User_role",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_login",
                table: "User_login",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_claim",
                table: "User_claim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role_claim",
                table: "Role_claim",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 4, 6, 9, 59, 40, 167, DateTimeKind.Local).AddTicks(8486), new DateTime(2021, 4, 3, 9, 59, 40, 165, DateTimeKind.Local).AddTicks(5427) });

            migrationBuilder.UpdateData(
                table: "Absences",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 4, 6, 9, 59, 40, 167, DateTimeKind.Local).AddTicks(9443), new DateTime(2021, 4, 3, 9, 59, 40, 167, DateTimeKind.Local).AddTicks(9430) });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5b736860-81b6-4f09-bf2b-bc1da8427fe8", "e14d25d4-1b2f-4791-8c92-6a6313187a24" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c7c154aa-af00-4d49-a155-b0a6999fd7ac", "715ee4b7-a6a1-4326-8670-ba797e29cb3e" });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 3, 31, 9, 59, 40, 168, DateTimeKind.Local).AddTicks(1736), new DateTime(2021, 3, 30, 9, 59, 40, 168, DateTimeKind.Local).AddTicks(1309) });

            migrationBuilder.UpdateData(
                table: "Grievances",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAnswered", "DateSubmitted" },
                values: new object[] { new DateTime(2021, 4, 3, 9, 59, 40, 168, DateTimeKind.Local).AddTicks(2963), new DateTime(2021, 4, 2, 9, 59, 40, 168, DateTimeKind.Local).AddTicks(2954) });

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Employee_EmployeeId",
                table: "Absences",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Departments_DepartmentId",
                table: "Employee",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grievances_Employee_EmployeeId",
                table: "Grievances",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grievances_Employee_RespondantId",
                table: "Grievances",
                column: "RespondantId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payroll_Employee_EmployeeId",
                table: "Payroll",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_claim_Role_RoleId",
                table: "Role_claim",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employee_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_claim_Employee_UserId",
                table: "User_claim",
                column: "UserId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_login_Employee_UserId",
                table: "User_login",
                column: "UserId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_role_Employee_UserId",
                table: "User_role",
                column: "UserId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_role_Role_RoleId",
                table: "User_role",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_token_Employee_UserId",
                table: "User_token",
                column: "UserId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
