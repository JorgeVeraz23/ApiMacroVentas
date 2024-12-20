﻿// <auto-generated />
using System;
using MacroVentasEnterprise;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MacroVentasEnterprise.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241212074946_MacroVentasEnterprise-2")]
    partial class MacroVentasEnterprise2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MacroVentasEnterprise.Data.CategoriaProducto", b =>
                {
                    b.Property<long>("IdCategoriaProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdCategoriaProducto"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCategoriaProducto");

                    b.ToTable("CategoriaProductos");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.Cliente", b =>
                {
                    b.Property<long>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdCliente"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.Producto", b =>
                {
                    b.Property<long>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdProducto"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<long?>("CategoriaProductoIdCategoriaProducto")
                        .HasColumnType("bigint");

                    b.Property<int>("CodigoProducto")
                        .HasColumnType("int");

                    b.Property<bool>("EsGravadoConIVA")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<decimal?>("TasaIVA")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdProducto");

                    b.HasIndex("CategoriaProductoIdCategoriaProducto");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.Usuario", b =>
                {
                    b.Property<long>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdUsuario"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Contrasenia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identitificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("User");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.VentaDetalle", b =>
                {
                    b.Property<long>("IdVentaDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdVentaDetalle"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<long>("IdProducto")
                        .HasColumnType("bigint");

                    b.Property<long>("IdVentas")
                        .HasColumnType("bigint");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdVentaDetalle");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdVentas");

                    b.ToTable("VentaDetalle");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.Ventas", b =>
                {
                    b.Property<long>("IdVentas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdVentas"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<long?>("ClienteIdCliente")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("IVA")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalVenta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("IdVentas");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("UserId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.Producto", b =>
                {
                    b.HasOne("MacroVentasEnterprise.Data.CategoriaProducto", null)
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaProductoIdCategoriaProducto");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.VentaDetalle", b =>
                {
                    b.HasOne("MacroVentasEnterprise.Data.Producto", "Producto")
                        .WithMany("VentaDetalles")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MacroVentasEnterprise.Data.Ventas", "Ventas")
                        .WithMany("VentaDetalles")
                        .HasForeignKey("IdVentas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.Ventas", b =>
                {
                    b.HasOne("MacroVentasEnterprise.Data.Cliente", null)
                        .WithMany("Ventas")
                        .HasForeignKey("ClienteIdCliente");

                    b.HasOne("MacroVentasEnterprise.Data.Usuario", "User")
                        .WithMany("VentasDeUsuario")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.CategoriaProducto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.Cliente", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.Producto", b =>
                {
                    b.Navigation("VentaDetalles");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.Usuario", b =>
                {
                    b.Navigation("VentasDeUsuario");
                });

            modelBuilder.Entity("MacroVentasEnterprise.Data.Ventas", b =>
                {
                    b.Navigation("VentaDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
