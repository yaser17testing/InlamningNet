using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Net.UI.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilImage",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilImage",
                table: "AppUsers");
        }
    }
}
