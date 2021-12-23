using Bogus;
using Bogus.Extensions.Brazil;
using System;
using workshare.clientes.domain.Models;
using workshares.clientes.api.DTOs;
using Xunit;

namespace workshare.clientes.test.Fixtures
{
    /// <summary>
    /// Os objetos são criados antes das classes que estão implementando a fixture
    /// E destruido após o último método rodar
    /// </summary>
    /// Quando for necessário mais de uma fixture
    /// É possível utilizar o class fixture
    public class ClienteTestFixture : IDisposable
    {
        private readonly Faker _faker;

        public ClienteTestFixture()
        {
            _faker = new Faker("pt_BR");
        }
        /// <summary>
        /// Uma fixture serve para o reaproveitamento de algumas funções entre as classes
        /// É uma forma de compartilhar código entre os testes
        /// </summary>
        /// <returns></returns>
        public Cliente GerarClienteValido()
        {
            return new Cliente(
                _faker.Person.FirstName, 
                _faker.Person.LastName, 
                _faker.Person.DateOfBirth.AddDays(-19), 
                _faker.Person.Cpf(false));
        }

        public Cliente GerarClienteComCpfInvalido()
        {
            return new Cliente(
                _faker.Person.FirstName,
                _faker.Person.LastName,
                _faker.Person.DateOfBirth.AddDays(-19),
                "1111111111");
        }

        public ClienteDTO GerarClienteDtoValido()
        {
            return new ClienteDTO {
                Ativo = true,
                Cpf = _faker.Person.Cpf(false),
                DataNascimento = _faker.Person.DateOfBirth.AddDays(-19),
                Nome = _faker.Person.FirstName,
                Sobrenome = _faker.Person.LastName

            };
        }

        public void Dispose()
        {
        }
    }
}
