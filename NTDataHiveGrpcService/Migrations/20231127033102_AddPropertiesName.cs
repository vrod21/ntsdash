using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QA",
                table: "PreEditingErrorFeedbacks",
                newName: "QualityAssurance");

            migrationBuilder.RenameColumn(
                name: "Employee",
                table: "PreEditingErrorFeedbacks",
                newName: "EmployeeName");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "PreEditingErrorFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.RenameColumn(
                name: "QualityAssurance",
                table: "PreEditingErrorFeedbacks",
                newName: "QA");

            migrationBuilder.RenameColumn(
                name: "EmployeeName",
                table: "PreEditingErrorFeedbacks",
                newName: "Employee");
        }
    }
}
