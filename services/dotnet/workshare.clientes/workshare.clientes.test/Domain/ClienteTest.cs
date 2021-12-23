using Bogus;
using Bogus.Extensions.Brazil;
using System;
using workshare.clientes.domain.Messages;
using workshare.clientes.domain.Models;
using workshare.core.Domain;
using Xunit;

namespace workshare.clientes.test.domain
{
    public class ClienteTest
    {
        private Faker Faker;
        public ClienteTest()
        {
            Faker = new Faker("pt_BR");
        }

        [Fact(DisplayName = "Informando um CPF inválido")]
        [Trait("Categoria", "Cliente Test")]
        public void Quando_Cliente_Informar_CpfInvalido_DeveraLancar_Exception_Dominio()
        {
            //arrange
            var cpfInvalido = "111.111.111-11";
            var nome = "Wagner";
            var sobrenome = "Almeida";

            //act & assert
            Assert.Throws<DomainException>(() => new Cliente(nome, sobrenome, DateTime.Now, cpfInvalido));
        }

        [Fact(DisplayName = "Criando o cliente com sucesso")]
        [Trait("Categoria", "Cliente Test")]
        public void Quando_Cliente_Criado_Com_Sucesso_Propriedade_Ativo_Devera_Ser_Verdadeiro()
        {
            //arrange
            var cpf = Faker.Person.Cpf();
            var nome = Faker.Person.FirstName;
            var sobrenome = Faker.Person.LastName;
            var dataNascimento = new DateTime(1996, 12, 17);

            //act
            var cliente = new Cliente(nome, sobrenome, dataNascimento, cpf);

            //assert
            Assert.True(cliente.Ativo);
        }

        [Fact(DisplayName = "Cliente Menor de Idade com ano invalido")]
        [Trait("Categoria", "Cliente Test")]
        public void Quando_Cliente_Menor_Idade_Com_Ano_Invalido_Devera_Lancar_Exception_Dominio()
        {
            //arrange
            var cpf = Faker.Person.Cpf();
            var nome = Faker.Person.FirstName;
            var sobrenome = Faker.Person.LastName;
            var dataNascimento = DateTime.Now;

            //act & assert 
            var exception = Assert.Throws<DomainException>(() => new Cliente(nome, sobrenome, dataNascimento, cpf));
            Assert.Equal(ClienteDomainMessage.ClienteMenorDeIdade, exception.Message);
        }

        [Fact(DisplayName = "Cliente Menor de Idade com mes inválido")]
        [Trait("Categoria", "Cliente Test")]
        public void Quando_Cliente_Menor_Idade_Com_Mes_Aniversario_Maior_Que_Mes_Atual_Devera_Lancar_Exception_Dominio()
        {
            //arrange
            var cpf = Faker.Person.Cpf();
            var nome = Faker.Person.FirstName;
            var sobrenome = Faker.Person.LastName;
            var dataNascimento = DateTime.Now.AddYears(-18).AddMonths(1);

            //act & assert 
            Assert.Throws<DomainException>(() => new Cliente(nome, sobrenome, dataNascimento, cpf));
        }

        [Fact(DisplayName = "Cliente Menor de Idade com dia maior que o do mes atual inválido")]
        [Trait("Categoria", "Cliente Test")]
        public void Quando_Cliente_Menor_Idade_Com_Dia_Aniversario_Maior_Que_O_Dia_Atual_Devera_Lancar_Exception_Dominio()
        {
            //arrange
            var cpf = Faker.Person.Cpf();
            var nome = Faker.Person.FirstName;
            var sobrenome = Faker.Person.LastName;
            var dataNascimento = DateTime.Now.AddYears(-18).AddDays(5);

            //act & assert 
            var exception = Assert.Throws<DomainException>(() => new Cliente(nome, sobrenome, dataNascimento, cpf));
            Assert.Equal(ClienteDomainMessage.ClienteMenorDeIdade, exception.Message);
        }
    }
}
