using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teste.Confitec.Domain.Confitec.Usuario.Dto;
using Teste.Confitec.Domain.Confitec.Usuario.Interfaces;
using Teste.Confitec.Domain.Interfaces;

namespace Teste.Confitec.Domain.Confitec.Usuario.Services
{
    public class ExclusorDeUsuario : IExclusorDeUsuario
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        private BaseResponseDto baseResponseDto = new BaseResponseDto() { ErrorMessages = new List<string>() };

        public ExclusorDeUsuario(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponseDto> ExcluirAsync(int id)
        {
            var usuario = await _usuarioRepository.FindByIdAsync(id);

            if (usuario == null)
            {
                baseResponseDto.ErrorMessages.Add("Usuário não encontrado.");
                return baseResponseDto;
            }

            try
            {
                _usuarioRepository.Remove(usuario);
                await _unitOfWork.CompleteAsync();

                baseResponseDto.Modelo = usuario;
            }
            catch (Exception ex)
            {
                baseResponseDto.ErrorMessages.Add($"Ocorreu um erro ao apagar o usuário: {ex.Message}");
            }

            return baseResponseDto;
        }
    }
}
