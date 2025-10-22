using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddonetoManyRelationshipbetweenLevelandCourseandremoverelationshipbetweenTeacherandAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Teachers_TeacherIdFK",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_TeacherIdFK",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "TeacherIdFK",
                table: "Announcements");

            migrationBuilder.AddColumn<int>(
                name: "LevelFK",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LevelFK",
                table: "Courses",
                column: "LevelFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Levels_LevelFK",
                table: "Courses",
                column: "LevelFK",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Levels_LevelFK",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LevelFK",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "LevelFK",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdFK",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_TeacherIdFK",
                table: "Announcements",
                column: "TeacherIdFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Teachers_TeacherIdFK",
                table: "Announcements",
                column: "TeacherIdFK",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
