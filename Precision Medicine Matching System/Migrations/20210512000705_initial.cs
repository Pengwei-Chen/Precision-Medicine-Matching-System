using Microsoft.EntityFrameworkCore.Migrations;

namespace Precision_Medicine_Matching_System.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnnotatedDrug",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biomarker = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnotatedDrug", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClinicalGuidelineAnnotation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recommendation = table.Column<bool>(type: "bit", nullable: false),
                    Drug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SummaryMarkdown = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicalGuidelineAnnotation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrugLabelAnnotation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosingInformation = table.Column<bool>(type: "bit", nullable: false),
                    SummaryMarkdown = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugLabelAnnotation", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnnotatedDrug");

            migrationBuilder.DropTable(
                name: "ClinicalGuidelineAnnotation");

            migrationBuilder.DropTable(
                name: "DrugLabelAnnotation");
        }
    }
}
