using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    /// <inheritdoc />
    public partial class AddClassErrorFeedbackPreEditingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreEditingErrorFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JournalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PageCount = table.Column<int>(type: "int", nullable: false),
                    ErrorCount = table.Column<int>(type: "int", nullable: false),
                    DescriptionOfError = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Matter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorSubtype = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ErrorCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntroducedOrMissed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Employee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CopyEditingLevel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreEditingErrorFeedbacks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreEditingErrorFeedbacks");
        }
    }
}
