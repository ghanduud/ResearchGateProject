using Microsoft.EntityFrameworkCore.Migrations;

namespace ResearchGateProject.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Papers_Comments_CommentId",
                table: "Papers");

            migrationBuilder.DropForeignKey(
                name: "FK_Papers_Likes_LikeId",
                table: "Papers");

            migrationBuilder.DropIndex(
                name: "IX_Papers_CommentId",
                table: "Papers");

            migrationBuilder.DropIndex(
                name: "IX_Papers_LikeId",
                table: "Papers");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Papers");

            migrationBuilder.DropColumn(
                name: "LikeId",
                table: "Papers");

            migrationBuilder.AddColumn<string>(
                name: "LikeId",
                table: "Likes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaperId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LikeId",
                table: "Likes",
                column: "LikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PaperId",
                table: "Comments",
                column: "PaperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Papers_PaperId",
                table: "Comments",
                column: "PaperId",
                principalTable: "Papers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Papers_LikeId",
                table: "Likes",
                column: "LikeId",
                principalTable: "Papers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Papers_PaperId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Papers_LikeId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_LikeId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PaperId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "LikeId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "PaperId",
                table: "Comments");

            migrationBuilder.AddColumn<string>(
                name: "CommentId",
                table: "Papers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LikeId",
                table: "Papers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Papers_CommentId",
                table: "Papers",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_LikeId",
                table: "Papers",
                column: "LikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Papers_Comments_CommentId",
                table: "Papers",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Papers_Likes_LikeId",
                table: "Papers",
                column: "LikeId",
                principalTable: "Likes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
