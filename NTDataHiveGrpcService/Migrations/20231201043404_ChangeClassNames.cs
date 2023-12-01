using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    /// <inheritdoc />
    public partial class ChangeClassNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreEditingErrorFeedbacks");

            migrationBuilder.CreateTable(
                name: "PreEditing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityAssurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    ErrorCount = table.Column<int>(type: "int", nullable: false),
                    DescriptionOfError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorSubtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroducedOrMissed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectiveAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureOfCA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerOfCA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetDateOfCompletionCA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreventiveMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureOfPM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetDateOfCompletionPM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusOfCA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusOfPM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditingLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreEditing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityAssurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    ErrorCount = table.Column<int>(type: "int", nullable: false),
                    DescriptionOfError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorSubtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroducedOrMissed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditingLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revisions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreEditing");

            migrationBuilder.DropTable(
                name: "Revisions");

            migrationBuilder.CreateTable(
                name: "PreEditingErrorFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditingLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CorrectiveAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionOfError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCount = table.Column<int>(type: "int", nullable: false),
                    ErrorLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorSubtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroducedOrMissed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureOfCA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NatureOfPM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerOfCA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    PreventiveMeasure = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityAssurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootCause = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusOfCA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusOfPM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TargetDateOfCompletionCA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargetDateOfCompletionPM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreEditingErrorFeedbacks", x => x.Id);
                });
        }
    }
}
