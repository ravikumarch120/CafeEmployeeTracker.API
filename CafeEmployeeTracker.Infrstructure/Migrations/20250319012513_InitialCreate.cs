using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeEmployeeTracker.Infrstructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCafe_Cafes_CafeId",
                table: "EmployeeCafe");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCafe_Employee_EmployeeId",
                table: "EmployeeCafe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeCafe",
                table: "EmployeeCafe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeCafe",
                newName: "EmployeeCafes");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCafe_EmployeeId",
                table: "EmployeeCafes",
                newName: "IX_EmployeeCafes_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCafe_CafeId",
                table: "EmployeeCafes",
                newName: "IX_EmployeeCafes_CafeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeCafes",
                table: "EmployeeCafes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCafes_Cafes_CafeId",
                table: "EmployeeCafes",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCafes_Employees_EmployeeId",
                table: "EmployeeCafes",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCafes_Cafes_CafeId",
                table: "EmployeeCafes");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeCafes_Employees_EmployeeId",
                table: "EmployeeCafes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeCafes",
                table: "EmployeeCafes");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeCafes",
                newName: "EmployeeCafe");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCafes_EmployeeId",
                table: "EmployeeCafe",
                newName: "IX_EmployeeCafe_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeCafes_CafeId",
                table: "EmployeeCafe",
                newName: "IX_EmployeeCafe_CafeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeCafe",
                table: "EmployeeCafe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCafe_Cafes_CafeId",
                table: "EmployeeCafe",
                column: "CafeId",
                principalTable: "Cafes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeCafe_Employee_EmployeeId",
                table: "EmployeeCafe",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
