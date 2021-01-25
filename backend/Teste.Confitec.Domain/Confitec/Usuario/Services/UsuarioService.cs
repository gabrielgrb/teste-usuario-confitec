using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Confitec.Domain.Confitec.Usuario.Dto;
using Teste.Confitec.Domain.Confitec.Usuario.Interfaces;

namespace Teste.Confitec.Domain.Confitec.Usuario.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> GetById(int id)
        {
            var usuario = await _usuarioRepository.FindByIdAsync(id);
            return _mapper.Map<Usuario, UsuarioDto>(usuario);
        }

        public async Task<List<UsuariosParaExibicaoDto>> ListarAsync()
        {
            var usuarios = await _usuarioRepository.ListAsync();
            var usuariosDto = _mapper.Map<List<Usuario>, List<UsuariosParaExibicaoDto>>(usuarios);
            return usuariosDto;
        }
    }
}
