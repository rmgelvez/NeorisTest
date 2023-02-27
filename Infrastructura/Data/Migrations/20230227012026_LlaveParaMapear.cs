using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructura.Data.Migrations
{
    /// <inheritdoc />
    public partial class LlaveParaMapear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Personas_ClienteId",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Cuentas_CuentaId",
                table: "Movimientos");

            migrationBuilder.AlterColumn<int>(
                name: "CuentaId",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Cuentas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Personas_ClienteId",
                table: "Cuentas",
                column: "ClienteId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Cuentas_CuentaId",
                table: "Movimientos",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Personas_ClienteId",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Cuentas_CuentaId",
                table: "Movimientos");

            migrationBuilder.AlterColumn<int>(
                name: "CuentaId",
                table: "Movimientos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Cuentas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Personas_ClienteId",
                table: "Cuentas",
                column: "ClienteId",
                principalTable: "Personas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Cuentas_CuentaId",
                table: "Movimientos",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id");
        }
    }
}
