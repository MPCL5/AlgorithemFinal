using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgorithemFinal.Migrations
{
    public partial class fixedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeTableBells_Courses_CourseId",
                table: "TimeTableBells");

            migrationBuilder.DropIndex(
                name: "IX_TimeTableBells_CourseId",
                table: "TimeTableBells");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "TimeTableBells");

            migrationBuilder.CreateTable(
                name: "CourseMaster",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    MastersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseMaster", x => new { x.CoursesId, x.MastersId });
                    table.ForeignKey(
                        name: "FK_CourseMaster_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseMaster_Masters_MastersId",
                        column: x => x.MastersId,
                        principalTable: "Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaster_MastersId",
                table: "CourseMaster",
                column: "MastersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseMaster");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "TimeTableBells",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeTableBells_CourseId",
                table: "TimeTableBells",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeTableBells_Courses_CourseId",
                table: "TimeTableBells",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
