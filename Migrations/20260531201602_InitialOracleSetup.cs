using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrbiFreight.Analytics.Migrations
{
    /// <inheritdoc />
    public partial class InitialOracleSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "RM566503 ");

            migrationBuilder.CreateTable(
                name: "ROTA",
                schema: "RM566503 ",
                columns: table => new
                {
                    ID_ROTA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ORIGEM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESTINO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROTA", x => x.ID_ROTA);
                });

            migrationBuilder.CreateTable(
                name: "TIPO_CARGA",
                schema: "RM566503 ",
                columns: table => new
                {
                    ID_TIPO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NOME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TIPO_CARGA", x => x.ID_TIPO);
                });

            migrationBuilder.CreateTable(
                name: "CARGA",
                schema: "RM566503 ",
                columns: table => new
                {
                    ID_CARGA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_TIPO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    IdRota = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARGA", x => x.ID_CARGA);
                    table.ForeignKey(
                        name: "FK_CARGA_ROTA_IdRota",
                        column: x => x.IdRota,
                        principalSchema: "RM566503 ",
                        principalTable: "ROTA",
                        principalColumn: "ID_ROTA");
                    table.ForeignKey(
                        name: "FK_CARGA_TIPO_CARGA_ID_TIPO",
                        column: x => x.ID_TIPO,
                        principalSchema: "RM566503 ",
                        principalTable: "TIPO_CARGA",
                        principalColumn: "ID_TIPO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALERTA",
                schema: "RM566503 ",
                columns: table => new
                {
                    ID_ALERTA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_CARGA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    MENSAGEM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NIVEL_RISCO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DATA_ALERTA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALERTA", x => x.ID_ALERTA);
                    table.ForeignKey(
                        name: "FK_ALERTA_CARGA_ID_CARGA",
                        column: x => x.ID_CARGA,
                        principalSchema: "RM566503 ",
                        principalTable: "CARGA",
                        principalColumn: "ID_CARGA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALERTA_ID_CARGA",
                schema: "RM566503 ",
                table: "ALERTA",
                column: "ID_CARGA");

            migrationBuilder.CreateIndex(
                name: "IX_CARGA_ID_TIPO",
                schema: "RM566503 ",
                table: "CARGA",
                column: "ID_TIPO");

            migrationBuilder.CreateIndex(
                name: "IX_CARGA_IdRota",
                schema: "RM566503 ",
                table: "CARGA",
                column: "IdRota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ALERTA",
                schema: "RM566503 ");

            migrationBuilder.DropTable(
                name: "CARGA",
                schema: "RM566503 ");

            migrationBuilder.DropTable(
                name: "ROTA",
                schema: "RM566503 ");

            migrationBuilder.DropTable(
                name: "TIPO_CARGA",
                schema: "RM566503 ");
        }
    }
}
