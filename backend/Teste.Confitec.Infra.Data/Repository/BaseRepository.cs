using Teste.Confitec.Infra.Data.Context;

namespace Teste.Confitec.Infra.Data.Repository
{
    public abstract class BaseRepository
    {
        protected readonly ConfitecDbContext _context;

        public BaseRepository(ConfitecDbContext context)
        {
            _context = context;
        }
    }
}
