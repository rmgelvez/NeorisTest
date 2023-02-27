using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructura.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreacionForeingKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CuentaId",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "Estado",
                table: "Cuentas",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Cuentas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_CuentaId",
                table: "Movimientos",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_ClienteId",
                table: "Cuentas",
                column: "ClienteId");

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

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_CuentaId",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Cuentas_ClienteId",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "CuentaId",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cuentas");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Cuentas",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
