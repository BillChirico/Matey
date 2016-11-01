using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Matey.Web.Migrations
{
    public partial class AddedPremisesToUtility : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PremisesId",
                table: "Utilities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Utilities_PremisesId",
                table: "Utilities",
                column: "PremisesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilities_Premises_PremisesId",
                table: "Utilities",
                column: "PremisesId",
                principalTable: "Premises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilities_Premises_PremisesId",
                table: "Utilities");

            migrationBuilder.DropIndex(
                name: "IX_Utilities_PremisesId",
                table: "Utilities");

            migrationBuilder.DropColumn(
                name: "PremisesId",
                table: "Utilities");
        }
    }
}
