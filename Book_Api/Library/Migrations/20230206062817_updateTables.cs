using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class updateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategories",
                columns: table => new
                {
                    BookCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategories", x => x.BookCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "BookRatings",
                columns: table => new
                {
                    BookRatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookNetRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BookRatingType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookRatings", x => x.BookRatingId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookIssues",
                columns: table => new
                {
                    BookIssueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookIssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookIssueExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    BookStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookIssues", x => x.BookIssueId);
                    table.ForeignKey(
                        name: "FK_BookIssues_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookAuthor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalBooks = table.Column<int>(type: "int", nullable: false),
                    BookExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookCategoryId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    BookIssueId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_BookCategories_BookCategoryId",
                        column: x => x.BookCategoryId,
                        principalTable: "BookCategories",
                        principalColumn: "BookCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_BookIssues_BookIssueId",
                        column: x => x.BookIssueId,
                        principalTable: "BookIssues",
                        principalColumn: "BookIssueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "BookReviews",
                columns: table => new
                {
                    BookReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookReviewText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookReviews", x => x.BookReviewId);
                    table.ForeignKey(
                        name: "FK_BookReviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookRating_BooksBookId",
                table: "BookBookRating",
                column: "BooksBookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookIssues_UserId",
                table: "BookIssues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookRatingUser_UserId",
                table: "BookRatingUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_BookId",
                table: "BookReviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookReviews_UserId",
                table: "BookReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCategoryId",
                table: "Books",
                column: "BookCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookIssueId",
                table: "Books",
                column: "BookIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookRating");

            migrationBuilder.DropTable(
                name: "BookRatingUser");

            migrationBuilder.DropTable(
                name: "BookReviews");

            migrationBuilder.DropTable(
                name: "BookRatings");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookCategories");

            migrationBuilder.DropTable(
                name: "BookIssues");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
