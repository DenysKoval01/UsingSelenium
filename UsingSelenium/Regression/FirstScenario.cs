using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using UsingSelenium.Pages;
using UsingSelenium.Pages.PayGrades;


namespace UsingSelenium.Regression
{
    [AllureNUnit]
    public class Tests : BaseTest
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly string minimumSalary = "1000";
        private readonly string maximumSalary = "5000";


        [Test]
        public void ScenarioFirst()
        {
            string randomString = new(Enumerable.Repeat(chars, 6).Select(s => s[new Random().Next(s.Length)]).ToArray());
            Login login = Open<Login>("https://opensource-demo.orangehrmlive.com/");
            login.WaitUntilPageIsLoaded();
            login.SetUserName("Admin").SetPassowrd("admin123");
            login.ClickLogin();


            SearchPage searchPage = new SearchPage(_driver);
            searchPage.WaitUntilPageIsLoaded();
            searchPage.ClickOnAdmin();
            AdminHeader adminHeader = new AdminHeader(_driver);
            adminHeader.ClickJob();
            IList<IWebElement> allElements = adminHeader.GetTableElements();
            (from item in allElements where item.Text == "Pay Grades" select item).FirstOrDefault().Click();

            PayGrades payGrades = new PayGrades(_driver);
            payGrades.WaitUntilPageIsLoaded();
            payGrades.ClickAddButton().SetPayGrade(randomString).ClickSaveButton();

            Currencies currencies = new Currencies(_driver);
            currencies.WaitUntilPageIsLoaded();
            currencies.ClickAddButton();
            currencies.ClickCurrency();
            currencies.SetMinimumSalary(minimumSalary);
            currencies.SetMaximumSalary(maximumSalary);
            currencies.ClickSaveButton();

            Assert.That(minimumSalary, Is.EqualTo(currencies.GetMinimumSalaryText()));
            Assert.That(maximumSalary, Is.EqualTo(currencies.GetMaximumSalaryText()));
        }


        [Test]
        public void ScenarioSecond()
        {
            string randomString = new(Enumerable.Repeat(chars, 6).Select(s => s[new Random().Next(s.Length)]).ToArray());
            Login login = Open<Login>("https://opensource-demo.orangehrmlive.com/");
            login.WaitUntilPageIsLoaded();
            login.SetUserName("Admin").SetPassowrd("admin123");
            login.ClickLogin();


            SearchPage searchPage = new SearchPage(_driver);
            searchPage.WaitUntilPageIsLoaded();
            searchPage.ClickOnAdmin();
            AdminHeader adminHeader = new AdminHeader(_driver);
            adminHeader.ClickJob();
            IList<IWebElement> allElements = adminHeader.GetTableElements();
            (from item in allElements where item.Text == "Pay Grades" select item).FirstOrDefault().Click();

            PayGrades payGrades = new PayGrades(_driver);
            payGrades.WaitUntilPageIsLoaded();
            payGrades.ClickAddButton().SetPayGrade(randomString).ClickSaveButton();

            Currencies currencies = new Currencies(_driver);
            currencies.WaitUntilPageIsLoaded();
            currencies.ClickAddButton();
            currencies.ClickCurrency();
            currencies.SetMinimumSalary(minimumSalary);
            currencies.SetMaximumSalary(maximumSalary);
            currencies.ClickCancelButton();

            Assert.That(currencies.GetEmptyCurreniesText(), Is.EqualTo("No Records Found"));


            //use  allure serve allure-results to see Allure report
        }
    }
}