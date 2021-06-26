using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgorithemFinal.Migrations
{
    public partial class bellSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bells",
                columns: new[] { "Id", "BellOfDay", "Label" },
                values: new object[,]
                {
                    { 1, 0, "8-10" },
                    { 2, 1, "10-12" },
                    { 3, 2, "14-16" },
                    { 4, 3, "16-18" }
                });

            migrationBuilder.InsertData(
                table: "Days",
                columns: new[] { "Id", "DayOfWeek", "Label" },
                values: new object[,]
                {
                    { 1, 0, "شنبه" },
                    { 2, 1, "یکشنبه" },
                    { 3, 2, "دوشنبه" },
                    { 4, 3, "سه‌شنبه" },
                    { 5, 4, "چهارشنبه" },
                    { 6, 5, "پنج‌شنبه" },
                    { 7, 6, "جمعه" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$hPpv3c0TwyP1WyL3ajqF7.yrDMYWAHqN/y0Mn4z.9tgq6/MLX9egS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$uifnnQuAngWU3nNzNE3HduL3zS3C5bVYGbYqbvcix8urIPVAIMm/G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$v3qoUF8k1XJl1PLFCGDGQOZMrjt9cBZYlDaeyRAUZVgsMRP.iENYS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$jrTyHggyvhcrty6Nd3oPk.myOH7yt1h12c7hAt/1OnPKgcRhxTSpG");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bells",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bells",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bells",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bells",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Days",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$qMKWWpZvH7qOJwjFqcrMIO.F93tn0.Zm4ZPgf9gucrbDMLp/cgdSy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$HKkcFDNLL2bgZpPo2UxHcuZ.wksP1qzbNHt5tEGMk5ZDyqwrzKH2W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$SQPeuWLFLP3DPUsZO7mHMOsYiKgNvvP6/E3OXFDDOHpjBJuvRHvUC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$SFve9ALNggK1I19J35qpSu40QPobLf4KMLBFCLbvbCo.r8KuClSN6");
        }
    }
}
