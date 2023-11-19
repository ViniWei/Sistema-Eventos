using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class IngressosDiponiveisEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngressosDisponiveis",
                table: "Evento",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngressosDisponiveis",
                table: "Evento");
        }
    }
}
