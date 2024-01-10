using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumSystem.Migrations
{
    public partial class fixBigLetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Posts",
                newName: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Posts",
                newName: "isDeleted");
        }
    }
}
