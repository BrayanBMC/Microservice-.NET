using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TiendaServicios.Api.Autor.Migrations
{
    /// <inheritdoc />
    public partial class MigracionPostgresInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorLibro",
                columns: table => new
                {
                    AutorLibroid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    FechaDeNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutorLibroGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLibro", x => x.AutorLibroid);
                });

            migrationBuilder.CreateTable(
                name: "GradoAcademico",
                columns: table => new
                {
                    GradoAcademicoid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    CentroAcademico = table.Column<string>(type: "text", nullable: false),
                    FechaGrado = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutorLibroid = table.Column<int>(type: "integer", nullable: false),
                    GradoAcademicoGuid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradoAcademico", x => x.GradoAcademicoid);
                    table.ForeignKey(
                        name: "FK_GradoAcademico_AutorLibro_AutorLibroid",
                        column: x => x.AutorLibroid,
                        principalTable: "AutorLibro",
                        principalColumn: "AutorLibroid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradoAcademico_AutorLibroid",
                table: "GradoAcademico",
                column: "AutorLibroid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradoAcademico");

            migrationBuilder.DropTable(
                name: "AutorLibro");
        }
    }
}
