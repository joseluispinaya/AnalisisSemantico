using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Capa.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InicioDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carreras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carreras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineasInvestigacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineasInvestigacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroCi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResumenPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docentes_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroCi = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CarreraId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estudiantes_Carreras_CarreraId",
                        column: x => x.CarreraId,
                        principalTable: "Carreras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DocenteLineasInvestigacion",
                columns: table => new
                {
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    LineaInvestigacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocenteLineasInvestigacion", x => new { x.DocenteId, x.LineaInvestigacionId });
                    table.ForeignKey(
                        name: "FK_DocenteLineasInvestigacion_Docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DocenteLineasInvestigacion_LineasInvestigacion_LineaInvestigacionId",
                        column: x => x.LineaInvestigacionId,
                        principalTable: "LineasInvestigacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistorialTutorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    Tema = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Carrera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialTutorias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialTutorias_Docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoGrados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gestion = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    DocenteId = table.Column<int>(type: "int", nullable: false),
                    EstudianteId = table.Column<int>(type: "int", nullable: false),
                    LineaInvestigacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoGrados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProyectoGrados_Docentes_DocenteId",
                        column: x => x.DocenteId,
                        principalTable: "Docentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProyectoGrados_Estudiantes_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProyectoGrados_LineasInvestigacion_LineaInvestigacionId",
                        column: x => x.LineaInvestigacionId,
                        principalTable: "LineasInvestigacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carreras_Nombre",
                table: "Carreras",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocenteLineasInvestigacion_LineaInvestigacionId",
                table: "DocenteLineasInvestigacion",
                column: "LineaInvestigacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Docentes_CarreraId",
                table: "Docentes",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Docentes_NroCi",
                table: "Docentes",
                column: "NroCi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_CarreraId",
                table: "Estudiantes",
                column: "CarreraId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiantes_NroCi",
                table: "Estudiantes",
                column: "NroCi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistorialTutorias_DocenteId",
                table: "HistorialTutorias",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoGrados_DocenteId",
                table: "ProyectoGrados",
                column: "DocenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoGrados_EstudianteId",
                table: "ProyectoGrados",
                column: "EstudianteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoGrados_LineaInvestigacionId",
                table: "ProyectoGrados",
                column: "LineaInvestigacionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocenteLineasInvestigacion");

            migrationBuilder.DropTable(
                name: "HistorialTutorias");

            migrationBuilder.DropTable(
                name: "ProyectoGrados");

            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "LineasInvestigacion");

            migrationBuilder.DropTable(
                name: "Carreras");
        }
    }
}
