using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftLog.Data.Migrations
{
    /// <inheritdoc />
    public partial class Profilechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WorkoutSessions",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "WorkoutSessionLogs",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Movements",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Exercises",
                newName: "ProfileId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Profiles",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Profiles",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Profiles",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovementName",
                table: "Exercises",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Profiles");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Profiles");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "WorkoutSessions",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "WorkoutSessionLogs",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Movements",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Exercises",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "MovementName",
                table: "Exercises",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
