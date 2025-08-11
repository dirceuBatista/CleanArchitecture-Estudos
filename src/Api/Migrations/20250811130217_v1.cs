using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    EmailHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PasswordHash = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "INT", maxLength: 3, nullable: false),
                    Allergy = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: true),
                    Gender = table.Column<string>(type: "NVARCHAR(15)", maxLength: 15, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR(11)", maxLength: 11, nullable: false),
                    SusNumber = table.Column<string>(type: "NVARCHAR(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VaccineCard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    SusNumber = table.Column<string>(type: "NVARCHAR(15)", maxLength: 15, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR(11)", maxLength: 11, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccineCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VaccineCard_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Manufacture = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    CategoryType = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: false),
                    DoseType = table.Column<int>(type: "INT", maxLength: 10, nullable: false),
                    MinimumAgeInMonths = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    Mandatory = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Index = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    VaccineCardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccine_VaccineCard_VaccineCardId",
                        column: x => x.VaccineCardId,
                        principalTable: "VaccineCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccine_VaccineCardId",
                table: "Vaccine",
                column: "VaccineCardId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccineCard_UserId",
                table: "VaccineCard",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccine");

            migrationBuilder.DropTable(
                name: "VaccineCard");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
