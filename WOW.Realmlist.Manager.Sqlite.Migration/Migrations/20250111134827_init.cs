using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WOW.RealmList.Manager.Sqlite.Migrations.Migrations
{
    /// <inheritdoc />
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    public partial class init : Migration
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "server",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_server", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    login = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    password = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    ServerId = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.id);
                    table.ForeignKey(
                        name: "FK_account_server_ServerId",
                        column: x => x.ServerId,
                        principalTable: "server",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "realm_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    login = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: true),
                    ServerId = table.Column<int>(type: "INTEGER", nullable: false),
                    created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_realm_list", x => x.id);
                    table.ForeignKey(
                        name: "FK_realm_list_server_ServerId",
                        column: x => x.ServerId,
                        principalTable: "server",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_account_ServerId",
                table: "account",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_realm_list_ServerId",
                table: "realm_list",
                column: "ServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "realm_list");

            migrationBuilder.DropTable(
                name: "server");
        }
    }
}
