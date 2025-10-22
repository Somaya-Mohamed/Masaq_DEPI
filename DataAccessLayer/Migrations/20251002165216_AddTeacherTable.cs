using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddTeacherTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    ParentPhoneNumber = table.Column<string>(type: "nvarchar(15)", nullable: false),
                    CreationBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false, computedColumnSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LastActive = table.Column<DateTime>(type: "datetime2", nullable: false, computedColumnSql: "GETDATE()"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
