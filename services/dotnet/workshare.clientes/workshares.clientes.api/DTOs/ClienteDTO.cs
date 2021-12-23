using System;

namespace workshares.clientes.api.DTOs
{
    public class ClienteDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get;  set; }
        public bool Ativo { get; set; }
    }
}
