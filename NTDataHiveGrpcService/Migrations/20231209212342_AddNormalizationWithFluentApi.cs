using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    /// <inheritdoc />
    public partial class AddNormalizationWithFluentApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PageCount = table.Column<double>(type: "float", nullable: false),
                    RootCause = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CorrectiveAction = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NatureOfCA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OwnerOfCA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TargetDateOfCompletionCA = table.Column<DateTime>(type: "datetime", nullable: false),
                    PreventiveMeasure = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    NatureOfPM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    OwnerOfPM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    TargetDateOfCompletionPM = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusOfCA = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    StatusOfPM = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    MegaFeedback = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK_Address_Address",
                        column: x => x.MegaFeedback,
                        principalTable: "Feedback",
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
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Credit",
                columns: table => new
                {
                    CreditIdExt = table.Column<int>(type: "int", nullable: false),
                    WebId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityAssurance = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PublisherName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    JournalId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ArticleId = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CopyEditedBy = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Department = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    EmployeeName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    CopyEditingLevel = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.CreditIdExt);
                    table.ForeignKey(
                        name: "FK_Credit_Feedback",
                        column: x => x.CreditIdExt,
                        principalTable: "Feedback",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Error",
                columns: table => new
                {
                    ErrorIdExt = table.Column<int>(type: "int", nullable: false),
                    ErrorCount = table.Column<double>(type: "float", nullable: false),
                    DescriptionOfError = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Matter = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ErrorLocation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ErrorCode = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ErrorType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ErrorSubtype = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ErrorCategory = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IntroducedOrMissed = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error", x => x.ErrorIdExt);
                    table.ForeignKey(
                        name: "FK_Error_Feedback",
                        column: x => x.ErrorIdExt,
                        principalTable: "Feedback",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_MegaFeedback",
                table: "Feedback",
                column: "MegaFeedback");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Feedback");
        }
    }
}
