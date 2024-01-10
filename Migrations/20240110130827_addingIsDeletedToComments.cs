using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumSystem.Migrations
{
    public partial class addingIsDeletedToComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "Comments",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "Comments");
        }
    }
}
