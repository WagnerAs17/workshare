using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace workshare.clientes.test.Configuration
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(Browser browser, string caminhoDriver, bool headless)
        {
            IWebDriver webDriver = null;
            switch (browser) {
                case Browser.Chrome:
                    var optionsChrome = new ChromeOptions();
                    if (headless)
                        optionsChrome.AddArgument("--headless");

                    webDriver = new ChromeDriver(caminhoDriver, optionsChrome);

                    break;
                case Browser.Firefox:
                    var optionsFireFox = new FirefoxOptions();
                    if (headless)
                        optionsFireFox.AddArgument("--headless");

                    webDriver = new FirefoxDriver(caminhoDriver, optionsFireFox);
                    break;
            }

            return webDriver;
        }

        //public static IWebDriver SetupBrowser<TOptions, TWebDriver>(string caminhoDriver, bool headless) where TOptions : ChromeOptions, new () where TWebDriver : WebDriver , new ()
        //{
        //    var optionsChrome = new TOptions();
        //    if (headless)
        //        optionsChrome.AddArgument("--headless");

        //    return new TWebDriver(caminhoDriver, optionsChrome);
        //}
    }

}
 
