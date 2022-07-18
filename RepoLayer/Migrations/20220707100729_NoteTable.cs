using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepoLayer.Migrations
{
    public partial class NoteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotesTable",
                columns: table => new
                {
                    NoteId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    reminder = table.Column<DateTime>(nullable: false),
                    color = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    isArchived = table.Column<bool>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false),
                    isPinned = table.Column<bool>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: true),
                    editedAt = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotesTable", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_NotesTable_UserEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntity",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotesTable_UserId",
                table: "NotesTable",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotesTable");
        }
    }
}
