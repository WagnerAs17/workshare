using System.Threading.Tasks;
using workshare.clientes.data.Context;
using workshare.clientes.domain.Models;
using workshare.clientes.domain.Models.Repositories;

namespace workshare.clientes.data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _context;

        public ClienteRepository(ClienteContext context)
        {
            _context = context;
        }

        public async Task<bool> Adicionar(Cliente cliente)
        {
            await _context.AddAsync(cliente);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
