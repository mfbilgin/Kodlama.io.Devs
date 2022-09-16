using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddLanguageTechnology : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LanguageTechnologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageTechnologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageTechnologies_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LanguageTechnologies",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[] { 1, 1, "WPF" });

            migrationBuilder.InsertData(
                table: "LanguageTechnologies",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[] { 2, 2, "Spring" });

            migrationBuilder.InsertData(
                table: "LanguageTechnologies",
                columns: new[] { "Id", "LanguageId", "Name" },
                values: new object[] { 3, 5, "Laravel" });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageTechnologies_LanguageId",
                table: "LanguageTechnologies",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageTechnologies");
        }
    }
}
