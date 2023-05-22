using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using UsingSelenium.Interface;
using UsingSelenium.Utils;

namespace UsingSelenium.Pages.PayGrades
{
    public class Currencies : PageObject, ILoadablePage
    {

        public Currencies(IWebDriver driver) : base() { SetDriver(driver); }

        [FindsBy(How = How.XPath, Using = ".//div[@class='orangehrm-header-container']//button[@type='button']")]
        private IWebElement _addButton;

        [FindsBy(How = How.CssSelector, Using = ".oxd-select-text-input")]
        private IWebElement _currencyField;

        [FindsBy(How = How.CssSelector, Using = ".oxd-form-row:nth-child(2) .oxd-grid-item:nth-child(1) .oxd-input")]
        private IWebElement _currencyFieldFirst;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Minimum Salary')]/parent::div/following-sibling::div/input")]
        private IWebElement _minimumSalary;

        [FindsBy(How = How.XPath, Using = "//label[contains(text(), 'Maximum Salary')]/parent::div/following-sibling::div/input")]
        private IWebElement _maximumSalary;

        [FindsBy(How = How.XPath, Using = "//h6[text()='Add Currency']/following-sibling::form//button[normalize-space()='Save']")]
        private IWebElement _saveButton;

        [FindsBy(How = How.XPath, Using = "//h6[text()='Add Currency']/following-sibling::form//button[normalize-space()='Cancel']")]
        private IWebElement _cancelButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='oxd-table-cell oxd-padding-cell'][3]/div")]
        private IWebElement _minimumSalaryText;

        [FindsBy(How = How.XPath, Using = "//div[@class='oxd-table-cell oxd-padding-cell'][4]/div")]
        private IWebElement _maximumSalaryText;

        [FindsBy(How = How.XPath, Using = "//span[@class='oxd-text oxd-text--span' and text()='No Records Found']")]
        private IWebElement _emptyCurrenciesText;

        public string GetEmptyCurreniesText()
        {
            return _emptyCurrenciesText.Text;
        }

        public string GetMinimumSalaryText()
        {
            return _minimumSalaryText.Text.Replace(".00", "");
        }

        public string GetMaximumSalaryText()
        {
            return _maximumSalaryText.Text.Replace(".00", ""); ;
        }

        public Currencies ClickSaveButton()
        {
            _saveButton.Click();
            return this;
        }

        public Currencies ClickCancelButton()
        {
            _cancelButton.Click();
            return this;
        }

        public Currencies ClickAddButton()
        {
            _addButton.Click();
            return this;
        }

        public Currencies ClickCurrency()
        {
            Actions action = new(_driver);
            action.Click(_currencyField).Perform();
            WebDriverWait wait = new(_driver, TimeSpan.FromSeconds(3));
            _ = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".oxd-form-row:nth-child(2) .oxd-grid-item:nth-child(1) .oxd-input")));
            action.Click(_currencyFieldFirst).Perform();
            return this;
        }

        public Currencies SetMinimumSalary(string minSalary)
        {
            _minimumSalary.SendKeys(minSalary);
            return this;
        }

        public Currencies SetMaximumSalary(string maxSalary)
        {
            _maximumSalary.SendKeys(maxSalary);
            return this;
        }

        public void WaitUntilPageIsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//div[@class='orangehrm-header-container']//button[@type='button']")));
        }
    }
}
