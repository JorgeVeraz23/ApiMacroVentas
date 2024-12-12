using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroVentasEnterprise.Migrations
{
    /// <inheritdoc />
    public partial class MacroVentas4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_CategoriaProductos_CategoriaProductoIdCategoriaProducto",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_CategoriaProductoIdCategoriaProducto",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "CategoriaProductoIdCategoriaProducto",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "EsGravadoConIVA",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "TasaIVA",
                table: "Producto");

            migrationBuilder.AddColumn<long>(
                name: "IdCategoria",
                table: "Producto",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_CategoriaProductos_IdCategoria",
                table: "Producto",
                column: "IdCategoria",
                principalTable: "CategoriaProductos",
                principalColumn: "IdCategoriaProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_CategoriaProductos_IdCategoria",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "IdCategoria",
                table: "Producto");

            migrationBuilder.AddColumn<long>(
                name: "CategoriaProductoIdCategoriaProducto",
                table: "Producto",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EsGravadoConIVA",
                table: "Producto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TasaIVA",
                table: "Producto",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CategoriaProductoIdCategoriaProducto",
                table: "Producto",
                column: "CategoriaProductoIdCategoriaProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_CategoriaProductos_CategoriaProductoIdCategoriaProducto",
                table: "Producto",
                column: "CategoriaProductoIdCategoriaProducto",
                principalTable: "CategoriaProductos",
                principalColumn: "IdCategoriaProducto");
        }
    }
}
