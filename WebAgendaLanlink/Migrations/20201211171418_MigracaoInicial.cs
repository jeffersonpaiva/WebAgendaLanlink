using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAgendaLanlink.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    PessoaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.PessoaId);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    ContatoId = table.Column<int>(nullable: false),
                    TipoContato = table.Column<string>(maxLength: 10, nullable: true),
                    CodigoTipo = table.Column<int>(nullable: false),
                    TextoContato = table.Column<string>(maxLength: 120, nullable: true),
                    NumeroEnd = table.Column<string>(maxLength: 10, nullable: true),
                    Complemento = table.Column<string>(maxLength: 20, nullable: true),
                    Bairro = table.Column<string>(maxLength: 80, nullable: true),
                    Cidade = table.Column<string>(maxLength: 80, nullable: true),
                    UF = table.Column<string>(maxLength: 2, nullable: true),
                    CodigoAgp = table.Column<int>(nullable: false),
                    TipoAgp = table.Column<string>(maxLength: 20, nullable: true),
                    TipoEnd = table.Column<string>(maxLength: 20, nullable: true),
                    PessoaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.ContatoId);
                    table.ForeignKey(
                        name: "FK_Contatos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "PessoaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_PessoaId",
                table: "Contatos",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Pessoas");
        }
    }
}
