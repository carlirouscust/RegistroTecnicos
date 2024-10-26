using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    articuloId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    costo = table.Column<decimal>(type: "TEXT", nullable: false),
                    precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    existencia = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.articuloId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClientesID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    WhatsApp = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClientesID);
                });

            migrationBuilder.CreateTable(
                name: "Prioridades",
                columns: table => new
                {
                    PrioridadesID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.PrioridadesID);
                });

            migrationBuilder.CreateTable(
                name: "TiposTecnicos",
                columns: table => new
                {
                    TiposTecnicosID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTecnicos", x => x.TiposTecnicosID);
                });

            migrationBuilder.CreateTable(
                name: "Cotizaciones",
                columns: table => new
                {
                    cotizacionesId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClientesID = table.Column<int>(type: "INTEGER", nullable: false),
                    observacion = table.Column<string>(type: "TEXT", nullable: false),
                    monto = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cotizaciones", x => x.cotizacionesId);
                    table.ForeignKey(
                        name: "FK_Cotizaciones_Clientes_ClientesID",
                        column: x => x.ClientesID,
                        principalTable: "Clientes",
                        principalColumn: "ClientesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    TecnicosID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    SueldoHora = table.Column<int>(type: "INTEGER", nullable: false),
                    TiposTecnicosID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnicos", x => x.TecnicosID);
                    table.ForeignKey(
                        name: "FK_Tecnicos_TiposTecnicos_TiposTecnicosID",
                        column: x => x.TiposTecnicosID,
                        principalTable: "TiposTecnicos",
                        principalColumn: "TiposTecnicosID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CotizacionesDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CotizacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<decimal>(type: "TEXT", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    ArticuloId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotizacionesDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_CotizacionesDetalles_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "articuloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CotizacionesDetalles_Cotizaciones_CotizacionId",
                        column: x => x.CotizacionId,
                        principalTable: "Cotizaciones",
                        principalColumn: "cotizacionesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    TrabajosID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Monto = table.Column<int>(type: "INTEGER", nullable: false),
                    TecnicosID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientesID = table.Column<int>(type: "INTEGER", nullable: false),
                    PrioridadesID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.TrabajosID);
                    table.ForeignKey(
                        name: "FK_Trabajos_Clientes_ClientesID",
                        column: x => x.ClientesID,
                        principalTable: "Clientes",
                        principalColumn: "ClientesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajos_Prioridades_PrioridadesID",
                        column: x => x.PrioridadesID,
                        principalTable: "Prioridades",
                        principalColumn: "PrioridadesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajos_Tecnicos_TecnicosID",
                        column: x => x.TecnicosID,
                        principalTable: "Tecnicos",
                        principalColumn: "TecnicosID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrabajosDetalles",
                columns: table => new
                {
                    detalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrabajosID = table.Column<int>(type: "INTEGER", nullable: true),
                    trabajoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticulosarticuloId = table.Column<int>(type: "INTEGER", nullable: true),
                    articuloId = table.Column<int>(type: "INTEGER", nullable: false),
                    cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    costo = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrabajosDetalles", x => x.detalleId);
                    table.ForeignKey(
                        name: "FK_TrabajosDetalles_Articulos_ArticulosarticuloId",
                        column: x => x.ArticulosarticuloId,
                        principalTable: "Articulos",
                        principalColumn: "articuloId");
                    table.ForeignKey(
                        name: "FK_TrabajosDetalles_Trabajos_TrabajosID",
                        column: x => x.TrabajosID,
                        principalTable: "Trabajos",
                        principalColumn: "TrabajosID");
                });

            migrationBuilder.InsertData(
                table: "Articulos",
                columns: new[] { "articuloId", "costo", "descripcion", "existencia", "precio" },
                values: new object[,]
                {
                    { 1, 1200.00m, "Bocina", 50m, 3000.00m },
                    { 2, 35.00m, "Taza", 200m, 70.00m },
                    { 3, 15000.00m, "Laptop", 100m, 35000.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cotizaciones_ClientesID",
                table: "Cotizaciones",
                column: "ClientesID");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionesDetalles_ArticuloId",
                table: "CotizacionesDetalles",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_CotizacionesDetalles_CotizacionId",
                table: "CotizacionesDetalles",
                column: "CotizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_TiposTecnicosID",
                table: "Tecnicos",
                column: "TiposTecnicosID");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_ClientesID",
                table: "Trabajos",
                column: "ClientesID");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_PrioridadesID",
                table: "Trabajos",
                column: "PrioridadesID");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_TecnicosID",
                table: "Trabajos",
                column: "TecnicosID");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajosDetalles_ArticulosarticuloId",
                table: "TrabajosDetalles",
                column: "ArticulosarticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_TrabajosDetalles_TrabajosID",
                table: "TrabajosDetalles",
                column: "TrabajosID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CotizacionesDetalles");

            migrationBuilder.DropTable(
                name: "TrabajosDetalles");

            migrationBuilder.DropTable(
                name: "Cotizaciones");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Prioridades");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "TiposTecnicos");
        }
    }
}
