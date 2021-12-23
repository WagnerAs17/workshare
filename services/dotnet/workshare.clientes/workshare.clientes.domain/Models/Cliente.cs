using System;
using workshare.clientes.domain.Messages;
using workshare.core.Domain;
using workshare.core.ValuesObjects;

namespace workshare.clientes.domain.Models
{
    public class Cliente : Entity, IAggregateRoot
    {
        public const int MAIOR_IDADE = 18;
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public CPF Cpf { get; private set; }
        public bool Ativo { get; private set; }

        protected Cliente() { }
        public Cliente(string nome, string sobrenome, DateTime dataNascimento, string cpf)
        {
            if (!EhMaiorIdade(dataNascimento))
                throw new DomainException(ClienteDomainMessage.ClienteMenorDeIdade);

            Cpf = new CPF(cpf);
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            Ativo = true;
        }

        public bool EhMaiorIdade(DateTime dataNascimento)
        {
            return (DateTime.Now.Year - dataNascimento.Year) >= MAIOR_IDADE && 
                DateTime.Now.Month >= dataNascimento.Month && 
                DateTime.Now.Day >= dataNascimento.Day;
        }
    }
}
