using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgorithemFinal.Migrations
{
    public partial class newMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BellOfDay = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bells", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MasterId = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.UniqueConstraint("AlternateKey_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Masters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Masters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTables_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeTables_Masters_MasterId",
                        column: x => x.MasterId,
                        principalTable: "Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeTableId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcements_TimeTables_TimeTableId",
                        column: x => x.TimeTableId,
                        principalTable: "TimeTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTimeTable",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    TimeTablesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTimeTable", x => new { x.StudentsId, x.TimeTablesId });
                    table.ForeignKey(
                        name: "FK_StudentTimeTable_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTimeTable_TimeTables_TimeTablesId",
                        column: x => x.TimeTablesId,
                        principalTable: "TimeTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeTableBells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayId = table.Column<int>(type: "int", nullable: true),
                    BellId = table.Column<int>(type: "int", nullable: true),
                    TimeTableId = table.Column<int>(type: "int", nullable: true),
                    MasterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTableBells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeTableBells_Bells_BellId",
                        column: x => x.BellId,
                        principalTable: "Bells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTableBells_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTableBells_Masters_MasterId",
                        column: x => x.MasterId,
                        principalTable: "Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TimeTableBells_TimeTables_TimeTableId",
                        column: x => x.TimeTableId,
                        principalTable: "TimeTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AdminId", "Code", "FirstName", "LastName", "MasterId", "Password", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, "975361004", "مسعود", "پورغفار اقدم", null, "$2a$11$qMKWWpZvH7qOJwjFqcrMIO.F93tn0.Zm4ZPgf9gucrbDMLp/cgdSy", null },
                    { 2, null, "965361004", "ریحانه", "زهرابی", 1, "$2a$11$HKkcFDNLL2bgZpPo2UxHcuZ.wksP1qzbNHt5tEGMk5ZDyqwrzKH2W", null },
                    { 3, null, "985361004", "نرگس", "میرزایی", null, "$2a$11$SQPeuWLFLP3DPUsZO7mHMOsYiKgNvvP6/E3OXFDDOHpjBJuvRHvUC", 1 },
                    { 4, null, "985361003", "طاها", "علیپور", null, "$2a$11$SFve9ALNggK1I19J35qpSu40QPobLf4KMLBFCLbvbCo.r8KuClSN6", 2 }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Masters",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_TimeTableId",
                table: "Announcements",
                column: "TimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseMaster_MastersId",
                table: "CourseMaster",
                column: "MastersId");

            migrationBuilder.CreateIndex(
                name: "IX_Masters_UserId",
                table: "Masters",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentTimeTable_TimeTablesId",
                table: "StudentTimeTable",
                column: "TimeTablesId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTableBells_BellId",
                table: "TimeTableBells",
                column: "BellId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTableBells_DayId",
                table: "TimeTableBells",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTableBells_MasterId",
                table: "TimeTableBells",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTableBells_TimeTableId",
                table: "TimeTableBells",
                column: "TimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_CourseId",
                table: "TimeTables",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_MasterId",
                table: "TimeTables",
                column: "MasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "CourseMaster");

            migrationBuilder.DropTable(
                name: "StudentTimeTable");

            migrationBuilder.DropTable(
                name: "TimeTableBells");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Bells");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropTable(
                name: "TimeTables");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Masters");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
