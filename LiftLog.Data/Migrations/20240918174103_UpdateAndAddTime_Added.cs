using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftLog.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAndAddTime_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddDateTime",
                table: "WorkoutSessions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "WorkoutSessions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDateTime",
                table: "WorkoutSessionLogs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "WorkoutSessionLogs",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDateTime",
                table: "UserProfiles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "UserProfiles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDateTime",
                table: "Muscles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Muscles",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDateTime",
                table: "Movements",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Movements",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddDateTime",
                table: "Exercises",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDateTime",
                table: "Exercises",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddDateTime",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "WorkoutSessions");

            migrationBuilder.DropColumn(
                name: "AddDateTime",
                table: "WorkoutSessionLogs");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "WorkoutSessionLogs");

            migrationBuilder.DropColumn(
                name: "AddDateTime",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "AddDateTime",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Muscles");

            migrationBuilder.DropColumn(
                name: "AddDateTime",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "AddDateTime",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "UpdateDateTime",
                table: "Exercises");
        }
    }
}
