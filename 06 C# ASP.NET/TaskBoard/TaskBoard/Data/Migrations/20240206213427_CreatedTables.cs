using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.Data.Migrations
{
    public partial class CreatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "586b3d87-c19c-4aa1-b0ce-119644a206b8", 0, "0dac2de8-1dc4-48be-b508-9edbfef46ed8", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEHLR4rA5vrQStf120g/KylR1PhmKPT9XqNQivTmiVdKbf4u905BGKNy8oaGVcQFBjw==", null, false, "29d611ea-1f0e-4950-b918-75d35608339f", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 21, 23, 34, 27, 573, DateTimeKind.Local).AddTicks(2264), "Implement better styling for all public pages", "586b3d87-c19c-4aa1-b0ce-119644a206b8", "Improve CSS styles", null },
                    { 2, 1, new DateTime(2023, 9, 6, 23, 34, 27, 573, DateTimeKind.Local).AddTicks(2294), "Create Android client App for the RESTful TaskBoard service", "586b3d87-c19c-4aa1-b0ce-119644a206b8", "Android Client App", null },
                    { 3, 2, new DateTime(2024, 1, 6, 23, 34, 27, 573, DateTimeKind.Local).AddTicks(2298), "Create Desktop client App for the RESTful TaskBoard service", "586b3d87-c19c-4aa1-b0ce-119644a206b8", "Desktop Client App", null },
                    { 4, 3, new DateTime(2023, 2, 6, 23, 34, 27, 573, DateTimeKind.Local).AddTicks(2301), "Implement [Create Task] page for adding tasks", "586b3d87-c19c-4aa1-b0ce-119644a206b8", "Create Tasks", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_UserId",
                table: "Tasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "586b3d87-c19c-4aa1-b0ce-119644a206b8");
        }
    }
}
