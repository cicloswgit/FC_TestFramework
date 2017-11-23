using OpenQA.Selenium;
using FC_TestFramework.Core.Setup;
using OpenQA.Selenium.Remote;

namespace FC_TestFramework.Core.Resources
{
    public class ScreenshotUtils : IManager
    {
        public ScreenshotUtils(RemoteWebDriver Driver) : base(Driver) { }

        public virtual void SalvarImagem(string NomeImagem, string Caminho)
        {
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
            var dir = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName;
            dir = dir + "\\" + Caminho;
            System.IO.Directory.CreateDirectory(dir);
            dir += NomeImagem;
            ss.SaveAsFile(dir, ScreenshotImageFormat.Jpeg);
        }

    }
}
