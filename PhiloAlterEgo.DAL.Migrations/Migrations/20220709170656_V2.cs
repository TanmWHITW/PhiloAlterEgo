using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhiloAlterEgo.DAL.Migrations.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPermission",
                table: "Guilds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasPermission",
                table: "Guilds",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
