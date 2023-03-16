﻿// <auto-generated />
using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230206094027_changetype")]
    partial class changetype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookBookRating", b =>
                {
                    b.Property<int>("BookRatingsBookRatingId")
                        .HasColumnType("int");

                    b.Property<int>("BooksBookId")
                        .HasColumnType("int");

                    b.HasKey("BookRatingsBookRatingId", "BooksBookId");

                    b.HasIndex("BooksBookId");

                    b.ToTable("BookBookRating");
                });

            modelBuilder.Entity("BookRatingUser", b =>
                {
                    b.Property<int>("BookRatingsBookRatingId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookRatingsBookRatingId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("BookRatingUser");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookAuthor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BookCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("BookDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BookExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("BookImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BookIssueId")
                        .HasColumnType("int");

                    b.Property<string>("BookTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalBooks")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("BookCategoryId");

                    b.HasIndex("BookIssueId");

                    b.HasIndex("UserId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Models.BookCategory", b =>
                {
                    b.Property<int>("BookCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookCategoryId");

                    b.ToTable("BookCategories");
                });

            modelBuilder.Entity("Library.Models.BookIssue", b =>
                {
                    b.Property<int>("BookIssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookIssueDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookIssueExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BookStatus")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookIssueId");

                    b.HasIndex("UserId");

                    b.ToTable("BookIssues");
                });

            modelBuilder.Entity("Library.Models.BookRating", b =>
                {
                    b.Property<int>("BookRatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("BookNetRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BookRatingType")
                        .HasColumnType("int");

                    b.HasKey("BookRatingId");

                    b.ToTable("BookRatings");
                });

            modelBuilder.Entity("Library.Models.BookReview", b =>
                {
                    b.Property<int>("BookReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BookReviewText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BookReviewId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("BookReviews");
                });

            modelBuilder.Entity("Library.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Library.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookBookRating", b =>
                {
                    b.HasOne("Library.Models.BookRating", null)
                        .WithMany()
                        .HasForeignKey("BookRatingsBookRatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookRatingUser", b =>
                {
                    b.HasOne("Library.Models.BookRating", null)
                        .WithMany()
                        .HasForeignKey("BookRatingsBookRatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.HasOne("Library.Models.BookCategory", "BookCategory")
                        .WithMany("Books")
                        .HasForeignKey("BookCategoryId");

                    b.HasOne("Library.Models.BookIssue", "BookIssue")
                        .WithMany()
                        .HasForeignKey("BookIssueId");

                    b.HasOne("Library.Models.User", "User")
                        .WithMany("Books")
                        .HasForeignKey("UserId");

                    b.Navigation("BookCategory");

                    b.Navigation("BookIssue");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Library.Models.BookIssue", b =>
                {
                    b.HasOne("Library.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Library.Models.BookReview", b =>
                {
                    b.HasOne("Library.Models.Book", "Book")
                        .WithMany("BookReviews")
                        .HasForeignKey("BookId");

                    b.HasOne("Library.Models.User", null)
                        .WithMany("BookReviews")
                        .HasForeignKey("UserId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Library.Models.User", b =>
                {
                    b.HasOne("Library.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Library.Models.Book", b =>
                {
                    b.Navigation("BookReviews");
                });

            modelBuilder.Entity("Library.Models.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.Models.User", b =>
                {
                    b.Navigation("BookReviews");

                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
