using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using UsingSelenium.Interface;
using UsingSelenium.Utils;

namespace UsingSelenium.Pages.PayGrades
{
    public class PayGrades : PageObject, ILoadablePage
    {
        public PayGrades(IWebDriver driver) : base() => SetDriver(driver);

        [FindsBy(How = How.XPath, Using = ".//div[@class='orangehrm-header-container']//button[@type='button']")]
        private IWebElement _addButton;

        [FindsBy(How = How.XPath, Using = ".//div[@class='oxd-grid-item oxd-grid-item--gutters']//input[@class='oxd-input oxd-input--active']")]
        private IWebElement _payGrade;

        [FindsBy(How = How.XPath, Using = ".//button[@type='submit']")]
        private IWebElement _saveButton;

        public PayGrades ClickAddButton()
        {
            _addButton.Click();
            return this;
        }

        public PayGrades ClickSaveButton()
        {
            _saveButton.Click();
            return this;
        }

        public PayGrades SetPayGrade(string parameter)
        {
            _payGrade.SendKeys(parameter);
            return this;
        }

        public void WaitUntilPageIsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class='orangehrm-header-container']//button[@type='button']")));
        }
    }
}
