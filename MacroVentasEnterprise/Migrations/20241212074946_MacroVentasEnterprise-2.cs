using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MacroVentasEnterprise.Migrations
{
    /// <inheritdoc />
    public partial class MacroVentasEnterprise2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalle_Producto_ProductoIdProducto",
                table: "VentaDetalle");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "UsuarioEliminacion",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "VentaDetalle");

            migrationBuilder.DropColumn(
                name: "UsuarioEliminacion",
                table: "VentaDetalle");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "VentaDetalle");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "UsuarioEliminacion",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UsuarioEliminacion",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UsuarioCreacion",
                table: "CategoriaProductos");

            migrationBuilder.DropColumn(
                name: "UsuarioEliminacion",
                table: "CategoriaProductos");

            migrationBuilder.DropColumn(
                name: "UsuarioModificacion",
                table: "CategoriaProductos");

            migrationBuilder.RenameColumn(
                name: "ProductoIdProducto",
                table: "VentaDetalle",
                newName: "IdProducto");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalle_ProductoIdProducto",
                table: "VentaDetalle",
                newName: "IX_VentaDetalle_IdProducto");

            migrationBuilder.RenameColumn(
                name: "Contraseña",
                table: "User",
                newName: "Contrasenia");

            migrationBuilder.AlterColumn<decimal>(
                name: "Cantidad",
                table: "VentaDetalle",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEliminacion",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaModificacion",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalle_Producto_IdProducto",
                table: "VentaDetalle",
                column: "IdProducto",
                principalTable: "Producto",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalle_Producto_IdProducto",
                table: "VentaDetalle");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FechaEliminacion",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FechaModificacion",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "VentaDetalle",
                newName: "ProductoIdProducto");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalle_IdProducto",
                table: "VentaDetalle",
                newName: "IX_VentaDetalle_ProductoIdProducto");

            migrationBuilder.RenameColumn(
                name: "Contrasenia",
                table: "User",
                newName: "Contraseña");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "Ventas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEliminacion",
                table: "Ventas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacion",
                table: "Ventas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "VentaDetalle",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "VentaDetalle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEliminacion",
                table: "VentaDetalle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacion",
                table: "VentaDetalle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEliminacion",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacion",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEliminacion",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacion",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCreacion",
                table: "CategoriaProductos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioEliminacion",
                table: "CategoriaProductos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioModificacion",
                table: "CategoriaProductos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalle_Producto_ProductoIdProducto",
                table: "VentaDetalle",
                column: "ProductoIdProducto",
                principalTable: "Producto",
                principalColumn: "IdProducto",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
