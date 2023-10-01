using Microsoft.EntityFrameworkCore.Migrations;

namespace ResearchGateProject.Migrations
{
    public partial class LikeUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Papers_LikeId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "LikeId",
                table: "Likes",
                newName: "PaperId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_LikeId",
                table: "Likes",
                newName: "IX_Likes_PaperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Papers_PaperId",
                table: "Likes",
                column: "PaperId",
                principalTable: "Papers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Papers_PaperId",
                table: "Likes");

            migrationBuilder.RenameColumn(
                name: "PaperId",
                table: "Likes",
                newName: "LikeId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PaperId",
                table: "Likes",
                newName: "IX_Likes_LikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Papers_LikeId",
                table: "Likes",
                column: "LikeId",
                principalTable: "Papers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
