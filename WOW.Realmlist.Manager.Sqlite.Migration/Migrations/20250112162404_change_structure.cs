using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOW.RealmList.Manager.Sqlite.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class change_structure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_server_ServerId",
                table: "account");

            migrationBuilder.RenameColumn(
                name: "ServerId",
                table: "account",
                newName: "RealmListId");

            migrationBuilder.RenameIndex(
                name: "IX_account_ServerId",
                table: "account",
                newName: "IX_account_RealmListId");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "realm_list",
                type: "TEXT",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_account_realm_list_RealmListId",
                table: "account",
                column: "RealmListId",
                principalTable: "realm_list",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_realm_list_RealmListId",
                table: "account");

            migrationBuilder.DropColumn(
                name: "address",
                table: "realm_list");

            migrationBuilder.RenameColumn(
                name: "RealmListId",
                table: "account",
                newName: "ServerId");

            migrationBuilder.RenameIndex(
                name: "IX_account_RealmListId",
                table: "account",
                newName: "IX_account_ServerId");

            migrationBuilder.AddForeignKey(
                name: "FK_account_server_ServerId",
                table: "account",
                column: "ServerId",
                principalTable: "server",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
