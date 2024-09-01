using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiftLog.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProfileIdchangedtoUserProfileId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "UserProfiles");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "WorkoutSessions",
                newName: "UserProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "WorkoutSessionLogs",
                newName: "UserProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Movements",
                newName: "UserProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Exercises",
                newName: "UserProfileId");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "UserProfiles",
                newName: "UserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "Profiles");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "WorkoutSessions",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "WorkoutSessionLogs",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Movements",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Exercises",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "UserProfileId",
                table: "Profiles",
                newName: "ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");
        }
    }
}
