using Microsoft.Extensions.Configuration;

namespace workshare.clientes.test.Configuration
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _configuration;
        public string WebDrivers => _configuration.GetSection("WebDriver").Value;

        public ConfigurationHelper()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }

}
 
