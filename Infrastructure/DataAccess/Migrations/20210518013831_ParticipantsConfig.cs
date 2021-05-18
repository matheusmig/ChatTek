using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.DataAccess.Migrations
{
    public partial class ParticipantsConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConversationId",
                table: "Participants",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ConversationId",
                table: "Participants",
                column: "ConversationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Conversations_ConversationId",
                table: "Participants",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Conversations_ConversationId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ConversationId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ConversationId",
                table: "Participants");
        }
    }
}
