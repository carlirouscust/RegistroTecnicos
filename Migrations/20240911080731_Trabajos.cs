using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroTecnicos.Migrations
{
    /// <inheritdoc />
    public partial class Trabajos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Trabajos",
                columns: table => new
                {
                    TrabajosID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<int>(type: "INTEGER", nullable: false),
                    Monto = table.Column<int>(type: "INTEGER", nullable: false),
                    TecnicosID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientesID = table.Column<int>(type: "INTEGER", nullable: false)
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
                        name: "FK_Trabajos_Tecnicos_TecnicosID",
                        column: x => x.TecnicosID,
                        principalTable: "Tecnicos",
                        principalColumn: "TecnicosID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tecnicos_TiposTecnicosID",
                table: "Tecnicos",
                column: "TiposTecnicosID");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_ClientesID",
                table: "Trabajos",
                column: "ClientesID");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_TecnicosID",
                table: "Trabajos",
                column: "TecnicosID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Tecnicos");

            migrationBuilder.DropTable(
                name: "TiposTecnicos");
        }
    }
}
