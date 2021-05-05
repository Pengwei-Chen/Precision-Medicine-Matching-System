using Microsoft.EntityFrameworkCore.Migrations;

namespace Precision_Medicine_Matching_System.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnnotatedDrug",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biomarker = table.Column<int>(type: "int", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recommendation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummaryMarkdown = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DosingInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummaryMarkdown = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
