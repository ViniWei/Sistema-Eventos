using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Eventos.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evento",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Organizador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizador", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    senha = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false),
                    dataNascimento = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    cpf = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Atuante",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    OrganizadorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atuante", x => x.id);
                    table.ForeignKey(
                        name: "FK_Atuante_Organizador_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Organizador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    preco = table.Column<float>(type: "REAL", nullable: false),
                    Eventoid = table.Column<int>(type: "INTEGER", nullable: true),
                    OrganizadorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kit_Evento_Eventoid",
                        column: x => x.Eventoid,
                        principalTable: "Evento",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Kit_Organizador_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Organizador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    endereco = table.Column<string>(type: "TEXT", nullable: false),
                    capacidade = table.Column<int>(type: "INTEGER", nullable: false),
                    OrganizadorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Local_Organizador_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Organizador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    preco = table.Column<float>(type: "REAL", nullable: false),
                    Eventoid = table.Column<int>(type: "INTEGER", nullable: true),
                    OrganizadorId = table.Column<int>(type: "INTEGER", nullable: true),
                    Usuarioid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.id);
                    table.ForeignKey(
                        name: "FK_Plano_Evento_Eventoid",
                        column: x => x.Eventoid,
                        principalTable: "Evento",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Plano_Organizador_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Organizador",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plano_Usuario_Usuarioid",
                        column: x => x.Usuarioid,
                        principalTable: "Usuario",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    preco = table.Column<float>(type: "REAL", nullable: false),
                    Eventoid = table.Column<int>(type: "INTEGER", nullable: true),
                    KitId = table.Column<int>(type: "INTEGER", nullable: true),
                    OrganizadorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produto_Evento_Eventoid",
                        column: x => x.Eventoid,
                        principalTable: "Evento",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Produto_Kit_KitId",
                        column: x => x.KitId,
                        principalTable: "Kit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Produto_Organizador_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Organizador",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atuante_OrganizadorId",
                table: "Atuante",
                column: "OrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Kit_Eventoid",
                table: "Kit",
                column: "Eventoid");

            migrationBuilder.CreateIndex(
                name: "IX_Kit_OrganizadorId",
                table: "Kit",
                column: "OrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Local_OrganizadorId",
                table: "Local",
                column: "OrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Plano_Eventoid",
                table: "Plano",
                column: "Eventoid");

            migrationBuilder.CreateIndex(
                name: "IX_Plano_OrganizadorId",
                table: "Plano",
                column: "OrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Plano_Usuarioid",
                table: "Plano",
                column: "Usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Eventoid",
                table: "Produto",
                column: "Eventoid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_KitId",
                table: "Produto",
                column: "KitId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_OrganizadorId",
                table: "Produto",
                column: "OrganizadorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atuante");

            migrationBuilder.DropTable(
                name: "Local");

            migrationBuilder.DropTable(
                name: "Plano");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Kit");

            migrationBuilder.DropTable(
                name: "Evento");

            migrationBuilder.DropTable(
                name: "Organizador");
        }
    }
}
