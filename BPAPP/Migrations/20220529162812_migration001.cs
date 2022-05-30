using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BPAPP.Migrations
{
    public partial class migration001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Clientes_IdCliente",
                table: "Cuentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Clientes_IdCliente",
                table: "Cuentas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Clientes_IdCliente",
                table: "Cuentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "IdPersona");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Clientes_IdCliente",
                table: "Cuentas",
                column: "IdCliente",
                principalTable: "Clientes",
                principalColumn: "IdPersona");
        }
    }
}
