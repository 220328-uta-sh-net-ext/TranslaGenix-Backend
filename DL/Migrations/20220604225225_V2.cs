using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "userId",
                table: "points",
                newName: "userIdId");

            migrationBuilder.CreateIndex(
                name: "IX_points_userIdId",
                table: "points",
                column: "userIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_points_users_userIdId",
                table: "points",
                column: "userIdId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_points_users_userIdId",
                table: "points");

            migrationBuilder.DropIndex(
                name: "IX_points_userIdId",
                table: "points");

            migrationBuilder.RenameColumn(
                name: "userIdId",
                table: "points",
                newName: "userId");
        }
    }
}
