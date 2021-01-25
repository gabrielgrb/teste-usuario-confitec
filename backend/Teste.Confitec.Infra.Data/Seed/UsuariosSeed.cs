using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.Confitec.Infra.Data.Seed
{
    public class UsuariosSeed
    {
        public static void Seed(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder != null)
            {
                migrationBuilder.Sql(@"
                    INSERT INTO Usuario(Nome, Sobrenome, Email, DataNascimento, Escolaridade)
                    VALUES ('Gabriel', 'Barreto', 'gabrielgrb50@gmail.com', '1995-12-28 07:00', 4)

                    INSERT INTO Usuario(Nome, Sobrenome, Email, DataNascimento, Escolaridade)
                    VALUES ('Confitec', 'Admin', 'admin@confitec.com', '2003-08-08 06:00', 4);

                    INSERT INTO Usuario(Nome, Sobrenome, Email, DataNascimento, Escolaridade)
                    VALUES ('Renan', 'Rodrigues', 'renan@direito.com', '1993-02-08 06:00', 3);

                    INSERT INTO Usuario(Nome, Sobrenome, Email, DataNascimento, Escolaridade)
                    VALUES ('Paolo', 'Guerrero', 'paolo@guerrero.com', '1985-06-13 06:00', 3);
            ");
            }
        }
    }
}
