using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace workshare.clientes.data.Migrations
{
    public partial class Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(500)", nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Cpf_Numero = table.Column<string>(type: "varchar(11)", nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
