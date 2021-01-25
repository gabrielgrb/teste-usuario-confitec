using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Teste.Confitec.Domain.Confitec.Usuario;
using Teste.Confitec.Domain.Confitec.Usuario.Interfaces;
using Teste.Confitec.Infra.Data.Context;

namespace Teste.Confitec.Infra.Data.Repository
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(ConfitecDbContext context) : base(context)
        {
        }

        public async Task<List<Usuario>> ListAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
        }

        public void Update(Usuario category)
        {
            _context.Usuario.Update(category);
        }

        public async Task<Usuario> FindByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public void Remove(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
        }
    }
}
