using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace CorreiosAutomation.Steps
{
    [Binding]
    public class CorreiosSteps
    {
        private IWebDriver driver;

        [Given(@"que abro o site dos correios")]
        public void DadoQueAbroOSiteDosCorreios()
        {
            var options = new ChromeOptions();
            driver = new ChromeDriver(@"C:\Users\Roger\Desktop\correios", options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php?t");
        }

        [When(@"busco pelo CEP ""(.*)""")]
        public void QuandoBuscoPeloCEP(string cep)
        {
            var campoCep = driver.FindElement(By.Id("endereco"));
            campoCep.Clear();
            campoCep.SendKeys(cep);

            driver.FindElement(By.Id("btn_pesquisar")).Click();
        }

        [Then(@"devo ver a mensagem ""(.*)""")]
        public void EntaoDevoVerAMensagem(string mensagem)
        {
            var resultado = driver.FindElement(By.CssSelector("body")).Text;
            Assert.IsTrue(resultado.Contains(mensagem));
            driver.Navigate().GoToUrl("https://www.correios.com.br/");
        }

        [Then(@"o resultado deve conter ""(.*)""")]
        public void EntaoOResultadoDeveConter(string esperado)
        {
            var resultado = driver.FindElement(By.CssSelector("body")).Text;
            Assert.IsTrue(resultado.Contains(esperado));
            driver.Navigate().GoToUrl("https://buscacepinter.correios.com.br/app/endereco/index.php?t");
        }

        [When(@"busco pelo código de rastreamento ""(.*)""")]
        public void QuandoBuscoPeloCodigoDeRastreamento(string codigo)
        {
            driver.FindElement(By.LinkText("Rastreamento")).Click();

            var campo = driver.FindElement(By.Id("objetos"));
            campo.Clear();
            campo.SendKeys(codigo);

            driver.FindElement(By.Id("btnPesq")).Click();
        }

        [Then(@"fecho o navegador")]
        public void EntaoFechoONavegador()
        {
            driver.Quit();
        }
    }
}
