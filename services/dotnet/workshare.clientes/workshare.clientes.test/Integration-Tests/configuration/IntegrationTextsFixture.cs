using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using workshares.clientes.api;
using Xunit;

namespace workshare.clientes.test.integration_tests.configuration
{
    /// <summary>
    /// Funciona parecido com o IClassFixture
    /// Porém vale ressaltar que só será limpado dá memória quando todos 
    /// os testes forem finalizados
    /// </summary>
    [CollectionDefinition(nameof(IntegratioWebApiTestsFixtureCollection))]
    public class IntegratioWebApiTestsFixtureCollection : ICollectionFixture<IntegrationTextsFixture<StartupWebApiTest>>
    {}

    public class IntegrationTextsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly ClienteFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTextsFixture()
        {
            var clientOptions = new WebApplicationFactoryClientOptions
            {

            };

            Factory = new ClienteFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
