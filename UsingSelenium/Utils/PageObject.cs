using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UsingSelenium.Utils
{
    public class PageObject
    {

        public PageObject() { }

        protected IWebDriver _driver;

        public void SetDriver(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
