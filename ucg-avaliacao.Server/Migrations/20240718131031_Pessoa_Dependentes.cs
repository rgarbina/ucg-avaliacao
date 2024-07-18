using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ucg_avaliacao.Server.Migrations
{
    /// <inheritdoc />
    public partial class Pessoa_Dependentes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dependente",
                schema: "dbo",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDependente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DependenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependente", x => new { x.IdPessoa, x.IdDependente });
                    table.ForeignKey(
                        name: "FK_dependente_pessoa_DependenteId",
                        column: x => x.DependenteId,
                        principalSchema: "dbo",
                        principalTable: "pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dependente_pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalSchema: "dbo",
                        principalTable: "pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_dependente_DependenteId",
                schema: "dbo",
                table: "dependente",
                column: "DependenteId");

            migrationBuilder.CreateIndex(
                name: "IX_dependente_PessoaId",
                schema: "dbo",
                table: "dependente",
                column: "PessoaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dependente",
                schema: "dbo");
        }
    }
}
