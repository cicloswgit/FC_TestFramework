using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace FC_TestFramework.Core.Setup
{
    public abstract class IManager
    {
        public RemoteWebDriver Driver { get; set; }

        public IManager(RemoteWebDriver driver)
        {
            Driver = driver;
        }

    }
}
