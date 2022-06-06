using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_points_users_userId",
                table: "points");

            migrationBuilder.DropIndex(
                name: "IX_points_userId",
                table: "points");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_points_userId",
                table: "points",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_points_users_userId",
                table: "points",
                column: "userId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
