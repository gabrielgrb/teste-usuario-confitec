using System.Threading.Tasks;
using Teste.Confitec.Domain.Interfaces;

namespace Teste.Confitec.Infra.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConfitecDbContext _context;

        public UnitOfWork(ConfitecDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
