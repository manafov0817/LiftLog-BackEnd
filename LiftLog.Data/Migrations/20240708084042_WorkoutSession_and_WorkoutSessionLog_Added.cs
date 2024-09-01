using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftLog.Data.Migrations
{
    /// <inheritdoc />
    public partial class WorkoutSession_and_WorkoutSessionLog_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkoutSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSessions_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutSessionLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkoutSessionId = table.Column<int>(type: "integer", nullable: false),
                    WorkoutSessionId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutSessionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutSessionLogs_WorkoutSessions_WorkoutSessionId1",
                        column: x => x.WorkoutSessionId1,
                        principalTable: "WorkoutSessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessionLogs_WorkoutSessionId1",
                table: "WorkoutSessionLogs",
                column: "WorkoutSessionId1");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutSessions_ExerciseId",
                table: "WorkoutSessions",
                column: "ExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkoutSessionLogs");

            migrationBuilder.DropTable(
                name: "WorkoutSessions");
        }
    }
}
