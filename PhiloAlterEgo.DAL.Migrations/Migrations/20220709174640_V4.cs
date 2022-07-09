using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhiloAlterEgo.DAL.Migrations.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuildName",
                table: "Guilds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuildName",
                table: "Guilds");
        }
    }
}
