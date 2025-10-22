using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class LessonAndVideoRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoName",
                table: "Lessons");

            migrationBuilder.CreateTable(
                name: "LessonVideos",
                columns: table => new
                {
                    LessonID = table.Column<int>(type: "int", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonVideos", x => new { x.LessonID, x.VideoURL });
                    table.ForeignKey(
                        name: "FK_LessonVideos_Lessons_LessonID",
                        column: x => x.LessonID,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LessonVideos");

            migrationBuilder.AddColumn<string>(
                name: "VideoName",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
