using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftLog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Movement_and_Exercise_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    MusclesEngaged = table.Column<int>(type: "integer", nullable: false),
                    VideoLink = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MovementName = table.Column<string>(type: "text", nullable: false),
                    WeightType = table.Column<int>(type: "integer", nullable: false),
                    SetCount = table.Column<byte>(type: "smallint", nullable: false),
                    MovementId = table.Column<int>(type: "integer", nullable: false),
                    MovementId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exercises_Movements_MovementId1",
                        column: x => x.MovementId1,
                        principalTable: "Movements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_MovementId1",
                table: "Exercises",
                column: "MovementId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Movements");
        }
    }
}
