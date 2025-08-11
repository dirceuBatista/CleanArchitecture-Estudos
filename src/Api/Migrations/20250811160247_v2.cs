using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccine_VaccineCard_VaccineCardId",
                table: "Vaccine");

            migrationBuilder.DropIndex(
                name: "IX_Vaccine_VaccineCardId",
                table: "Vaccine");

            migrationBuilder.DropColumn(
                name: "VaccineCardId",
                table: "Vaccine");

            migrationBuilder.AddColumn<string>(
                name: "VaccineName",
                table: "VaccineCard",
                type: "NVARCHAR(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VaccineNamesSerialized",
                table: "VaccineCard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VaccineName",
                table: "VaccineCard");

            migrationBuilder.DropColumn(
                name: "VaccineNamesSerialized",
                table: "VaccineCard");

            migrationBuilder.AddColumn<Guid>(
                name: "VaccineCardId",
                table: "Vaccine",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vaccine_VaccineCardId",
                table: "Vaccine",
                column: "VaccineCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccine_VaccineCard_VaccineCardId",
                table: "Vaccine",
                column: "VaccineCardId",
                principalTable: "VaccineCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
