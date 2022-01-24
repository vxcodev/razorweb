using System;
using Bogus;
using Razorweb.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace Razorweb.Migrations
{
    public partial class v010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_articles", x => x.Id);
                });

            // Insert data
            /* migrationBuilder.InsertData(
                table: "articles",
                columns: new[] { "Title", "Created", "Content" },
                values: new object[] {
                        "Bài viết số 1",
                        new DateTime(2022,1,23),
                        "Nội dung bài viết số 1"
                }
            );
            migrationBuilder.InsertData(
                table: "articles",
                columns: new string[] { "Title", "Created", "Content" },
                values: new object[]{
                    "Bài viết số 2",
                    new DateTime(2022,1,22),
                    "Nội dung bài viết số 2"
                }
            ); */
            // Insert fake data with bogus
            Randomizer.Seed = new Random(8675309);
            var fakeArticle = new Faker<Article>();
            fakeArticle.RuleFor(a => a.Title, f => f.Lorem.Sentence(10, 5));
            fakeArticle.RuleFor(a => a.Created, f => f.Date.Between(new DateTime(2021, 1, 1), new DateTime(2022, 1, 20)));
            fakeArticle.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(1, 4));

            for (int i = 0; i < 150; i++)
            {
                Article article = fakeArticle.Generate();
                migrationBuilder.InsertData(
                    table: "articles",
                    columns: new string[] { "Title", "Created", "Content" },
                    values: new object[]{
                    article.Title,
                    article.Created,
                    article.Content
                    }
                );
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "articles");
        }
    }
}
