using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    /// <inheritdoc />
    public partial class AddPropties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    CreditId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityAssurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditingLevel = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherIdentity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScoreCard = table.Column<int>(type: "int", nullable: false)
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
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCount = table.Column<double>(type: "float", nullable: true),
                    DescriptionOfError = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Matter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorSubtype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErrorCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntroducedOrMissed = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error", x => x.ErrorId);
                });

            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SupplierName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    QualityAssurance = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PublisherName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    JournalId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ArticleId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CopyEditedBy = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PageCount = table.Column<double>(type: "float", nullable: false),
                    ErrorCount = table.Column<double>(type: "float", nullable: false),
                    DescriptionOfError = table.Column<string>(type: "varchar(4000)", unicode: false, maxLength: 4000, nullable: true),
                    Matter = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ErrorLocation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ErrorCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ErrorType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ErrorSubtype = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ErrorCategory = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IntroducedOrMissed = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Department = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EmployeeName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CopyEditingLevel = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    MegaEvaluation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluation", x => x.id);
                    table.ForeignKey(
                        name: "FK_Evaluation_Evaluation",
                        column: x => x.MegaEvaluation,
                        principalTable: "Evaluation",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
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
                    OwnerOfPM = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityAssurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageCount = table.Column<double>(type: "float", nullable: false),
                    ErrorCount = table.Column<double>(type: "float", nullable: false),
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
                    table.PrimaryKey("PK_Revision", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Approval",
                columns: table => new
                {
                    ApprovalIdExt = table.Column<int>(type: "int", nullable: false),
                    RootCause = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CorrectiveAction = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NatureOfCA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OwnerOfCA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TargetDateOfCompletionCA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PreventiveMeasure = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NatureOfPM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OwnerOfPM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TargetDateOfCompletionPM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusOfCA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    StatusOfPM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approval", x => x.ApprovalIdExt);
                    table.ForeignKey(
                        name: "FK_Approval_Evaluation",
                        column: x => x.ApprovalIdExt,
                        principalTable: "Evaluation",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Evaluation_MegaEvaluation",
                table: "Evaluation",
                column: "MegaEvaluation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approval");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Error");

            migrationBuilder.DropTable(
                name: "Person");

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

            migrationBuilder.DropTable(
                name: "Evaluation");
        }
    }
}
