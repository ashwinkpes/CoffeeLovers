using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeLovers.DAL.Migrations
{
    public partial class UpdateCoffeeModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreaOwner_Coffee_CoffeeId",
                table: "AreaOwner");

            migrationBuilder.DropIndex(
                name: "IX_AreaOwner_CoffeeId",
                table: "AreaOwner");

            migrationBuilder.DropColumn(
                name: "CoffeeId",
                table: "AreaOwner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CoffeeId",
                table: "AreaOwner",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AreaOwner_CoffeeId",
                table: "AreaOwner",
                column: "CoffeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AreaOwner_Coffee_CoffeeId",
                table: "AreaOwner",
                column: "CoffeeId",
                principalTable: "Coffee",
                principalColumn: "CoffeeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
