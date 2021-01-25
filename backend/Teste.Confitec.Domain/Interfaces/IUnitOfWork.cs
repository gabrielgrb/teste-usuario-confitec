using System.Threading.Tasks;

namespace Teste.Confitec.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
