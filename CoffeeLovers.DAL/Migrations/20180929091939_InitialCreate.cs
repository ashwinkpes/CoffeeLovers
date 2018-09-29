using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeLovers.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Area",
                schema: "dbo",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Createdtime = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: true),
                    Updatedtime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AreaId = table.Column<Guid>(nullable: false),
                    AreaDisplayId = table.Column<string>(maxLength: 40, nullable: false),
                    AreaName = table.Column<string>(maxLength: 40, nullable: false),
                    PinCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "Coffee",
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
                    CoffeeId = table.Column<Guid>(nullable: false),
                    CoffeeDisplayId = table.Column<string>(maxLength: 40, nullable: false),
                    CoffeeName = table.Column<string>(maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.CoffeeId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
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
                    RoleId = table.Column<Guid>(nullable: false),
                    RoleDisplayId = table.Column<string>(maxLength: 40, nullable: false),
                    RoleName = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

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
                    CoffeeId = table.Column<Guid>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                schema: "dbo",
                columns: table => new
                {
                    CreatedBy = table.Column<string>(maxLength: 20, nullable: false),
                    Createdtime = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 20, nullable: true),
                    Updatedtime = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    LastName = table.Column<string>(maxLength: 20, nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    OwnerDisplayId = table.Column<string>(maxLength: 40, nullable: false),
                    EmailId = table.Column<string>(maxLength: 30, nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owner_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    validFrom = table.Column<DateTime>(nullable: false),
                    validTo = table.Column<DateTime>(nullable: false),
                    AreaOwnerId = table.Column<Guid>(nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Owner_RoleId",
                schema: "dbo",
                table: "Owner",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaOwner",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CoffeeAreas",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Owner",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Area",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Coffee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");
        }
    }
}
