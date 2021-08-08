using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagement.Migrations
{
    public partial class UpdatedLeaveTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LeaveApplications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "LeaveApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "LeaveApplications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "LeaveApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_EmployeeId",
                table: "LeaveApplications",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_AspNetUsers_EmployeeId",
                table: "LeaveApplications",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_AspNetUsers_EmployeeId",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_EmployeeId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "LeaveApplications");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LeaveApplications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
