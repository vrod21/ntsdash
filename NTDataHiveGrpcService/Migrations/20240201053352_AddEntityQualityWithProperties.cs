using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityQualityWithProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quality",
                columns: table => new
                {
                    QualityIdExt = table.Column<int>(type: "int", nullable: false),
                    WebId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quality");
        }
    }
}
