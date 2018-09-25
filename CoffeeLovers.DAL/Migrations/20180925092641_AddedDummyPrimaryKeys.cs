using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeLovers.DAL.Migrations
{
    public partial class AddedDummyPrimaryKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerDisplayId",
                table: "Owner",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CoffeeDisplayId",
                table: "Coffee",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AreaDisplayId",
                table: "Area",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerDisplayId",
                table: "Owner");

            migrationBuilder.DropColumn(
                name: "CoffeeDisplayId",
                table: "Coffee");

            migrationBuilder.DropColumn(
                name: "AreaDisplayId",
                table: "Area");
        }
    }
}
