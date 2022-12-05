using Microsoft.EntityFrameworkCore.Migrations;

namespace UpSchoolCRM.DataAccess.Migrations
{
    public partial class _updateAppUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmedCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirmedCode",
                table: "AspNetUsers");
        }
    }
}
