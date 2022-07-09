using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhiloAlterEgo.DAL.Migrations.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuildName",
                table: "Guilds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuildName",
                table: "Guilds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
