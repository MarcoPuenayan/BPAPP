using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BPAPP.Migrations
{
    public partial class migration002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoMovimiento",
                table: "Movimientos",
                newName: "Tipo");

            migrationBuilder.AddColumn<string>(
                name: "Movimientos",
                table: "Movimientos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "LimiteDiario",
                table: "Cuentas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Movimientos",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "LimiteDiario",
                table: "Cuentas");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Movimientos",
                newName: "TipoMovimiento");
        }
    }
}
