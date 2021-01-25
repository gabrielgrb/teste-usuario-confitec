using Microsoft.EntityFrameworkCore;
using Teste.Confitec.Domain.Confitec.Usuario;
using Teste.Confitec.Infra.Data.Context.Mappings;

namespace Teste.Confitec.Infra.Data.Context
{
    public class ConfitecDbContext : DbContext
    {
        public ConfitecDbContext(DbContextOptions<ConfitecDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMapping());
        }
    }
}
