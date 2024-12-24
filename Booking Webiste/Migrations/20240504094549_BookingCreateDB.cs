using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_Webiste.Migrations
{
    /// <inheritdoc />
    public partial class BookingCreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", nullable: false),
                    PhoneNo = table.Column<string>(type: "varchar(20)", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    Slots = table.Column<string>(type: "varchar(200)", nullable: false),
                    No_Of_Persons = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
