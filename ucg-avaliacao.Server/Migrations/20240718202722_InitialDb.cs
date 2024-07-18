using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ucg_avaliacao.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "pessoa",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newid()"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Nascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    RG = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dependente",
                schema: "dbo",
                columns: table => new
                {
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdDependente = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dependente", x => new { x.IdPessoa, x.IdDependente });
                    table.ForeignKey(
                        name: "FK_dependente_pessoa_IdDependente",
                        column: x => x.IdDependente,
                        principalSchema: "dbo",
                        principalTable: "pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_dependente_IdDependente",
                schema: "dbo",
                table: "dependente",
                column: "IdDependente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dependente",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "pessoa",
                schema: "dbo");
        }
    }
}
