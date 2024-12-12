using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroVentasEnterprise.Migrations
{
    /// <inheritdoc />
    public partial class MacroVentas3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Cliente_ClienteIdCliente",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_ClienteIdCliente",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Ventas");

            migrationBuilder.AddColumn<long>(
                name: "IdCliente",
                table: "Ventas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_IdCliente",
                table: "Ventas",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Cliente_IdCliente",
                table: "Ventas",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Cliente_IdCliente",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_IdCliente",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "User");

            migrationBuilder.AddColumn<long>(
                name: "ClienteIdCliente",
                table: "Ventas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_ClienteIdCliente",
                table: "Ventas",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Cliente_ClienteIdCliente",
                table: "Ventas",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente");
        }
    }
}
