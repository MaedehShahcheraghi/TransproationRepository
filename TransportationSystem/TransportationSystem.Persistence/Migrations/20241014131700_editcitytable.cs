using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportationSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class editcitytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Cities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Cities");
        }
    }
}
