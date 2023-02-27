using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructura.Data.Migrations
{
    /// <inheritdoc />
    public partial class ClientesTablaArreglo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Personas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Personas",
                type: "int",
                nullable: true);
        }
    }
}
