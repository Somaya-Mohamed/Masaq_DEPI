using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class ModifyNotificationRelationshipBetweenTeacherAndStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SentAt",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StudentFK",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeacherFK",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_StudentFK",
                table: "Notifications",
                column: "StudentFK");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TeacherFK",
                table: "Notifications",
                column: "TeacherFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Students_StudentFK",
                table: "Notifications",
                column: "StudentFK",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Teachers_TeacherFK",
                table: "Notifications",
                column: "TeacherFK",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Students_StudentFK",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Teachers_TeacherFK",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_StudentFK",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TeacherFK",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SentAt",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "StudentFK",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TeacherFK",
                table: "Notifications");
        }
    }
}
