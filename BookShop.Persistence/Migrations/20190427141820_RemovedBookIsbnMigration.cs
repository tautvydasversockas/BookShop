using Microsoft.EntityFrameworkCore.Migrations;

namespace BookShop.Persistence.Migrations
{
    public partial class RemovedBookIsbnMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isbn",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Isbn",
                table: "Books",
                nullable: true);
        }
    }
}
