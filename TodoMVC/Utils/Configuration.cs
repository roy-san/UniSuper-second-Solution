using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TodoMVC.Steps
{
    [Binding]
    public class Configuration
    {
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get { return driver ?? (driver = new ChromeDriver()); }
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            Driver.Close();
            Driver.Quit();
            driver = null;
        }

    }
}
