using Microsoft.EntityFrameworkCore.Migrations;

namespace RepoLayer.Migrations
{
    public partial class NotesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotesTable_UserEntity_UserId",
                table: "NotesTable");

            migrationBuilder.DropIndex(
                name: "IX_NotesTable_UserId",
                table: "NotesTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NotesTable");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "NotesTable",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_NotesTable_Id",
                table: "NotesTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NotesTable_UserEntity_Id",
                table: "NotesTable",
                column: "Id",
                principalTable: "UserEntity",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotesTable_UserEntity_Id",
                table: "NotesTable");

            migrationBuilder.DropIndex(
                name: "IX_NotesTable_Id",
                table: "NotesTable");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "NotesTable");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "NotesTable",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_NotesTable_UserId",
                table: "NotesTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotesTable_UserEntity_UserId",
                table: "NotesTable",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
