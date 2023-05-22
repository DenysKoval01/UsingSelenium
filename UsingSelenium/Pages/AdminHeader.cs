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
    public class AdminHeader : PageObject, ILoadablePage
    {

        public AdminHeader(IWebDriver driver) : base() => SetDriver(driver);

        [FindsBy(How = How.XPath, Using = ".//span[@class='oxd-topbar-body-nav-tab-item'][contains(text(),'User Management ')]")]
        private IWebElement _userManagement;

        [FindsBy(How = How.XPath, Using = ".//span[@class='oxd-topbar-body-nav-tab-item'][contains(text(),'Job')]")]
        private IWebElement _job;


        [FindsBy(How = How.XPath, Using = "//ul[@class='oxd-dropdown-menu']/li/a[@role='menuitem']")]
        private IList<IWebElement> _dropDownElements;

        public void ClickJob()
        {
            _job.Click();
        }

        public IList<IWebElement> GetTableElements() {
            return _dropDownElements;
        }
        public void WaitUntilPageIsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//span[@class='oxd-topbar-body-nav-tab-item'][contains(text(),'Job')]")));
        }

    }
}
