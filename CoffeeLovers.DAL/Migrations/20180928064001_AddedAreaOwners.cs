using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeLovers.DAL.Migrations
{
    public partial class AddedAreaOwners : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaOwner",
                schema: "dbo",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Createdtime = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: true),
                    Updatedtime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AreaOwnerId = table.Column<Guid>(nullable: false),
                    validFrom = table.Column<DateTime>(nullable: false),
                    validTo = table.Column<DateTime>(nullable: false),
                    AreaId = table.Column<Guid>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaOwner", x => x.AreaOwnerId);
                    table.ForeignKey(
                        name: "FK_AreaOwner_Area_AreaId",
                        column: x => x.AreaId,
                        principalSchema: "dbo",
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaOwner_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaOwner_AreaId",
                schema: "dbo",
                table: "AreaOwner",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaOwner_OwnerId",
                schema: "dbo",
                table: "AreaOwner",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaOwner",
                schema: "dbo");
        }
    }
}
