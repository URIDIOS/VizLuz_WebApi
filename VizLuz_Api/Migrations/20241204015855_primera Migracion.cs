using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VizLuz_Api.Migrations
{
    /// <inheritdoc />
    public partial class primeraMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ubicaciones",
                columns: table => new
                {
                    ID_Ubicacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUbicacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicaciones", x => x.ID_Ubicacion);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "Controles",
                columns: table => new
                {
                    ID_Controles = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreControl = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ID_Ubicacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controles", x => x.ID_Controles);
                    table.ForeignKey(
                        name: "FK_Controles_Ubicaciones_ID_Ubicacion",
                        column: x => x.ID_Ubicacion,
                        principalTable: "Ubicaciones",
                        principalColumn: "ID_Ubicacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Electrodomesticos",
                columns: table => new
                {
                    ID_Electrodomestico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreElectrodomestico = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Electrodomesticos", x => x.ID_Electrodomestico);
                    table.ForeignKey(
                        name: "FK_Electrodomesticos_Usuarios_ID_Usuario",
                        column: x => x.ID_Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "ID_Usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ubicaciones",
                columns: new[] { "ID_Ubicacion", "NombreUbicacion" },
                values: new object[,]
                {
                    { 1, "Cosina" },
                    { 2, "Sala" },
                    { 3, "Recamara 1" },
                    { 4, "Recamara 2" },
                    { 5, "Recamara 3" },
                    { 6, "Patio" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID_Usuario", "Nombres" },
                values: new object[,]
                {
                    { 1, "Uriel Osuna" },
                    { 2, "Miguel Octavio" },
                    { 3, "Solo Vino" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Controles_ID_Ubicacion",
                table: "Controles",
                column: "ID_Ubicacion");

            migrationBuilder.CreateIndex(
                name: "IX_Electrodomesticos_ID_Usuario",
                table: "Electrodomesticos",
                column: "ID_Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Controles");

            migrationBuilder.DropTable(
                name: "Electrodomesticos");

            migrationBuilder.DropTable(
                name: "Ubicaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
