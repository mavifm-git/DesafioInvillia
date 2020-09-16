using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafio.Data.Migrations
{
    public partial class AjusteData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataDevolucao",
                table: "Emprestimo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataDevolucao",
                table: "Emprestimo");
        }
    }
}
