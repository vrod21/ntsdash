using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    /// <inheritdoc />
    public partial class AddProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evaluation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QualityAssurance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JournalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CopyEditedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportingManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Approval",
                columns: table => new
                {
                    ApprovalIdExt = table.Column<int>(type: "int", nullable: false),
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
                    Validate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Quality",
                columns: table => new
                {
                    QualityIdExt = table.Column<int>(type: "int", nullable: false),
                    Component = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalErrorPoints = table.Column<double>(type: "float", nullable: false),
                    DateProcessed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateChecked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalErrorPoints = table.Column<double>(type: "float", nullable: false),
                    TotalTSPages = table.Column<double>(type: "float", nullable: false),
                    ErrorPerPages = table.Column<double>(type: "float", nullable: false),
                    AccuracyRating = table.Column<double>(type: "float", nullable: false),
                    AccuracyRatingFC = table.Column<double>(type: "float", nullable: false),
                    WeightPercentFC = table.Column<double>(type: "float", nullable: false),
                    WeightedRatingFC = table.Column<double>(type: "float", nullable: false),
                    AccuracyRatingIPF = table.Column<double>(type: "float", nullable: false),
                    WeightPercentIPF = table.Column<double>(type: "float", nullable: false),
                    WeightedRatingIPF = table.Column<double>(type: "float", nullable: false),
                    DCF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverallAccuracyRating = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quality", x => x.QualityIdExt);
                    table.ForeignKey(
                        name: "FK_Quality_Evaluation",
                        column: x => x.QualityIdExt,
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
                name: "Person");

            migrationBuilder.DropTable(
                name: "Quality");

            migrationBuilder.DropTable(
                name: "Evaluation");
        }
    }
}
