using Microsoft.EntityFrameworkCore.Migrations;

namespace AlgorithemFinal.Migrations
{
    public partial class courseSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Title", "UnitsCount" },
                values: new object[,]
                {
                    { 1, "طراحی الگوریتم", 3 },
                    { 2, "ساختمان داده ها", 3 },
                    { 3, "برنامه سازی پیشرفته", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$r9ZNNAAsp7q436lBciIUROHPPhNx8w7E2uQO/VBIEGSsH.pVmJWMe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$IwhNebCxX4sOWfhVltGJy.9wG8zgxzR58HsikVZVL1q/scEe5pjhy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$QzkNKGof/P5zQGiGyOQ4.u/HKzDXaaJfZpP8cbU/BuAlMurhCdCjq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$k8wMZKTqqNWSsSJusbDkh.dTG97S1/96v8.EE9L/9Wg5.koODk9cy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

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
    }
}
