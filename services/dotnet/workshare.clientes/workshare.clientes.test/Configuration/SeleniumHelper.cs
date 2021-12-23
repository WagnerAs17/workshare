using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace workshare.clientes.test.Configuration
{
    public class SeleniumHelper : IDisposable
    {
        public IWebDriver WebDriver;
        public ConfigurationHelper ConfigurationHelper;
        public WebDriverWait Wait;
        public SeleniumHelper(Browser browser, ConfigurationHelper configurationHelper, Boolean headless = true)
        {
            ConfigurationHelper = configurationHelper;
            WebDriver = WebDriverFactory.CreateWebDriver(browser, configurationHelper.WebDrivers, headless);
            WebDriver.Manage().Window.Maximize();
            Wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
        }

        public String ObterUrl()
        {
            return WebDriver.Url;
        }

        public void IrParaUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public void ClicarLinkPorText(string linkText)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(linkText))).Click();
        }

        public void ClicarBotaoPorId(string botaoId)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(botaoId))).Click();
        }

        public void ClicarPorXPath(string xPath)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath))).Click();
        }

        public void Dispose()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }
    }

}
 
