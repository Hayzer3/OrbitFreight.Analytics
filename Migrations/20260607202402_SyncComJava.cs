using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrbiFreight.Analytics.Migrations
{
    /// <inheritdoc />
    public partial class SyncComJava : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM566503");

            migrationBuilder.CreateTable(
                name: "TIPO_CARGA",
                schema: "RM566503",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    temp_min = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    temp_max = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    umidade_max = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    prazo_max_horas = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_CARGA", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                schema: "RM566503",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cargo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CARGA",
                schema: "RM566503",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    tipo_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    veiculo_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    motorista_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    placa_veiculo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    origem = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    destino = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    temp_min = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    temp_max = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    umidade_max = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARGA", x => x.id);
                    table.ForeignKey(
                        name: "FK_CARGA_TIPO_CARGA_tipo_id",
                        column: x => x.tipo_id,
                        principalSchema: "RM566503",
                        principalTable: "TIPO_CARGA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALERTA",
                schema: "RM566503",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    carga_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    nivel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALERTA", x => x.id);
                    table.ForeignKey(
                        name: "FK_ALERTA_CARGA_carga_id",
                        column: x => x.carga_id,
                        principalSchema: "RM566503",
                        principalTable: "CARGA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SENSOR_LEITURA",
                schema: "RM566503",
                columns: table => new
                {
                    id = table.Column<long>(type: "NUMBER(19)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    carga_id = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    temperatura = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    umidade = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    data_hora_leitura = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    latitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    longitude = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SENSOR_LEITURA", x => x.id);
                    table.ForeignKey(
                        name: "FK_SENSOR_LEITURA_CARGA_carga_id",
                        column: x => x.carga_id,
                        principalSchema: "RM566503",
                        principalTable: "CARGA",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALERTA_carga_id",
                schema: "RM566503",
                table: "ALERTA",
                column: "carga_id");

            migrationBuilder.CreateIndex(
                name: "IX_CARGA_tipo_id",
                schema: "RM566503",
                table: "CARGA",
                column: "tipo_id");

            migrationBuilder.CreateIndex(
                name: "IX_SENSOR_LEITURA_carga_id",
                schema: "RM566503",
                table: "SENSOR_LEITURA",
                column: "carga_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALERTA",
                schema: "RM566503");

            migrationBuilder.DropTable(
                name: "SENSOR_LEITURA",
                schema: "RM566503");

            migrationBuilder.DropTable(
                name: "USUARIO",
                schema: "RM566503");

            migrationBuilder.DropTable(
                name: "CARGA",
                schema: "RM566503");

            migrationBuilder.DropTable(
                name: "TIPO_CARGA",
                schema: "RM566503");
        }
    }
}
