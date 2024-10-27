using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportationSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class EditUserTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "National_Code",
                table: "Users",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "National_Code",
                table: "Users");
        }
    }
}
