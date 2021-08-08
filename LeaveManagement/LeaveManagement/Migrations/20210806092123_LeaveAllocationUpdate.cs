using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeaveManagement.Migrations
{
    public partial class LeaveAllocationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_AspNetUsers_EmployeeId",
                table: "LeaveApplications");

            migrationBuilder.DropTable(
                name: "UserLeaves");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "LeaveApplications",
                newName: "ApprovedById");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveApplications_EmployeeId",
                table: "LeaveApplications",
                newName: "IX_LeaveApplications_ApprovedById");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "LeaveTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LeaveApplications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "LeaveApplications",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Cancelled",
                table: "LeaveApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateActioned",
                table: "LeaveApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRequested",
                table: "LeaveApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RequestComments",
                table: "LeaveApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "LeaveAllocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveAllocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveAllocations_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveAllocations_LeaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_LeaveTypeId",
                table: "LeaveApplications",
                column: "LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_UserId",
                table: "LeaveApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocations_EmployeeId",
                table: "LeaveAllocations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocations_LeaveTypeId",
                table: "LeaveAllocations",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_AspNetUsers_ApprovedById",
                table: "LeaveApplications",
                column: "ApprovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_AspNetUsers_UserId",
                table: "LeaveApplications",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_LeaveTypes_LeaveTypeId",
                table: "LeaveApplications",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_AspNetUsers_ApprovedById",
                table: "LeaveApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_AspNetUsers_UserId",
                table: "LeaveApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_LeaveTypes_LeaveTypeId",
                table: "LeaveApplications");

            migrationBuilder.DropTable(
                name: "LeaveAllocations");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_LeaveTypeId",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_UserId",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "Cancelled",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "DateActioned",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "DateRequested",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "RequestComments",
                table: "LeaveApplications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ApprovedById",
                table: "LeaveApplications",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveApplications_ApprovedById",
                table: "LeaveApplications",
                newName: "IX_LeaveApplications_EmployeeId");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LeaveApplications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserLeaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    RemainingLeaveDays = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLeaves", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_AspNetUsers_EmployeeId",
                table: "LeaveApplications",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
