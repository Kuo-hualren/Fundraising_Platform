using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorRecord.Server.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PunchIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PunchOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Hours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, "qqq@gmail.com", "Ben", "0966666666", "工程師" },
                    { 2, "ddd@gmail.com", "Alan", "0988888888", "工程師" }
                });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Hours", "Name", "PunchIn", "PunchOut", "Time" },
                values: new object[,]
                {
                    { 1, "", "Ben", new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3319), new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3322), "2023/07/12" },
                    { 2, "", "Ben", new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3330), new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3331), "2023/07/12" },
                    { 3, "", "Ben", new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3337), new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3340), "2023/07/12" },
                    { 4, "", "Ben", new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3353), new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3354), "2023/07/12" },
                    { 5, "", "Ben", new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3359), new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3359), "2023/07/12" },
                    { 6, "", "Ben", new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3365), new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3366), "2023/07/12" },
                    { 7, "", "Ben", new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3370), new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3371), "2023/07/12" },
                    { 8, "", "Ben", new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3376), new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3377), "2023/07/12" },
                    { 9, "", "Ben", new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3383), new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3384), "2023/07/12" },
                    { 10, "", "Ben", new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3390), new DateTime(2023, 7, 12, 1, 39, 45, 773, DateTimeKind.Local).AddTicks(3390), "2023/07/12" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Records");
        }
    }
}
