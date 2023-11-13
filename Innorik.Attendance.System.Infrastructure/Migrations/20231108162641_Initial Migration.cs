using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Innorik.Attendance.System.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceSheets",
                columns: table => new
                {
                    AtsIDpk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtsFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtsLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtsCheckInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtsActive = table.Column<bool>(type: "bit", nullable: false),
                    AtsCheckInPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AtsCheckInPictureHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtsCheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtsCheckOutPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AtsCheckOutPictureHeader = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceSheets", x => x.AtsIDpk);
                });

            migrationBuilder.CreateTable(
                name: "CreateCheckInDtos",
                columns: table => new
                {
                    AtsFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtsLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtsActive = table.Column<bool>(type: "bit", nullable: false),
                    AtsCheckInPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtsCheckInPictureHeader = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CreateCheckoutDto",
                columns: table => new
                {
                    AtsFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtsLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AtsCheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtsCheckOutPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetAllCheckInDtos",
                columns: table => new
                {
                    AtsIDpk = table.Column<int>(type: "int", nullable: false),
                    AtsFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtsLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtsCheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtsActive = table.Column<bool>(type: "bit", nullable: false),
                    AtsCheckInPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AtsCheckInPictureHeader = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtsCheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AtsCheckOutPicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AtsCheckOutPictureHeader = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceSheets");

            migrationBuilder.DropTable(
                name: "CreateCheckInDtos");

            migrationBuilder.DropTable(
                name: "CreateCheckoutDto");

            migrationBuilder.DropTable(
                name: "GetAllCheckInDtos");
        }
    }
}
