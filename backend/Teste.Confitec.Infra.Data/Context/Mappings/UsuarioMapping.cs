using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Confitec.Domain.Confitec.Usuario;

namespace Teste.Confitec.Infra.Data.Context.Mappings
{
    class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(c => c.Nome).HasMaxLength(350);
            builder.Property(c => c.Sobrenome).HasMaxLength(350);
            builder.Property(c => c.Email).HasMaxLength(200);

            builder.Property(c => c.Escolaridade).HasColumnType("int");
        }
    }
}
