using Microsoft.EntityFrameworkCore.Migrations;

namespace VideosManagementSystem.Data.Migrations
{
    public partial class recordsedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_User_UserName1",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Video_VideoNameVideoId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_UserName1",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_VideoNameVideoId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "UserName1",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "VideoNameVideoId",
                table: "Records");

            migrationBuilder.AlterColumn<string>(
                name: "VideoImage",
                table: "Video",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UsersUserName",
                table: "Records",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideosVideoId",
                table: "Records",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_UsersUserName",
                table: "Records",
                column: "UsersUserName");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VideosVideoId",
                table: "Records",
                column: "VideosVideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_User_UsersUserName",
                table: "Records",
                column: "UsersUserName",
                principalTable: "User",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Video_VideosVideoId",
                table: "Records",
                column: "VideosVideoId",
                principalTable: "Video",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_User_UsersUserName",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Video_VideosVideoId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_UsersUserName",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_VideosVideoId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "UsersUserName",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "VideosVideoId",
                table: "Records");

            migrationBuilder.AlterColumn<string>(
                name: "VideoImage",
                table: "Video",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName1",
                table: "Records",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoNameVideoId",
                table: "Records",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_UserName1",
                table: "Records",
                column: "UserName1");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VideoNameVideoId",
                table: "Records",
                column: "VideoNameVideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_User_UserName1",
                table: "Records",
                column: "UserName1",
                principalTable: "User",
                principalColumn: "UserName",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Video_VideoNameVideoId",
                table: "Records",
                column: "VideoNameVideoId",
                principalTable: "Video",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
