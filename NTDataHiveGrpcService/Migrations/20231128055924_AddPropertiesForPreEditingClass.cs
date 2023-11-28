using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesForPreEditingClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CopyEditedBy",
                table: "PreEditingErrorFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorrectiveAction",
                table: "PreEditingErrorFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NatureOfCA",
                table: "PreEditingErrorFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NatureOfPM",
                table: "PreEditingErrorFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerOfCA",
                table: "PreEditingErrorFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreventiveMeasure",
                table: "PreEditingErrorFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RootCause",
                table: "PreEditingErrorFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusOfCA",
                table: "PreEditingErrorFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusOfPM",
                table: "PreEditingErrorFeedbacks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TargetDateOfCompletionCA",
                table: "PreEditingErrorFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TargetDateOfCompletionPM",
                table: "PreEditingErrorFeedbacks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CopyEditedBy",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.DropColumn(
                name: "CorrectiveAction",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.DropColumn(
                name: "NatureOfCA",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.DropColumn(
                name: "NatureOfPM",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.DropColumn(
                name: "OwnerOfCA",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.DropColumn(
                name: "PreventiveMeasure",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.DropColumn(
                name: "RootCause",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.DropColumn(
                name: "StatusOfCA",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.DropColumn(
                name: "StatusOfPM",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.DropColumn(
                name: "TargetDateOfCompletionCA",
                table: "PreEditingErrorFeedbacks");

            migrationBuilder.DropColumn(
                name: "TargetDateOfCompletionPM",
                table: "PreEditingErrorFeedbacks");
        }
    }
}
