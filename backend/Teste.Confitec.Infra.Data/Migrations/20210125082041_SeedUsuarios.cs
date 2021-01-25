using Microsoft.EntityFrameworkCore.Migrations;
using Teste.Confitec.Infra.Data.Seed;

namespace Teste.Confitec.Infra.Data.Migrations
{
    public partial class SeedUsuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            UsuariosSeed.Seed(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
