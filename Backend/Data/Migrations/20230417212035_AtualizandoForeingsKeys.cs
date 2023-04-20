using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AtualizandoForeingsKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserHasCards_GameHasUser_GameId",
                table: "UserHasCards");

            migrationBuilder.DropIndex(
                name: "IX_UserHasCards_GameId",
                table: "UserHasCards");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "UserHasCards");

            migrationBuilder.RenameColumn(
                name: "idUserHasCards",
                table: "GameHasUser",
                newName: "UserHasCardsId");

            migrationBuilder.CreateIndex(
                name: "IX_GameHasUser_UserHasCardsId",
                table: "GameHasUser",
                column: "UserHasCardsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameHasUser_UserHasCards_UserHasCardsId",
                table: "GameHasUser",
                column: "UserHasCardsId",
                principalTable: "UserHasCards",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameHasUser_UserHasCards_UserHasCardsId",
                table: "GameHasUser");

            migrationBuilder.DropIndex(
                name: "IX_GameHasUser_UserHasCardsId",
                table: "GameHasUser");

            migrationBuilder.RenameColumn(
                name: "UserHasCardsId",
                table: "GameHasUser",
                newName: "idUserHasCards");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "UserHasCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserHasCards_GameId",
                table: "UserHasCards",
                column: "GameId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHasCards_GameHasUser_GameId",
                table: "UserHasCards",
                column: "GameId",
                principalTable: "GameHasUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
