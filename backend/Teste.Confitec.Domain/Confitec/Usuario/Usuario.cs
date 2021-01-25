using System;
using System.ComponentModel.DataAnnotations;
using Teste.Confitec.Domain.Confitec.Usuario.Enums;

namespace Teste.Confitec.Domain.Confitec.Usuario
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EscolaridadeEnum Escolaridade { get; set; }

        public Usuario(
            string nome,
            string sobrenome, 
            string email, 
            DateTime dataNascimento, 
            EscolaridadeEnum escolaridade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }

        public void AlterarNome(string nome)
        {
            Nome = nome?.Trim();
        }

        public void AlterarSobrenome(string sobrenome)
        {
            Sobrenome = sobrenome?.Trim();
        }

        public void AlterarEmail(string email)
        {
            Email = email?.Trim();
        }

        public void AlterarDataNascimento(DateTime dataNascimento)
        {
            DataNascimento = dataNascimento;
        }

        public void AlterarEscolaridade(EscolaridadeEnum escolaridade)
        {
            Escolaridade = escolaridade;
        }
    }
}
