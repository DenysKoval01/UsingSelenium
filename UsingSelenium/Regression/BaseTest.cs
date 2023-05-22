using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using UsingSelenium.Utils;

namespace UsingSelenium.Regression
{
    public class BaseTest
    {
        public IWebDriver _driver;

        [SetUp]
        public void BeforeWholeTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            _driver = new ChromeDriver(options);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        protected T Open<T>(string url) where T : PageObject, new()
        {
            _driver.Navigate().GoToUrl(url);

            var page = new T();
            page.SetDriver(_driver);

            return page;
        }
    }
}
