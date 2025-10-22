using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class initalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReadAt",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "levelFK",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExamId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseIdFK",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Exams",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Courses",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LessonIdFK",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentIdFK",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                computedColumnSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "QuestionOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionOptions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentExam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsSubmitted = table.Column<bool>(type: "bit", nullable: false),
                    IsPassed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentExam_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentExam_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentLesson",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLesson", x => new { x.StudentId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_StudentLesson_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLesson_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotification",
                columns: table => new
                {
                    HumanBaseEntityId = table.Column<int>(type: "int", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotification", x => new { x.HumanBaseEntityId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_UserNotification_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentAnswer",
                columns: table => new
                {
                    StudentExamId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnswerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswer", x => new { x.StudentExamId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_StudentAnswer_QuestionOptions_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "QuestionOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentAnswer_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAnswer_StudentExam_StudentExamId",
                        column: x => x.StudentExamId,
                        principalTable: "StudentExam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_levelFK",
                table: "Students",
                column: "levelFK");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseIdFK",
                table: "Lessons",
                column: "CourseIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_LessonId",
                table: "Exams",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_LessonIdFK",
                table: "Comment",
                column: "LessonIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_StudentIdFK",
                table: "Comment",
                column: "StudentIdFK");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionOptions_QuestionId",
                table: "QuestionOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_AnswerId",
                table: "StudentAnswer",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_QuestionId",
                table: "StudentAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_ExamId",
                table: "StudentExam",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExam_StudentId",
                table: "StudentExam",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLesson_LessonId",
                table: "StudentLesson",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_NotificationId",
                table: "UserNotification",
                column: "NotificationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Lessons_LessonIdFK",
                table: "Comment",
                column: "LessonIdFK",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Students_StudentIdFK",
                table: "Comment",
                column: "StudentIdFK",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Lessons_LessonId",
                table: "Exams",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_Courses_CourseIdFK",
                table: "Lessons",
                column: "CourseIdFK",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Levels_levelFK",
                table: "Students",
                column: "levelFK",
                principalTable: "Levels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Lessons_LessonIdFK",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Students_StudentIdFK",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Lessons_LessonId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_Courses_CourseIdFK",
                table: "Lessons");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Exams_ExamId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Levels_levelFK",
                table: "Students");

            migrationBuilder.DropTable(
                name: "StudentAnswer");

            migrationBuilder.DropTable(
                name: "StudentLesson");

            migrationBuilder.DropTable(
                name: "UserNotification");

            migrationBuilder.DropTable(
                name: "QuestionOptions");

            migrationBuilder.DropTable(
                name: "StudentExam");

            migrationBuilder.DropIndex(
                name: "IX_Students_levelFK",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Questions_ExamId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_CourseIdFK",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Exams_LessonId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Comment_LessonIdFK",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Comment_StudentIdFK",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "levelFK",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CourseIdFK",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "LessonIdFK",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "StudentIdFK",
                table: "Comment");

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadAt",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComputedColumnSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Courses",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
