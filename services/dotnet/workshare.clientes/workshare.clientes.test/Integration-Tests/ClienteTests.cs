using Bogus;
using OpenQA.Selenium.Chrome;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using workshare.clientes.test.Fixtures;
using workshare.clientes.test.integration_tests.configuration;
using workshares.clientes.api;
using Xunit;

namespace workshare.clientes.test.integration_tests
{

    [Collection(nameof(IntegratioWebApiTestsFixtureCollection))]
    public class ClienteTests : IClassFixture<ClienteTestFixture>
    {
        private readonly IntegrationTextsFixture<StartupWebApiTest> _testsFixture;
        private readonly Faker _faker;
        private readonly ClienteTestFixture _clienteTestFixture;

        /// <summary>
        ///  A cada método de teste a classe é recriada
        ///  Isso é para que não haja compartilhando entre os testes
        /// </summary>
        /// <param name="textsFixture"></param>
        public ClienteTests(IntegrationTextsFixture<StartupWebApiTest> textsFixture, ClienteTestFixture clienteTestFixture)
        {
            _testsFixture = textsFixture;
            _faker = new Faker("pt_BR");
            _clienteTestFixture = clienteTestFixture;
        }

        [Fact(DisplayName = "Quando informado os dados corretamente deverá registrar o valor no banco de dados")]
        [Trait("Categoria", "Clientes - Testes de integração")]
        public async Task Quando_Fizer_A_Requicao_Com_OsDadosCorretos_Devera_Registrar_Na_Base()
        {
            //Arrange
            var cliente = _clienteTestFixture.GerarClienteDtoValido();
            //act 
            var response = await _testsFixture.Client.PostAsJsonAsync("/api/clientes", cliente);

            //assert 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact(DisplayName = "Quando informado os dados corretamente deverá registrar o valor no banco de dados")]
        [Trait("Categoria", "Clientes - Testes de integração")]
        public async Task TesteSelenium()
        {
            //Arrange
            var browser = new ChromeDriver(@"C:\Webdriver");

            browser.Navigate().GoToUrl("https://desenvolvedor.io");
        }
    }
}
