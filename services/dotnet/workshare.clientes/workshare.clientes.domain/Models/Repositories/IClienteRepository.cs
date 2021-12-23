using System.Threading.Tasks;

namespace workshare.clientes.domain.Models.Repositories
{
    public interface IClienteRepository
    {
        Task<bool> Adicionar(Cliente cliente);
    }
}
