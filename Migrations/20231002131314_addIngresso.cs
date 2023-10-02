using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class addIngresso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingresso",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    preco = table.Column<float>(type: "REAL", nullable: false),
                    Eventoid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingresso", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ingresso_Evento_Eventoid",
                        column: x => x.Eventoid,
                        principalTable: "Evento",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingresso_Eventoid",
                table: "Ingresso",
                column: "Eventoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingresso");
        }
    }
}
