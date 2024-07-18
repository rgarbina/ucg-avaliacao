using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ucg_avaliacao.Server.Migrations
{
    /// <inheritdoc />
    public partial class Pessoa_CPF_RG_Nascimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                schema: "dbo",
                table: "pessoa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Nascimento",
                schema: "dbo",
                table: "pessoa",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RG",
                schema: "dbo",
                table: "pessoa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                schema: "dbo",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "Nascimento",
                schema: "dbo",
                table: "pessoa");

            migrationBuilder.DropColumn(
                name: "RG",
                schema: "dbo",
                table: "pessoa");
        }
    }
}
