using Microsoft.EntityFrameworkCore.Migrations;

namespace ResearchGateProject.Migrations
{
    public partial class UpdeateComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutherId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AutherId",
                table: "Comments",
                column: "AutherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AutherId",
                table: "Comments",
                column: "AutherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AutherId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AutherId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AutherId",
                table: "Comments");
        }
    }
}
