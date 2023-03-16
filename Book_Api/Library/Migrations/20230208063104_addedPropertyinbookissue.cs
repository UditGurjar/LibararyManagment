using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class addedPropertyinbookissue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssues_Users_UserId",
                table: "BookIssues");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookIssues",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssues_Users_UserId",
                table: "BookIssues",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookIssues_Users_UserId",
                table: "BookIssues");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookIssues",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookIssues_Users_UserId",
                table: "BookIssues",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
