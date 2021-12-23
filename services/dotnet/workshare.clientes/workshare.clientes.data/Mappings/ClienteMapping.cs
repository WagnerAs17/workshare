using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using workshare.clientes.domain.Models;
using workshare.core.ValuesObjects;

namespace workshare.clientes.data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasColumnType("varchar(200)").IsRequired();
            builder.Property(p => p.Sobrenome).HasColumnType("varchar(500)").IsRequired();


            builder.OwnsOne(p => p.Cpf, c => {
                c.Property(x => x.Numero).HasColumnType($"varchar({CPF.TAMANHO})").IsRequired();
            });
        }
    }
}
