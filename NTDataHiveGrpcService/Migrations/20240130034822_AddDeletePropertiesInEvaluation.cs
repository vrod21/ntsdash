using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    /// <inheritdoc />
    public partial class AddDeletePropertiesInEvaluation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Error");

            migrationBuilder.DropTable(
                name: "PersonType");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "PreEditing");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Revision");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                table: "Evaluation",
                newName: "Stage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Stage",
                table: "Evaluation",
                newName: "SupplierName");

            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    CreditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditingLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityAssurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.CreditId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScoreCard = table.Column<int>(type: "int", nullable: false),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Error",
                columns: table => new
                {
                    ErrorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionOfError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCount = table.Column<double>(type: "float", nullable: true),
                    ErrorLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorSubtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroducedOrMissed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error", x => x.ErrorId);
                });

            migrationBuilder.CreateTable(
                name: "PersonType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreEditing",
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
                    OwnerOfPM = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PreEditing", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revision",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditingLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescriptionOfError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCount = table.Column<double>(type: "float", nullable: false),
                    ErrorLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorSubtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroducedOrMissed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<double>(type: "float", nullable: false),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityAssurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revision", x => x.Id);
                });
        }
    }
}
