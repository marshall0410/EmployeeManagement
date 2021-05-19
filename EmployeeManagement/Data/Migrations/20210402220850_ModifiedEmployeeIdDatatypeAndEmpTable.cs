using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Data.Migrations
{
    public partial class ModifiedEmployeeIdDatatypeAndEmpTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Employee_EmployeeId1",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employee_EmployeeId1",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_EmployeeId1",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Absences_EmployeeId1",
                table: "Absences");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Absences");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Salaries",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "Absences",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_EmployeeId",
                table: "Absences",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Employee_EmployeeId",
                table: "Absences",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employee_EmployeeId",
                table: "Salaries",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            //Manually added this column.
            migrationBuilder.AddColumn<string>(
                name: "HiredDate",
                table: "Employee",
                type: "Datetime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Absences_Employee_EmployeeId",
                table: "Absences");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Employee_EmployeeId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Salaries_EmployeeId",
                table: "Salaries");

            migrationBuilder.DropIndex(
                name: "IX_Absences_EmployeeId",
                table: "Absences");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Salaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "Salaries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Absences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "Absences",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeId1",
                table: "Salaries",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_EmployeeId1",
                table: "Absences",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Absences_Employee_EmployeeId1",
                table: "Absences",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Employee_EmployeeId1",
                table: "Salaries",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
