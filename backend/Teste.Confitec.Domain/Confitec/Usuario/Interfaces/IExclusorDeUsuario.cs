using System.Threading.Tasks;
using Teste.Confitec.Domain.Confitec.Usuario.Dto;

namespace Teste.Confitec.Domain.Confitec.Usuario.Interfaces
{
    public interface IExclusorDeUsuario
    {
        Task<BaseResponseDto> ExcluirAsync(int id);
    }
}
