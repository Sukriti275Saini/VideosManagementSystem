using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideosManagementSystem.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    FeedbackId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Suggestions = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.FeedbackId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    FullName = table.Column<string>(maxLength: 30, nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ConfirmPassword = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    VideoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoName = table.Column<string>(nullable: false),
                    YearOfRelease = table.Column<int>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Actor = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NoOfCopies = table.Column<int>(nullable: false),
                    LeaseAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.VideoId);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName1 = table.Column<string>(nullable: true),
                    BlogTitle = table.Column<string>(nullable: true),
                    BlogDescription = table.Column<string>(nullable: true),
                    BlogLikes = table.Column<int>(nullable: false),
                    BlogDislikes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blog_User_UserName1",
                        column: x => x.UserName1,
                        principalTable: "User",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName1 = table.Column<string>(nullable: true),
                    VideoNameVideoId = table.Column<int>(nullable: true),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    DueAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_User_UserName1",
                        column: x => x.UserName1,
                        principalTable: "User",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Records_Video_VideoNameVideoId",
                        column: x => x.VideoNameVideoId,
                        principalTable: "Video",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UserName1",
                table: "Blog",
                column: "UserName1");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserName1",
                table: "Records",
                column: "UserName1");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VideoNameVideoId",
                table: "Records",
                column: "VideoNameVideoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Video");
        }
    }
}
