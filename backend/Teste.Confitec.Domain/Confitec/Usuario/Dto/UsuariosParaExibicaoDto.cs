using System;

namespace Teste.Confitec.Domain.Confitec.Usuario.Dto
{
    public class UsuariosParaExibicaoDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string DataNascimentoFormatada { get; set; }
        public string EscolaridadeDescricao { get; set; }
        public string NomeCompleto { get; set; }
    }
}
