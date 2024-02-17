using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NTDataHiveGrpcService.Migrations
{
    /// <inheritdoc />
    public partial class AddStatePropertyInApprovalClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Test",
                table: "Evaluation");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Approval",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Approval");

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Evaluation",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
