using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingSelenium.Interface;
using UsingSelenium.Utils;

namespace UsingSelenium.Pages
{
    public class Login : PageObject, ILoadablePage
    {
        public Login(IWebDriver driver) : base() => SetDriver(driver);

        public Login() { }

        [FindsBy(How = How.XPath, Using = ".//input[@name='username']")]
        private IWebElement _username;

        [FindsBy(How = How.XPath, Using = ".//input[@name='password']")]
        private IWebElement _password;

        [FindsBy(How = How.XPath, Using = ".//button[@type='submit']")]
        private IWebElement _login;


        public Login SetUserName(string userName)
        {
            _username.SendKeys(userName);
            return this;
        }

        public Login SetPassowrd(string password)
        {
            _password.SendKeys(password);
            return this;
        }

        public Login ClickLogin()
        {
            _login.Click();
            return this;
        }

        public void WaitUntilPageIsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//input[@name='username']")));
        }

    }
}
