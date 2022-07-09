using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhiloAlterEgo.DAL.Migrations.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guilds",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    GuildName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPermission = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kingdoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kingdoms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Governors",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    KingdomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Governors_Kingdoms_KingdomId",
                        column: x => x.KingdomId,
                        principalTable: "Kingdoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuildKingdom",
                columns: table => new
                {
                    GuildsId = table.Column<decimal>(type: "decimal(20,0)", nullable: false),
                    KingdomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuildKingdom", x => new { x.GuildsId, x.KingdomsId });
                    table.ForeignKey(
                        name: "FK_GuildKingdom_Guilds_GuildsId",
                        column: x => x.GuildsId,
                        principalTable: "Guilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuildKingdom_Kingdoms_KingdomsId",
                        column: x => x.KingdomsId,
                        principalTable: "Kingdoms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Kills = table.Column<int>(type: "int", nullable: false),
                    T5Kills = table.Column<int>(type: "int", nullable: false),
                    T4Kills = table.Column<int>(type: "int", nullable: false),
                    Dead = table.Column<int>(type: "int", nullable: false),
                    ResourcesGathered = table.Column<int>(type: "int", nullable: false),
                    ResourcesShared = table.Column<int>(type: "int", nullable: false),
                    ScannedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GovernorId = table.Column<decimal>(type: "decimal(20,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stats_Governors_GovernorId",
                        column: x => x.GovernorId,
                        principalTable: "Governors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Governors_KingdomId",
                table: "Governors",
                column: "KingdomId");

            migrationBuilder.CreateIndex(
                name: "IX_GuildKingdom_KingdomsId",
                table: "GuildKingdom",
                column: "KingdomsId");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_GovernorId",
                table: "Stats",
                column: "GovernorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuildKingdom");

            migrationBuilder.DropTable(
                name: "Stats");

            migrationBuilder.DropTable(
                name: "Guilds");

            migrationBuilder.DropTable(
                name: "Governors");

            migrationBuilder.DropTable(
                name: "Kingdoms");
        }
    }
}
