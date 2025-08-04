using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniTrello_Hahn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTableBoardList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardList_Boards_BoardId",
                table: "BoardList");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_BoardList_BoardListId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_BoardListId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardList",
                table: "BoardList");

            migrationBuilder.DropColumn(
                name: "BoardListId",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "BoardList",
                newName: "BoardLists");

            migrationBuilder.RenameIndex(
                name: "IX_BoardList_BoardId",
                table: "BoardLists",
                newName: "IX_BoardLists_BoardId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BoardLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardLists",
                table: "BoardLists",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_ListId",
                table: "Cards",
                column: "ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardLists_Boards_BoardId",
                table: "BoardLists",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_BoardLists_ListId",
                table: "Cards",
                column: "ListId",
                principalTable: "BoardLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardLists_Boards_BoardId",
                table: "BoardLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_BoardLists_ListId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_ListId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoardLists",
                table: "BoardLists");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BoardLists");

            migrationBuilder.RenameTable(
                name: "BoardLists",
                newName: "BoardList");

            migrationBuilder.RenameIndex(
                name: "IX_BoardLists_BoardId",
                table: "BoardList",
                newName: "IX_BoardList_BoardId");

            migrationBuilder.AddColumn<Guid>(
                name: "BoardListId",
                table: "Cards",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoardList",
                table: "BoardList",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BoardListId",
                table: "Cards",
                column: "BoardListId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardList_Boards_BoardId",
                table: "BoardList",
                column: "BoardId",
                principalTable: "Boards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_BoardList_BoardListId",
                table: "Cards",
                column: "BoardListId",
                principalTable: "BoardList",
                principalColumn: "Id");
        }
    }
}
