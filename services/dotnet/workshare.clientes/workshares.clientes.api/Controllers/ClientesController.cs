using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using workshare.clientes.domain.Models;
using workshare.clientes.domain.Models.Repositories;
using workshares.clientes.api.DTOs;

namespace workshares.clientes.api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(ClienteDTO clienteDto)
        {
            var cliente = new Cliente(clienteDto.Nome, clienteDto.Sobrenome, clienteDto.DataNascimento, clienteDto.Cpf);
            await _clienteRepository.Adicionar(cliente);

            return Ok();
        }
    }
}
