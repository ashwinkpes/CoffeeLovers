using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeLovers.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Createdtime = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Updatedtime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AreaId = table.Column<Guid>(nullable: false),
                    AreaName = table.Column<string>(maxLength: 40, nullable: false),
                    PinCode = table.Column<int>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Createdtime = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Updatedtime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CoffeeId = table.Column<Guid>(nullable: false),
                    CoffeeName = table.Column<string>(maxLength: 20, nullable: false),
                    validFrom = table.Column<DateTime>(nullable: false),
                    validTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.CoffeeId);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Createdtime = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Updatedtime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 6, nullable: false),
                    LastName = table.Column<string>(maxLength: 6, nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeAreas",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Createdtime = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Updatedtime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CoffeeAreaId = table.Column<Guid>(nullable: false),
                    validFrom = table.Column<DateTime>(nullable: false),
                    validTo = table.Column<DateTime>(nullable: false),
                    CoffeeId = table.Column<int>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    CoffeeId1 = table.Column<Guid>(nullable: false),
                    AreaId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeAreas", x => x.CoffeeAreaId);
                    table.ForeignKey(
                        name: "FK_CoffeeAreas_Area_AreaId1",
                        column: x => x.AreaId1,
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CoffeeAreas_Coffee_CoffeeId1",
                        column: x => x.CoffeeId1,
                        principalTable: "Coffee",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaOwner",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Createdtime = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Updatedtime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AreaOwnerId = table.Column<Guid>(nullable: false),
                    AreaId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    validFrom = table.Column<DateTime>(nullable: false),
                    validTo = table.Column<DateTime>(nullable: false),
                    AreaId1 = table.Column<Guid>(nullable: false),
                    OwnerId1 = table.Column<Guid>(nullable: false),
                    CoffeeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaOwner", x => x.AreaOwnerId);
                    table.ForeignKey(
                        name: "FK_AreaOwner_Area_AreaId1",
                        column: x => x.AreaId1,
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaOwner_Coffee_CoffeeId",
                        column: x => x.CoffeeId,
                        principalTable: "Coffee",
                        principalColumn: "CoffeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AreaOwner_Owner_OwnerId1",
                        column: x => x.OwnerId1,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaOwner_AreaId1",
                table: "AreaOwner",
                column: "AreaId1");

            migrationBuilder.CreateIndex(
                name: "IX_AreaOwner_CoffeeId",
                table: "AreaOwner",
                column: "CoffeeId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaOwner_OwnerId1",
                table: "AreaOwner",
                column: "OwnerId1");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeAreas_AreaId1",
                table: "CoffeeAreas",
                column: "AreaId1");

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeAreas_CoffeeId1",
                table: "CoffeeAreas",
                column: "CoffeeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaOwner");

            migrationBuilder.DropTable(
                name: "CoffeeAreas");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Coffee");
        }
    }
}
