using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class ModifiedGrievance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grievances_Employee_EmployeeId1",
                table: "Grievances");

            migrationBuilder.DropForeignKey(
                name: "FK_Grievances_Employee_RespondantId1",
                table: "Grievances");

            migrationBuilder.DropIndex(
                name: "IX_Grievances_EmployeeId1",
                table: "Grievances");

            migrationBuilder.DropIndex(
                name: "IX_Grievances_RespondantId1",
                table: "Grievances");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Grievances");

            migrationBuilder.DropColumn(
                name: "RespondantId1",
                table: "Grievances");

            migrationBuilder.AlterColumn<string>(
                name: "RespondantId",
                table: "Grievances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Grievances",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Grievances_EmployeeId",
                table: "Grievances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Grievances_RespondantId",
                table: "Grievances",
                column: "RespondantId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grievances_Employee_EmployeeId",
                table: "Grievances");

            migrationBuilder.DropForeignKey(
                name: "FK_Grievances_Employee_RespondantId",
                table: "Grievances");

            migrationBuilder.DropIndex(
                name: "IX_Grievances_EmployeeId",
                table: "Grievances");

            migrationBuilder.DropIndex(
                name: "IX_Grievances_RespondantId",
                table: "Grievances");

            migrationBuilder.AlterColumn<int>(
                name: "RespondantId",
                table: "Grievances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Grievances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "Grievances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RespondantId1",
                table: "Grievances",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grievances_EmployeeId1",
                table: "Grievances",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Grievances_RespondantId1",
                table: "Grievances",
                column: "RespondantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Grievances_Employee_EmployeeId1",
                table: "Grievances",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Grievances_Employee_RespondantId1",
                table: "Grievances",
                column: "RespondantId1",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
