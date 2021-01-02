using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Data.Migrations
{
    public partial class AppUserRole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_PostOwnerId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "MyRole",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PostOwnerId",
                table: "Posts",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PostOwnerId",
                table: "Posts",
                newName: "IX_Posts_AppUserId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Roles_AppUserId",
                table: "Roles",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_AppUserId",
                table: "Posts",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_AppUserId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Posts",
                newName: "PostOwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AppUserId",
                table: "Posts",
                newName: "IX_Posts_PostOwnerId");

            migrationBuilder.AddColumn<int>(
                name: "MyRole",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_PostOwnerId",
                table: "Posts",
                column: "PostOwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
