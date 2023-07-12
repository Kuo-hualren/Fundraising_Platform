using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorDB.Server.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Records_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Records",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Records",
                columns: new[] { "Id", "Hours", "Name", "PunchIn", "PunchOut", "Time" },
                values: new object[,]
                {
                    { 1, "0", "Ben", new DateTime(2023, 7, 12, 14, 27, 24, 46, DateTimeKind.Local).AddTicks(704), new DateTime(2023, 7, 12, 14, 27, 24, 46, DateTimeKind.Local).AddTicks(705), "2023/07/12" },
                    { 2, "0", "Alan", new DateTime(2023, 7, 12, 14, 27, 24, 46, DateTimeKind.Local).AddTicks(714), new DateTime(2023, 7, 12, 14, 27, 24, 46, DateTimeKind.Local).AddTicks(715), "2023/07/12" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "Name", "Phone", "Position", "RecordId" },
                values: new object[,]
                {
                    { 1, "sss@gmail.com", "Ben", "0966666666", "engineer", 1 },
                    { 2, "sssss@gmail.com", "Alan", "0977777777", "engineer", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RecordId",
                table: "Employees",
                column: "RecordId");
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
