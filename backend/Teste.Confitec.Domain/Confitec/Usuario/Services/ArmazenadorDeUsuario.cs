using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Confitec.Domain.Confitec.Usuario.Dto;
using Teste.Confitec.Domain.Confitec.Usuario.Enums;
using Teste.Confitec.Domain.Confitec.Usuario.Interfaces;
using Teste.Confitec.Domain.Helper;
using Teste.Confitec.Domain.Interfaces;

namespace Teste.Confitec.Domain.Confitec.Usuario.Services
{
    public class ArmazenadorDeUsuario : IArmazenadorDeUsuario
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        private BaseResponseDto baseResponseDto = new BaseResponseDto() { ErrorMessages = new List<string>()};
        private List<string> errorMessages = new List<string>();
        private bool modeloValido = true;

        public ArmazenadorDeUsuario(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseDto> Armazenar(UsuarioDto usuarioDto)
        {
            ValidarRegras(usuarioDto);

            if (modeloValido)
            {
                try
                {
                    var usuario = await PopularUsuario(usuarioDto);

                    if (usuario.Id != 0)
                        _usuarioRepository.Update(usuario);
                    else
                        await _usuarioRepository.AddAsync(usuario);

                    await _unitOfWork.CompleteAsync();

                    baseResponseDto.Modelo = usuario;

                }
                catch (Exception ex)
                {
                    baseResponseDto.ErrorMessages.Add($"Ocorreu um erro ao salvar o usuário: {ex.Message}");
                }
            }

            return baseResponseDto;
        }

        private async Task<Usuario> PopularUsuario(UsuarioDto usuarioDto)
        {
            Usuario usuario;

            if (usuarioDto.Id == 0)
            {
                usuario = new Usuario(
                    usuarioDto.Nome,
                    usuarioDto.Sobrenome,
                    usuarioDto.Email,
                    usuarioDto.DataNascimento.Value,
                    usuarioDto.Escolaridade);
            }
            else
            {
                usuario = await _usuarioRepository.FindByIdAsync(usuarioDto.Id);
                usuario.AlterarNome(usuarioDto.Nome);
                usuario.AlterarSobrenome(usuarioDto.Sobrenome);
                usuario.AlterarEmail(usuarioDto.Email);
                usuario.AlterarDataNascimento(usuarioDto.DataNascimento.Value);
                usuario.AlterarEscolaridade(usuarioDto.Escolaridade);
            }

            return usuario;
        }

        private void ValidarRegras(UsuarioDto usuarioDto)
        {
            var escolaridadesPermitidas = Enum.GetValues(typeof(EscolaridadeEnum))
                .Cast<EscolaridadeEnum>()
                .Select(e => (int)e)
                .ToList();

            if (!EmailHelper.Validar(usuarioDto.Email))
                errorMessages.Add("E-mail inválido.");

            if (usuarioDto.DataNascimento > DateTime.Now.Date)
                errorMessages.Add("A data de nascimento não pode ser maior que hoje.");

            if (!escolaridadesPermitidas.Contains(usuarioDto.Escolaridade.GetHashCode()))
                errorMessages.Add("Escolaridade inválida.");

            baseResponseDto.ErrorMessages = errorMessages;
            modeloValido = errorMessages.Count == 0;
        }
    }
}
