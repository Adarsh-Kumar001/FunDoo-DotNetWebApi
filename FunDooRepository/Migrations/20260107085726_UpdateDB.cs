using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunDooRepository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelNote");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Notes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Notes",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Notes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LabelId",
                table: "Notes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LabelNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoteId = table.Column<int>(type: "int", nullable: false),
                    LabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabelNotes_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "LabelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabelNotes_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LabelId",
                table: "Notes",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelNotes_LabelId",
                table: "LabelNotes",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelNotes_NoteId",
                table: "LabelNotes",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Labels_LabelId",
                table: "Notes",
                column: "LabelId",
                principalTable: "Labels",
                principalColumn: "LabelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Labels_LabelId",
                table: "Notes");

            migrationBuilder.DropTable(
                name: "LabelNotes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_LabelId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LabelId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Notes",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notes",
                newName: "NoteId");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateTable(
                name: "LabelNote",
                columns: table => new
                {
                    LabelId = table.Column<int>(type: "int", nullable: false),
                    NoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelNote", x => new { x.LabelId, x.NoteId });
                    table.ForeignKey(
                        name: "FK_LabelNote_Labels_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Labels",
                        principalColumn: "LabelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LabelNote_Notes_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Notes",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelNote_NoteId",
                table: "LabelNote",
                column: "NoteId");
        }
    }
}
