using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_points_users_userIdId",
                table: "points");

            migrationBuilder.RenameColumn(
                name: "userIdId",
                table: "points",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_points_userIdId",
                table: "points",
                newName: "IX_points_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_points_users_userId",
                table: "points",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_points_users_userId",
                table: "points");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "points",
                newName: "userIdId");

            migrationBuilder.RenameIndex(
                name: "IX_points_userId",
                table: "points",
                newName: "IX_points_userIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_points_users_userIdId",
                table: "points",
                column: "userIdId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
