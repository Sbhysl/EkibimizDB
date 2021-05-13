using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EkibimizDB.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeGroupByDateJoinedViewModel",
                columns: table => new
                {
                    DateJoined = table.Column<DateTime>(nullable: false),
                    EmployeeCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeGroupByDateJoinedViewModel", x => x.DateJoined);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeGroupBySalaryViewModel",
                columns: table => new
                {
                    Salary = table.Column<double>(nullable: false),
                    EmployeeCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeGroupBySalaryViewModel", x => x.Salary);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Salary = table.Column<double>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    DateJoined = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeGroupByDateJoinedViewModel");

            migrationBuilder.DropTable(
                name: "EmployeeGroupBySalaryViewModel");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
