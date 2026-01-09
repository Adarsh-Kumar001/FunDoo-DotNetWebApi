using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunDooRepository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCollaborator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CollaboratorEmail",
                table: "Collaborators",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "OwnerUserId",
                table: "Collaborators",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Collaborators_OwnerUserId",
                table: "Collaborators",
                column: "OwnerUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collaborators_Users_OwnerUserId",
                table: "Collaborators",
                column: "OwnerUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collaborators_Users_OwnerUserId",
                table: "Collaborators");

            migrationBuilder.DropIndex(
                name: "IX_Collaborators_OwnerUserId",
                table: "Collaborators");

            migrationBuilder.DropColumn(
                name: "OwnerUserId",
                table: "Collaborators");

            migrationBuilder.AlterColumn<string>(
                name: "CollaboratorEmail",
                table: "Collaborators",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
