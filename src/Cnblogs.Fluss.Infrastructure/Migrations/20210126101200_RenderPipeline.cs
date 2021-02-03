using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cnblogs.Fluss.Infrastructure.Migrations
{
    public partial class RenderPipeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_content_block_blog_content_block_Refer",
                table: "blog_content_block");

            migrationBuilder.DropTable(
                name: "blog_post_content");

            migrationBuilder.DropIndex(
                name: "IX_blog_content_block_Refer",
                table: "blog_content_block");

            migrationBuilder.DropColumn(
                name: "Refer",
                table: "blog_content_block");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "blog_content_block",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PostId",
                table: "blog_content_block",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "blog_content_render_config",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentBlockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RendererId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    RendererData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    BlogPostId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_content_render_config", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blog_content_render_config_blog_content_block_ContentBlockId",
                        column: x => x.ContentBlockId,
                        principalTable: "blog_content_block",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blog_content_render_config_blog_post_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "blog_post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blog_content_block_PostId",
                table: "blog_content_block",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_blog_content_render_config_BlogPostId",
                table: "blog_content_render_config",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_blog_content_render_config_ContentBlockId",
                table: "blog_content_render_config",
                column: "ContentBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_blog_content_block_blog_post_PostId",
                table: "blog_content_block",
                column: "PostId",
                principalTable: "blog_post",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_content_block_blog_post_PostId",
                table: "blog_content_block");

            migrationBuilder.DropTable(
                name: "blog_content_render_config");

            migrationBuilder.DropIndex(
                name: "IX_blog_content_block_PostId",
                table: "blog_content_block");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "blog_content_block");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "blog_content_block");

            migrationBuilder.AddColumn<Guid>(
                name: "Refer",
                table: "blog_content_block",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "blog_post_content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContentBlockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    IsExist = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<long>(type: "bigint", nullable: false)
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
                name: "IX_blog_content_block_Refer",
                table: "blog_content_block",
                column: "Refer");

            migrationBuilder.CreateIndex(
                name: "IX_blog_post_content_ContentBlockId_IsExist",
                table: "blog_post_content",
                columns: new[] { "ContentBlockId", "IsExist" });

            migrationBuilder.CreateIndex(
                name: "IX_blog_post_content_PostId_IsExist",
                table: "blog_post_content",
                columns: new[] { "PostId", "IsExist" });

            migrationBuilder.AddForeignKey(
                name: "FK_blog_content_block_blog_content_block_Refer",
                table: "blog_content_block",
                column: "Refer",
                principalTable: "blog_content_block",
                principalColumn: "Id");
        }
    }
}
