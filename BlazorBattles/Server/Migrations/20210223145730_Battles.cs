using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorBattles.Server.Migrations
{
    public partial class Battles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Battles",
                table => new
                {
                    Id = table.Column<int>("INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AttackerId = table.Column<int>("INTEGER", nullable: false),
                    OpponentId = table.Column<int>("INTEGER", nullable: false),
                    WinnerId = table.Column<int>("INTEGER", nullable: false),
                    WinnerDamage = table.Column<int>("INTEGER", nullable: false),
                    RoundsFought = table.Column<int>("INTEGER", nullable: false),
                    BattleDate = table.Column<DateTime>("TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => x.Id);
                    table.ForeignKey(
                        "FK_Battles_Users_AttackerId",
                        x => x.AttackerId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Battles_Users_OpponentId",
                        x => x.OpponentId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Battles_Users_WinnerId",
                        x => x.WinnerId,
                        "Users",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Battles_AttackerId",
                "Battles",
                "AttackerId");

            migrationBuilder.CreateIndex(
                "IX_Battles_OpponentId",
                "Battles",
                "OpponentId");

            migrationBuilder.CreateIndex(
                "IX_Battles_WinnerId",
                "Battles",
                "WinnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Battles");
        }
    }
}