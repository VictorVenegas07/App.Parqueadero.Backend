using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppParqueadero.Infraestructura.Datos.Migrations
{
    public partial class primermigracionV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    usuarioCrea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioModifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumuento = table.Column<string>(type: "varchar(3)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioCrea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioModifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoDocumuento = table.Column<string>(type: "varchar(3)", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(20)", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    PuestoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CodigoPuesto = table.Column<string>(type: "varchar(15)", nullable: true),
                    Disponibilidad = table.Column<string>(type: "varchar(12)", nullable: true),
                    usuarioCrea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioModifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.PuestoId);
                });

            migrationBuilder.CreateTable(
                name: "Tarifa",
                columns: table => new
                {
                    TarifaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    usuarioCrea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioModifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifa", x => x.TarifaId);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    VehiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Placa = table.Column<string>(type: "varchar(10)", nullable: true),
                    Modelo = table.Column<string>(type: "varchar(20)", nullable: true),
                    Marca = table.Column<string>(type: "varchar(25)", nullable: true),
                    Tipo = table.Column<string>(type: "varchar(20)", nullable: true),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.VehiculoId);
                    table.ForeignKey(
                        name: "FK_Vehiculo_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuarioCrea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioModifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioId);
                    table.ForeignKey(
                        name: "FK_Horario_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    usuarioCrea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioModifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PuestoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Estado = table.Column<string>(type: "varchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reserva_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Puesto_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puesto",
                        principalColumn: "PuestoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Vehiculo_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "VehiculoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ticked",
                columns: table => new
                {
                    TickedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TarifaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PuestoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpleadoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraDeEntrada = table.Column<DateTime>(type: "DateTime", nullable: false),
                    HoraDeSalida = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Total = table.Column<decimal>(type: "Decimal", nullable: false),
                    usuarioCrea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    usuarioModifica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaModifica = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticked", x => x.TickedId);
                    table.ForeignKey(
                        name: "FK_Ticked_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticked_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticked_Puesto_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puesto",
                        principalColumn: "PuestoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticked_Tarifa_TarifaId",
                        column: x => x.TarifaId,
                        principalTable: "Tarifa",
                        principalColumn: "TarifaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_Vehiculo_VehiculoID",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculo",
                        principalColumn: "VehiculoId");
                });

            migrationBuilder.InsertData(
                table: "Puesto",
                columns: new[] { "PuestoId", "CodigoPuesto", "Disponibilidad", "FechaModifica", "usuarioCrea", "usuarioModifica" },
                values: new object[,]
                {
                    { new Guid("2b4a2de9-1596-4c53-beea-418a26d44bac"), "A0", "Disponible", null, null, null },
                    { new Guid("60bd82ff-b63d-4649-b620-f6333de4dafb"), "A1", "Disponible", null, null, null },
                    { new Guid("bab08f42-2fa8-430b-88d5-6ec72c917f27"), "A2", "Disponible", null, null, null },
                    { new Guid("17d29544-23c1-4dcd-97f3-3dbc1ca31885"), "A3", "Disponible", null, null, null },
                    { new Guid("803e074a-6484-4275-8e48-f50210a1ba38"), "A4", "Disponible", null, null, null },
                    { new Guid("4c76be66-0fc0-4646-a599-019f44c24608"), "A5", "Disponible", null, null, null },
                    { new Guid("65a344c7-9cc5-4e6b-9e74-bc0187ed81e9"), "A6", "Disponible", null, null, null },
                    { new Guid("f3ba6f58-c4bf-45d5-8276-894bc29d2103"), "A7", "Disponible", null, null, null },
                    { new Guid("0b6ac818-00d8-45ad-bddc-cde7c02fadbb"), "A8", "Disponible", null, null, null },
                    { new Guid("249ee805-b75b-4f49-9eba-f6fee7628377"), "A9", "Disponible", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Tarifa",
                columns: new[] { "TarifaId", "FechaModifica", "Tipo", "Valor", "usuarioCrea", "usuarioModifica" },
                values: new object[,]
                {
                    { new Guid("7f609f85-596b-4a1e-9776-2acedf942319"), null, "Auto", 3000m, null, null },
                    { new Guid("9d5ce7e2-678c-43a5-a6ea-df7a2d4c47ee"), null, "Moto", 1000m, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horario_EmpleadoId",
                table: "Horario",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteId",
                table: "Reserva",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_PuestoId",
                table: "Reserva",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_VehiculoId",
                table: "Reserva",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticked_ClienteId",
                table: "Ticked",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticked_EmpleadoId",
                table: "Ticked",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticked_PuestoId",
                table: "Ticked",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticked_TarifaId",
                table: "Ticked",
                column: "TarifaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticked_VehiculoId",
                table: "Ticked",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_EmpleadoId",
                table: "Usuario",
                column: "EmpleadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculo_ClienteId",
                table: "Vehiculo",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Ticked");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropTable(
                name: "Tarifa");

            migrationBuilder.DropTable(
                name: "Vehiculo");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
