using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmpContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authentications",
                columns: table => new
                {
                    Token = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authentications", x => x.Token);
                });

            migrationBuilder.CreateTable(
                name: "EMptb",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMptb", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Login",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Login", x => x.UserName);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authentications");

            migrationBuilder.DropTable(
                name: "EMptb");

            migrationBuilder.DropTable(
                name: "Tb_Login");
        }
    }
}
