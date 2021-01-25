using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cnblogs.Fluss.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog_site",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePageSize = table.Column<int>(type: "int", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_site", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blog_content_block",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    Refer = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Raw = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IsExist = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_content_block", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blog_content_block_blog_content_block_Refer",
                        column: x => x.Refer,
                        principalTable: "blog_content_block",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blog_content_block_blog_site_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blog_site",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "blog_post",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AutoDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blog_post_blog_site_BlogId",
                        column: x => x.BlogId,
                        principalTable: "blog_site",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "blog_post_content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    ContentBlockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_post_content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blog_post_content_blog_content_block_ContentBlockId",
                        column: x => x.ContentBlockId,
                        principalTable: "blog_content_block",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blog_post_content_blog_post_PostId",
                        column: x => x.PostId,
                        principalTable: "blog_post",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_blog_content_block_BlogId",
                table: "blog_content_block",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_blog_content_block_Refer",
                table: "blog_content_block",
                column: "Refer");

            migrationBuilder.CreateIndex(
                name: "IX_blog_post_BlogId_IsExist_IsPublished_DateCreated",
                table: "blog_post",
                columns: new[] { "BlogId", "IsExist", "IsPublished", "DateCreated" });

            migrationBuilder.CreateIndex(
                name: "IX_blog_post_content_ContentBlockId_IsExist",
                table: "blog_post_content",
                columns: new[] { "ContentBlockId", "IsExist" });

            migrationBuilder.CreateIndex(
                name: "IX_blog_post_content_PostId_IsExist",
                table: "blog_post_content",
                columns: new[] { "PostId", "IsExist" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog_post_content");

            migrationBuilder.DropTable(
                name: "blog_content_block");

            migrationBuilder.DropTable(
                name: "blog_post");

            migrationBuilder.DropTable(
                name: "blog_site");
        }
    }
}
