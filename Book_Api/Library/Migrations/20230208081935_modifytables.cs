using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class modifytables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Books_BookId",
                table: "BookReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Users_UserId",
                table: "BookReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Users_UserId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookBookRating");

            migrationBuilder.DropTable(
                name: "BookRatingUser");

            migrationBuilder.DropIndex(
                name: "IX_Books_UserId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookReviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BookReviews",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BookRatings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_BookId",
                table: "BookRatings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatings_UserId",
                table: "BookRatings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRatings_Books_BookId",
                table: "BookRatings",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookRatings_Users_UserId",
                table: "BookRatings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Books_BookId",
                table: "BookReviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Users_UserId",
                table: "BookReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRatings_Books_BookId",
                table: "BookRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookRatings_Users_UserId",
                table: "BookRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Books_BookId",
                table: "BookReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_BookReviews_Users_UserId",
                table: "BookReviews");

            migrationBuilder.DropIndex(
                name: "IX_BookRatings_BookId",
                table: "BookRatings");

            migrationBuilder.DropIndex(
                name: "IX_BookRatings_UserId",
                table: "BookRatings");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookRatings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookRatings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookReviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "BookReviews",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "BookBookRating",
                columns: table => new
                {
                    BookRatingsBookRatingId = table.Column<int>(type: "int", nullable: false),
                    BooksBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookRating", x => new { x.BookRatingsBookRatingId, x.BooksBookId });
                    table.ForeignKey(
                        name: "FK_BookBookRating_BookRatings_BookRatingsBookRatingId",
                        column: x => x.BookRatingsBookRatingId,
                        principalTable: "BookRatings",
                        principalColumn: "BookRatingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookRating_Books_BooksBookId",
                        column: x => x.BooksBookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookRatingUser",
                columns: table => new
                {
                    BookRatingsBookRatingId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRatingUser", x => new { x.BookRatingsBookRatingId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BookRatingUser_BookRatings_BookRatingsBookRatingId",
                        column: x => x.BookRatingsBookRatingId,
                        principalTable: "BookRatings",
                        principalColumn: "BookRatingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookRatingUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBookRating_BooksBookId",
                table: "BookBookRating",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatingUser_UserId",
                table: "BookRatingUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Books_BookId",
                table: "BookReviews",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookReviews_Users_UserId",
                table: "BookReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Users_UserId",
                table: "Books",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
