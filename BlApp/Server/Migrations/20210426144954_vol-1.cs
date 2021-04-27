using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlApp.Server.Migrations
{
    public partial class vol1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    connectionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastonline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    online = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    messag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seen = table.Column<bool>(type: "bit", nullable: false),
                    sendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    senderid = table.Column<int>(type: "int", nullable: true),
                    targetid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messag", x => x.id);
                    table.ForeignKey(
                        name: "FK_messag_user_senderid",
                        column: x => x.senderid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_messag_user_targetid",
                        column: x => x.targetid,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_messag_senderid",
                table: "messag",
                column: "senderid");

            migrationBuilder.CreateIndex(
                name: "IX_messag_targetid",
                table: "messag",
                column: "targetid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messag");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
