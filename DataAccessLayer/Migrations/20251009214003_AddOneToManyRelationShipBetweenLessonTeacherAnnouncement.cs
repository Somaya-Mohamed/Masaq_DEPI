using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToManyRelationShipBetweenLessonTeacherAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LessonIdFK",
                table: "Announcements",
                type: "int",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "TeacherIdFK",
                table: "Announcements",
                type: "int",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_LessonIdFK",
                table: "Announcements",
                column: "LessonIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_TeacherIdFK",
                table: "Announcements",
                column: "TeacherIdFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Lessons_LessonIdFK",
                table: "Announcements",
                column: "LessonIdFK",
                principalTable: "Lessons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_Teachers_TeacherIdFK",
                table: "Announcements",
                column: "TeacherIdFK",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Lessons_LessonIdFK",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_Teachers_TeacherIdFK",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_LessonIdFK",
                table: "Announcements");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_TeacherIdFK",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "LessonIdFK",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "TeacherIdFK",
                table: "Announcements");
        }
    }
}
