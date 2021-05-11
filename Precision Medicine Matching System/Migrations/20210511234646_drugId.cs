using Microsoft.EntityFrameworkCore.Migrations;

namespace Precision_Medicine_Matching_System.Migrations
{
    public partial class drugId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DrugId",
                table: "ClinicalGuidelineAnnotation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrugId",
                table: "ClinicalGuidelineAnnotation");
        }
    }
}
