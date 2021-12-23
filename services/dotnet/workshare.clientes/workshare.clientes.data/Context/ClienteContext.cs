using Microsoft.EntityFrameworkCore;
using System.Linq;
using workshare.clientes.domain.Models;
using workshare.core.ValuesObjects;

namespace workshare.clientes.data.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<CPF>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteContext).Assembly);

            foreach (var relatioship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
                relatioship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
