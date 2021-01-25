using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teste.Confitec.Domain.Confitec.Usuario.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ListAsync();
        Task AddAsync(Usuario usuario);
        void Update(Usuario category);
        Task<Usuario> FindByIdAsync(int usuarioId);
        void Remove(Usuario usuario);
    }
}
