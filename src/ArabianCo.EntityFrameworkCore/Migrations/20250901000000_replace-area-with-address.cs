using System;
using Microsoft.EntityFrameworkCore.Migrations;
using ArabianCo.EntityFrameworkCore;

#nullable disable

namespace ArabianCo.Migrations
{
    [DbContext(typeof(ArabianCoDbContext))]
    [Migration("20250901000000_replace-area-with-address")]
    public partial class replaceareawithaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequests_Areas_AreaId",
                table: "MaintenanceRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ACInstalls_Areas_AreaId",
                table: "ACInstalls");

            migrationBuilder.DropForeignKey(
                name: "FK_AreaTranslations_Areas_CoreId",
                table: "AreaTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Cities_CityId",
                table: "Areas");

            migrationBuilder.DropTable(
                name: "AreaTranslations");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_AreaId",
                table: "MaintenanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_ACInstalls_AreaId",
                table: "ACInstalls");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "OtherArea",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "OtherCity",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "ACInstalls");

            migrationBuilder.DropColumn(
                name: "OtherArea",
                table: "ACInstalls");

            migrationBuilder.DropColumn(
                name: "OtherCity",
                table: "ACInstalls");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "ACInstalls");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "MaintenanceRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "ACInstalls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_AddressId",
                table: "MaintenanceRequests",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ACInstalls_AddressId",
                table: "ACInstalls",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ACInstalls_Addresses_AddressId",
                table: "ACInstalls",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequests_Addresses_AddressId",
                table: "MaintenanceRequests",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ACInstalls_Addresses_AddressId",
                table: "ACInstalls");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceRequests_Addresses_AddressId",
                table: "MaintenanceRequests");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceRequests_AddressId",
                table: "MaintenanceRequests");

            migrationBuilder.DropIndex(
                name: "IX_ACInstalls_AddressId",
                table: "ACInstalls");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "MaintenanceRequests");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ACInstalls");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "MaintenanceRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherArea",
                table: "MaintenanceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCity",
                table: "MaintenanceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "MaintenanceRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "MaintenanceRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "ACInstalls",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherArea",
                table: "ACInstalls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCity",
                table: "ACInstalls",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "ACInstalls",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoreId = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaTranslations_Areas_CoreId",
                        column: x => x.CoreId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRequests_AreaId",
                table: "MaintenanceRequests",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ACInstalls_AreaId",
                table: "ACInstalls",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaTranslations_CoreId",
                table: "AreaTranslations",
                column: "CoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceRequests_Areas_AreaId",
                table: "MaintenanceRequests",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ACInstalls_Areas_AreaId",
                table: "ACInstalls",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id");
        }
    }
}
