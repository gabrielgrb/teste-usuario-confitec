using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Confitec.Domain.Confitec.Usuario.Dto;

namespace Teste.Confitec.Domain.Confitec.Usuario.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuariosParaExibicaoDto>> ListarAsync();
        Task<UsuarioDto> GetById(int id);
    }
}
