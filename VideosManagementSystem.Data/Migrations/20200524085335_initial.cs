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
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EmailId = table.Column<string>(nullable: false),
                    AppReview = table.Column<string>(nullable: false),
                    Suggestions = table.Column<string>(nullable: false)
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
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 30, nullable: false),
                    PhoneNo = table.Column<long>(nullable: false),
                    Address = table.Column<string>(maxLength: 500, nullable: false)
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
                    VideoName = table.Column<string>(maxLength: 50, nullable: false),
                    YearOfRelease = table.Column<int>(nullable: false),
                    Language = table.Column<string>(maxLength: 40, nullable: false),
                    Director = table.Column<string>(maxLength: 30, nullable: false),
                    Actor = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    NoOfCopies = table.Column<int>(nullable: false),
                    LeaseAmount = table.Column<int>(nullable: false),
                    VideoImage = table.Column<string>(nullable: true)
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
                    UsersUserName = table.Column<string>(nullable: false),
                    BlogTitle = table.Column<string>(nullable: false),
                    BlogDescription = table.Column<string>(nullable: false),
                    BlogImage = table.Column<string>(nullable: true),
                    Blogcontent = table.Column<string>(nullable: false),
                    BlogDate = table.Column<DateTime>(nullable: false),
                    BlogLikes = table.Column<int>(nullable: false),
                    BlogDislikes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogId);
                    table.ForeignKey(
                        name: "FK_Blog_User_UsersUserName",
                        column: x => x.UsersUserName,
                        principalTable: "User",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsersUserName = table.Column<string>(nullable: false),
                    VideosVideoId = table.Column<int>(nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: false),
                    DueAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_User_UsersUserName",
                        column: x => x.UsersUserName,
                        principalTable: "User",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Video_VideosVideoId",
                        column: x => x.VideosVideoId,
                        principalTable: "Video",
                        principalColumn: "VideoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserName", "Address", "DateOfBirth", "Email", "FullName", "Password", "PhoneNo", "ProfilePicture" },
                values: new object[] { "Sukriti275Saini", "Pathankot", new DateTime(1995, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "s@s.in", "Sukriti Saini", "Saini123", 7418529630L, "" });

            migrationBuilder.InsertData(
                table: "Video",
                columns: new[] { "VideoId", "Actor", "Description", "Director", "Language", "LeaseAmount", "NoOfCopies", "VideoImage", "VideoName", "YearOfRelease" },
                values: new object[] { 1, "COVID-19", "MKC Corona ki", "China", "Chinese", 200, 2, "", "Corona ka rona", 2020 });

            migrationBuilder.CreateIndex(
                name: "IX_Blog_UsersUserName",
                table: "Blog",
                column: "UsersUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Records_UsersUserName",
                table: "Records",
                column: "UsersUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VideosVideoId",
                table: "Records",
                column: "VideosVideoId");
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
