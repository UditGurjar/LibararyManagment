using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class addedPropertynew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookIssues_BookIssueId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookIssueId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookIssueId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookIssues",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookIssues_BookId",
                table: "BookIssues",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssues_Books_BookId",
                table: "BookIssues",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssues_Books_BookId",
                table: "BookIssues");

            migrationBuilder.DropIndex(
                name: "IX_BookIssues_BookId",
                table: "BookIssues");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookIssues");

            migrationBuilder.AddColumn<int>(
                name: "BookIssueId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookIssueId",
                table: "Books",
                column: "BookIssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookIssues_BookIssueId",
                table: "Books",
                column: "BookIssueId",
                principalTable: "BookIssues",
                principalColumn: "BookIssueId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
