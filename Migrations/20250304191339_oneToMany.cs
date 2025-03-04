using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_REST_API.Migrations
{
    /// <inheritdoc />
    public partial class oneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonEducations");

            migrationBuilder.DropTable(
                name: "PersonWorkExperiences");

            migrationBuilder.RenameColumn(
                name: "WorkId",
                table: "WorkExperiences",
                newName: "WorkExperienceId");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "WorkExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Educations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperiences_PersonId",
                table: "WorkExperiences",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_PersonId",
                table: "Educations",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Educations_Persons_PersonId",
                table: "Educations",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperiences_Persons_PersonId",
                table: "WorkExperiences",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Educations_Persons_PersonId",
                table: "Educations");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperiences_Persons_PersonId",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperiences_PersonId",
                table: "WorkExperiences");

            migrationBuilder.DropIndex(
                name: "IX_Educations_PersonId",
                table: "Educations");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "WorkExperiences");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Educations");

            migrationBuilder.RenameColumn(
                name: "WorkExperienceId",
                table: "WorkExperiences",
                newName: "WorkId");

            migrationBuilder.CreateTable(
                name: "PersonEducations",
                columns: table => new
                {
                    PersonEducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonEducations", x => x.PersonEducationId);
                    table.ForeignKey(
                        name: "FK_PersonEducations_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "EducationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonEducations_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonWorkExperiences",
                columns: table => new
                {
                    PersonWorkExperienceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonWorkExperiences", x => x.PersonWorkExperienceId);
                    table.ForeignKey(
                        name: "FK_PersonWorkExperiences_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonWorkExperiences_WorkExperiences_WorkId",
                        column: x => x.WorkId,
                        principalTable: "WorkExperiences",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_EducationId",
                table: "PersonEducations",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonEducations_PersonId",
                table: "PersonEducations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorkExperiences_PersonId",
                table: "PersonWorkExperiences",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWorkExperiences_WorkId",
                table: "PersonWorkExperiences",
                column: "WorkId");
        }
    }
}
