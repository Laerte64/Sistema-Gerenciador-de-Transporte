using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGerenciadorDeTransportes.Migrations
{
    /// <inheritdoc />
    public partial class Migracao1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_modalidade",
                columns: table => new
                {
                    ModalidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_modalidade", x => x.ModalidadeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_pais", x => x.PaisId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_usuario", x => x.UsuarioId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_estado", x => x.EstadoId);
                    table.ForeignKey(
                        name: "FK_tb_estado_tb_pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "tb_pais",
                        principalColumn: "PaisId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_empresa",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CNPJ = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_empresa", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_tb_empresa_tb_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_passageiro",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_passageiro", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_tb_passageiro_tb_usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "tb_usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_cidade",
                columns: table => new
                {
                    CidadeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_cidade", x => x.CidadeId);
                    table.ForeignKey(
                        name: "FK_tb_cidade_tb_estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "tb_estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_veiculo",
                columns: table => new
                {
                    VeiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    ModalidadeId = table.Column<int>(type: "int", nullable: false),
                    Capacidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_veiculo", x => x.VeiculoId);
                    table.ForeignKey(
                        name: "FK_tb_veiculo_tb_empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "tb_empresa",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_veiculo_tb_modalidade_ModalidadeId",
                        column: x => x.ModalidadeId,
                        principalTable: "tb_modalidade",
                        principalColumn: "ModalidadeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_viagem",
                columns: table => new
                {
                    ViagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VeiculoId = table.Column<int>(type: "int", nullable: false),
                    CidadePartidaId = table.Column<int>(type: "int", nullable: false),
                    CidadeChegadaId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_viagem", x => x.ViagemId);
                    table.ForeignKey(
                        name: "FK_tb_viagem_tb_cidade_CidadeChegadaId",
                        column: x => x.CidadeChegadaId,
                        principalTable: "tb_cidade",
                        principalColumn: "CidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_viagem_tb_cidade_CidadePartidaId",
                        column: x => x.CidadePartidaId,
                        principalTable: "tb_cidade",
                        principalColumn: "CidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_viagem_tb_veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "tb_veiculo",
                        principalColumn: "VeiculoId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tb_passageiro_viagem",
                columns: table => new
                {
                    PassageirosUsuarioId = table.Column<int>(type: "int", nullable: false),
                    ViagensViagemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_passageiro_viagem", x => new { x.PassageirosUsuarioId, x.ViagensViagemId });
                    table.ForeignKey(
                        name: "FK_tb_passageiro_viagem_tb_passageiro_PassageirosUsuarioId",
                        column: x => x.PassageirosUsuarioId,
                        principalTable: "tb_passageiro",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_passageiro_viagem_tb_viagem_ViagensViagemId",
                        column: x => x.ViagensViagemId,
                        principalTable: "tb_viagem",
                        principalColumn: "ViagemId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_cidade_EstadoId",
                table: "tb_cidade",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_estado_PaisId",
                table: "tb_estado",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_modalidade_Nome",
                table: "tb_modalidade",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_pais_Nome",
                table: "tb_pais",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_passageiro_viagem_ViagensViagemId",
                table: "tb_passageiro_viagem",
                column: "ViagensViagemId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_usuario_Nome",
                table: "tb_usuario",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_veiculo_EmpresaId",
                table: "tb_veiculo",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_veiculo_ModalidadeId",
                table: "tb_veiculo",
                column: "ModalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_viagem_CidadeChegadaId",
                table: "tb_viagem",
                column: "CidadeChegadaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_viagem_CidadePartidaId",
                table: "tb_viagem",
                column: "CidadePartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_viagem_VeiculoId",
                table: "tb_viagem",
                column: "VeiculoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_passageiro_viagem");

            migrationBuilder.DropTable(
                name: "tb_passageiro");

            migrationBuilder.DropTable(
                name: "tb_viagem");

            migrationBuilder.DropTable(
                name: "tb_cidade");

            migrationBuilder.DropTable(
                name: "tb_veiculo");

            migrationBuilder.DropTable(
                name: "tb_estado");

            migrationBuilder.DropTable(
                name: "tb_empresa");

            migrationBuilder.DropTable(
                name: "tb_modalidade");

            migrationBuilder.DropTable(
                name: "tb_pais");

            migrationBuilder.DropTable(
                name: "tb_usuario");
        }
    }
}
