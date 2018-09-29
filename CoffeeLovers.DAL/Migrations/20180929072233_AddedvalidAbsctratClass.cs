using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeLovers.DAL.Migrations
{
    public partial class AddedvalidAbsctratClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                schema: "dbo",
                table: "Coffee",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CoffeeAreas",
                schema: "dbo",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Createdtime = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: true),
                    Updatedtime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    validFrom = table.Column<DateTime>(nullable: false),
                    validTo = table.Column<DateTime>(nullable: false),
                    CoffeeAreaId = table.Column<Guid>(nullable: false),
                    CoffeeAreaDisplayId = table.Column<string>(maxLength: 40, nullable: false),
                    AreaId = table.Column<Guid>(nullable: false),
                    CoffeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeAreas", x => x.CoffeeAreaId);
                    table.ForeignKey(
                        name: "FK_CoffeeAreas_Area_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "dbo",
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeAreas_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalSchema: "dbo",
                        principalTable: "Coffee",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeAreas_AreaId",
                schema: "dbo",
                table: "CoffeeAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeAreas_CoffeeId",
                schema: "dbo",
                table: "CoffeeAreas",
                column: "CoffeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeAreas",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "dbo",
                table: "Coffee");
        }
    }
}
