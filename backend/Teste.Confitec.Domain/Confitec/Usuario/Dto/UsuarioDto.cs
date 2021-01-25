using System;
using System.ComponentModel.DataAnnotations;
using Teste.Confitec.Domain.Confitec.Usuario.Enums;

namespace Teste.Confitec.Domain.Confitec.Usuario.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobrenome é obrigatório.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Data de nascimento é obrigatória.")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Escolaridade é obrigatória.")]
        [Range(1, 4, ErrorMessage = "Escolaridade inválida.")]
        public EscolaridadeEnum Escolaridade { get; set; }

        public string DataNascimentoFormatada { get; set; }
        public string EscolaridadeDescricao { get; set; }
        public string NomeCompleto { get; set; }
    }
}
