using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumSystem.Migrations
{
    public partial class addforeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Posts_PostID",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_PostID",
                table: "Tags",
                newName: "IX_Tags_PostID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Posts_PostID",
                table: "Tags",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Posts_PostID",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_PostID",
                table: "Tag",
                newName: "IX_Tag_PostID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "TagID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Posts_PostID",
                table: "Tag",
                column: "PostID",
                principalTable: "Posts",
                principalColumn: "PostID");
        }
    }
}
