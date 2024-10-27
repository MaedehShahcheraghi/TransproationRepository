using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TransportationSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addpenetil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissions_permissions_PermissionId",
                table: "permissions");

            migrationBuilder.DropIndex(
                name: "IX_permissions_PermissionId",
                table: "permissions");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "permissions");

            migrationBuilder.CreateIndex(
                name: "IX_permissions_Parent_Permission_Id",
                table: "permissions",
                column: "Parent_Permission_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_permissions_Parent_Permission_Id",
                table: "permissions",
                column: "Parent_Permission_Id",
                principalTable: "permissions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissions_permissions_Parent_Permission_Id",
                table: "permissions");

            migrationBuilder.DropIndex(
                name: "IX_permissions_Parent_Permission_Id",
                table: "permissions");

            migrationBuilder.AddColumn<long>(
                name: "PermissionId",
                table: "permissions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_permissions_PermissionId",
                table: "permissions",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_permissions_PermissionId",
                table: "permissions",
                column: "PermissionId",
                principalTable: "permissions",
                principalColumn: "Id");
        }
    }
}
