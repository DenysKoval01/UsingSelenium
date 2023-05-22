using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingSelenium.Interface;
using UsingSelenium.Utils;
using SeleniumExtras.PageObjects;

namespace UsingSelenium.Pages
{
    public class SearchPage : PageObject, ILoadablePage
    {

        public SearchPage(IWebDriver driver) : base() { SetDriver(driver); }


        [FindsBy(How = How.XPath, Using = ".//ul[@class='oxd-main-menu']/li[@class='oxd-main-menu-item-wrapper'][1]//span[@class='oxd-text oxd-text--span oxd-main-menu-item--name']")]
        private IWebElement _admin;

        public void ClickOnAdmin()
        {
            _admin.Click();
        }

        public void WaitUntilPageIsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//ul[@class='oxd-main-menu']/li[@class='oxd-main-menu-item-wrapper'][1]//span[@class='oxd-text oxd-text--span oxd-main-menu-item--name']")));
        }
    }
}
