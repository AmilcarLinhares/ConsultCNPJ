using Microsoft.EntityFrameworkCore.Migrations;

namespace CNPJ.IU.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MsgErro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Situacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Porte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abertura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    natureza_juridica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fantasia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ultima_atualizacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Efr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotivoSituacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SituacaoEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSituacaoEspecial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    capital_social = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSituacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AtividadePrincipal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseApiWsDTOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadePrincipal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadePrincipal_Empresa_ResponseApiWsDTOId",
                        column: x => x.ResponseApiWsDTOId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtividadeSecundaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseApiWsDTOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeSecundaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadeSecundaria_Empresa_ResponseApiWsDTOId",
                        column: x => x.ResponseApiWsDTOId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diretor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseApiWsDTOId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diretor_Empresa_ResponseApiWsDTOId",
                        column: x => x.ResponseApiWsDTOId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtividadePrincipal_ResponseApiWsDTOId",
                table: "AtividadePrincipal",
                column: "ResponseApiWsDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeSecundaria_ResponseApiWsDTOId",
                table: "AtividadeSecundaria",
                column: "ResponseApiWsDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_Diretor_ResponseApiWsDTOId",
                table: "Diretor",
                column: "ResponseApiWsDTOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtividadePrincipal");

            migrationBuilder.DropTable(
                name: "AtividadeSecundaria");

            migrationBuilder.DropTable(
                name: "Diretor");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
