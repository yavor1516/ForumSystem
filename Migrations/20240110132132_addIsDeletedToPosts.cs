using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumSystem.Migrations
{
    public partial class addIsDeletedToPosts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Posts",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Posts");
        }
    }
}
