using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.PhantomJS;
using System.Web.Configuration;
using OpenQA.Selenium.Remote;
using System.Threading;
using BoDi;

namespace FC_TestFramework.Core.Setup
{
    public class SetupBrowser
    {

        public  RemoteWebDriver Driver { get; set; }
        private RemoteWebDriver driver;
        

        /**Método de recuperação do Driver Selenium 
         * e configuração do Browser de execução dos testes.
         * Deve ser implementado no início de cada classe Step Definitions
         */
        public RemoteWebDriver Setup()
        {
            Console.WriteLine("Driver iniciado");

            Driver = RecuperarDriver();

            return Driver;
        }
        
        /**Método de recuperação do Driver Selenium 
        * e configuração do Browser de execução dos testes.
        * Deve ser implementado no início de cada classe Step Definitions
        */
        public RemoteWebDriver RecuperarInstancia()
        {
            return Driver;
        }

        /**Método interno da classe que deve Recuperar 
         * o Driver Selenium conforme Browser informado
         */
        private RemoteWebDriver RecuperarDriver()
        {
            string Browser = WebConfigurationManager.AppSettings["Browser"];

            if (Browser.Equals("chrome"))
            {
                ChromeOptions Options = new ChromeOptions();
                Options.AddArguments("--disable-extensions");
                Options.AddArguments("--start-maximized");

                ChromeDriverService Servico = ChromeDriverService.CreateDefaultService();

                return Driver = new ChromeDriver(Servico, Options, TimeSpan.FromMinutes(3));

            }
            else if (Browser.Equals("firefox"))
            {
                FirefoxOptions Options = new FirefoxOptions();
                Options.AddArguments("--disable-extensions");
                Options.AddArguments("--start-maximized");

                FirefoxDriverService Servico = FirefoxDriverService.CreateDefaultService();

                return Driver = new FirefoxDriver(Servico, Options, TimeSpan.FromMinutes(3));

            }
            else if (Browser.Equals("ie"))
            {
                InternetExplorerOptions Options = new InternetExplorerOptions();
                Options.AddAdditionalCapability("platform", "Windows");
                Options.AddAdditionalCapability("version", "10");
                Options.IgnoreZoomLevel = true;
                Options.EnableNativeEvents = false;
                Options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                Options.EnsureCleanSession = true;
                Options.UnexpectedAlertBehavior = InternetExplorerUnexpectedAlertBehavior.Ignore;
                Options.EnableFullPageScreenshot = true;

                InternetExplorerDriverService Servico = InternetExplorerDriverService.CreateDefaultService();

                return Driver = new InternetExplorerDriver(Servico, Options, TimeSpan.FromMinutes(3));
            }
            else if (Browser.Equals("edge"))
            {
                EdgeOptions Options = new EdgeOptions();
                Options.AddAdditionalCapability("platform", "Windows");
                Options.AddAdditionalCapability("version", "10");

                EdgeDriverService Servico = EdgeDriverService.CreateDefaultService();

                return Driver = new EdgeDriver(Servico, Options, TimeSpan.FromMinutes(3));
            }
            else
            {
                PhantomJSOptions Options = new PhantomJSOptions();
                Options.AddAdditionalCapability("platform", "Windows");
                Options.AddAdditionalCapability("version", "10");

                PhantomJSDriverService Servico = PhantomJSDriverService.CreateDefaultService();

                return Driver = new PhantomJSDriver(Servico, Options, TimeSpan.FromMinutes(3));
            }
        }

        /**Método interno da classe que deve Navegar até  
         * a URL específica do ambiente informado
         */
        public void DirecionarAmbiente(string CaminhoMenu)
        {
            string Ambiente = WebConfigurationManager.AppSettings["Ambiente"];
            Driver.Navigate().GoToUrl(Ambiente+"/"+CaminhoMenu);
            Driver.Manage().Window.Maximize();
        }

        /**Método que encerra a sessão do Driver Selenium 
         * e fecha o Browser.
         * Deve ser implementado no final de cada classe Step Definitions
         */
        public void TearDown()
        {
            if(Driver != null)
            {
                Driver.Close();
                Driver.Quit();
            }

            Console.WriteLine("Driver finalizado.");
        }
    }
}
