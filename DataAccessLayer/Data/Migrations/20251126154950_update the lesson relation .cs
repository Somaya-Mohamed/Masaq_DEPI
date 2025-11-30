using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatethelessonrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonVideos_Lessons_LessonID",
                table: "LessonVideos");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonVideos_Lessons_LessonID",
                table: "LessonVideos",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LessonVideos_Lessons_LessonID",
                table: "LessonVideos");

            migrationBuilder.AddForeignKey(
                name: "FK_LessonVideos_Lessons_LessonID",
                table: "LessonVideos",
                column: "LessonID",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
