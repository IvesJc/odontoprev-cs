using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_empresa_contratante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Cnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumeroContrato = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_empresa_contratante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_rede_credenciada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rede_credenciada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tipo_missao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    DuracaoPadraoDias = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecompensaPadrao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Frequencia = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tipo_missao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tipo_plano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Preco = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CarenciaDias = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ValidadeDias = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tipo_plano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tipo_recompensa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    ExpiracaoDias = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Aplicacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tipo_recompensa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_tipo_servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    ValorReais = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_tipo_servico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Rua = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Numero = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RedeCredenciadaId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_endereco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_endereco_tb_rede_credenciada_RedeCredenciadaId",
                        column: x => x.RedeCredenciadaId,
                        principalTable: "tb_rede_credenciada",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_prestador_servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    NumeroCro = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Especialidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NumeroContrato = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Avaliacao = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    RedeCredenciadaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_prestador_servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_prestador_servico_tb_rede_credenciada_RedeCredenciadaId",
                        column: x => x.RedeCredenciadaId,
                        principalTable: "tb_rede_credenciada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_plano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataExpiracao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PrecoCobrado = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DataFinalCarencia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    TipoPlanoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmpresaContratanteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_plano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_plano_tb_empresa_contratante_EmpresaContratanteId",
                        column: x => x.EmpresaContratanteId,
                        principalTable: "tb_empresa_contratante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_plano_tb_tipo_plano_TipoPlanoId",
                        column: x => x.TipoPlanoId,
                        principalTable: "tb_tipo_plano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlanoEntityTipoServicoEntity",
                columns: table => new
                {
                    TipoPlanosId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoServicosId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlanoEntityTipoServicoEntity", x => new { x.TipoPlanosId, x.TipoServicosId });
                    table.ForeignKey(
                        name: "FK_TipoPlanoEntityTipoServicoEntity_tb_tipo_plano_TipoPlanosId",
                        column: x => x.TipoPlanosId,
                        principalTable: "tb_tipo_plano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoPlanoEntityTipoServicoEntity_tb_tipo_servico_TipoServicosId",
                        column: x => x.TipoServicosId,
                        principalTable: "tb_tipo_servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_beneficiario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataAdesao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FotoUrl = table.Column<string>(type: "NVARCHAR2(300)", maxLength: 300, nullable: true),
                    NumeroContrato = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: true),
                    EnderecoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    EmpresaContratanteId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_beneficiario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_beneficiario_tb_empresa_contratante_EmpresaContratanteId",
                        column: x => x.EmpresaContratanteId,
                        principalTable: "tb_empresa_contratante",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tb_beneficiario_tb_endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "tb_endereco",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PrestadorServicoEntityTipoServicoEntity",
                columns: table => new
                {
                    PrestadorServicosId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoServicosId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrestadorServicoEntityTipoServicoEntity", x => new { x.PrestadorServicosId, x.TipoServicosId });
                    table.ForeignKey(
                        name: "FK_PrestadorServicoEntityTipoServicoEntity_tb_prestador_servico_PrestadorServicosId",
                        column: x => x.PrestadorServicosId,
                        principalTable: "tb_prestador_servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrestadorServicoEntityTipoServicoEntity_tb_tipo_servico_TipoServicosId",
                        column: x => x.TipoServicosId,
                        principalTable: "tb_tipo_servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BeneficiarioEntityPlanoEntity",
                columns: table => new
                {
                    BeneficiariosId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PlanosId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiarioEntityPlanoEntity", x => new { x.BeneficiariosId, x.PlanosId });
                    table.ForeignKey(
                        name: "FK_BeneficiarioEntityPlanoEntity_tb_beneficiario_BeneficiariosId",
                        column: x => x.BeneficiariosId,
                        principalTable: "tb_beneficiario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiarioEntityPlanoEntity_tb_plano_PlanosId",
                        column: x => x.PlanosId,
                        principalTable: "tb_plano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_missao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Concluido = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RecompensaRecebida = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ExpiraEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TipoMissaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    BeneficiarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_missao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_missao_tb_beneficiario_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "tb_beneficiario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_missao_tb_tipo_missao_TipoMissaoId",
                        column: x => x.TipoMissaoId,
                        principalTable: "tb_tipo_missao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_programa_relacionamento_status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    QtdePontos = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataAdesao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    BeneficiarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_programa_relacionamento_status", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_programa_relacionamento_status_tb_beneficiario_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "tb_beneficiario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_recompensa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ResgatadoEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ExpiraEm = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    BeneficiarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoRecompensaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_recompensa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_recompensa_tb_beneficiario_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "tb_beneficiario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_recompensa_tb_tipo_recompensa_TipoRecompensaId",
                        column: x => x.TipoRecompensaId,
                        principalTable: "tb_tipo_recompensa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_sinistro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataSolicitacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DataAutorizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ValorPagoParaPrestador = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    BeneficiarioId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PrestadorServicoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_sinistro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_sinistro_tb_beneficiario_BeneficiarioId",
                        column: x => x.BeneficiarioId,
                        principalTable: "tb_beneficiario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_sinistro_tb_prestador_servico_PrestadorServicoId",
                        column: x => x.PrestadorServicoId,
                        principalTable: "tb_prestador_servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_servico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ValorPago = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    TipoServicoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SinistroId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_servico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_servico_tb_sinistro_SinistroId",
                        column: x => x.SinistroId,
                        principalTable: "tb_sinistro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_servico_tb_tipo_servico_TipoServicoId",
                        column: x => x.TipoServicoId,
                        principalTable: "tb_tipo_servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiarioEntityPlanoEntity_PlanosId",
                table: "BeneficiarioEntityPlanoEntity",
                column: "PlanosId");

            migrationBuilder.CreateIndex(
                name: "IX_PrestadorServicoEntityTipoServicoEntity_TipoServicosId",
                table: "PrestadorServicoEntityTipoServicoEntity",
                column: "TipoServicosId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_beneficiario_EmpresaContratanteId",
                table: "tb_beneficiario",
                column: "EmpresaContratanteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_beneficiario_EnderecoId",
                table: "tb_beneficiario",
                column: "EnderecoId",
                unique: true,
                filter: "\"EnderecoId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tb_endereco_RedeCredenciadaId",
                table: "tb_endereco",
                column: "RedeCredenciadaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_missao_BeneficiarioId",
                table: "tb_missao",
                column: "BeneficiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_missao_TipoMissaoId",
                table: "tb_missao",
                column: "TipoMissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_plano_EmpresaContratanteId",
                table: "tb_plano",
                column: "EmpresaContratanteId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_plano_TipoPlanoId",
                table: "tb_plano",
                column: "TipoPlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_prestador_servico_RedeCredenciadaId",
                table: "tb_prestador_servico",
                column: "RedeCredenciadaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_programa_relacionamento_status_BeneficiarioId",
                table: "tb_programa_relacionamento_status",
                column: "BeneficiarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_recompensa_BeneficiarioId",
                table: "tb_recompensa",
                column: "BeneficiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_recompensa_TipoRecompensaId",
                table: "tb_recompensa",
                column: "TipoRecompensaId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_servico_SinistroId",
                table: "tb_servico",
                column: "SinistroId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_servico_TipoServicoId",
                table: "tb_servico",
                column: "TipoServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sinistro_BeneficiarioId",
                table: "tb_sinistro",
                column: "BeneficiarioId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_sinistro_PrestadorServicoId",
                table: "tb_sinistro",
                column: "PrestadorServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoPlanoEntityTipoServicoEntity_TipoServicosId",
                table: "TipoPlanoEntityTipoServicoEntity",
                column: "TipoServicosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BeneficiarioEntityPlanoEntity");

            migrationBuilder.DropTable(
                name: "PrestadorServicoEntityTipoServicoEntity");

            migrationBuilder.DropTable(
                name: "tb_missao");

            migrationBuilder.DropTable(
                name: "tb_programa_relacionamento_status");

            migrationBuilder.DropTable(
                name: "tb_recompensa");

            migrationBuilder.DropTable(
                name: "tb_servico");

            migrationBuilder.DropTable(
                name: "TipoPlanoEntityTipoServicoEntity");

            migrationBuilder.DropTable(
                name: "tb_plano");

            migrationBuilder.DropTable(
                name: "tb_tipo_missao");

            migrationBuilder.DropTable(
                name: "tb_tipo_recompensa");

            migrationBuilder.DropTable(
                name: "tb_sinistro");

            migrationBuilder.DropTable(
                name: "tb_tipo_servico");

            migrationBuilder.DropTable(
                name: "tb_tipo_plano");

            migrationBuilder.DropTable(
                name: "tb_beneficiario");

            migrationBuilder.DropTable(
                name: "tb_prestador_servico");

            migrationBuilder.DropTable(
                name: "tb_empresa_contratante");

            migrationBuilder.DropTable(
                name: "tb_endereco");

            migrationBuilder.DropTable(
                name: "tb_rede_credenciada");
        }
    }
}
