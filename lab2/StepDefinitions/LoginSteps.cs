using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; 
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace YourProjectNamespace
{
    [Binding]
    public class LoginSteps
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        public LoginSteps()
        {
            // ���������� ������� � �����������
            driver = new ChromeDriver(); // �� ������ ������� ����� ������� �� ��������
            loginPage = new LoginPage(driver);
        }

        [Given(@"I am on the banking website")]
        public void GivenIAmOnTheBankingWebsite()
        {
            loginPage.OpenLoginPage("https://www.globalsqa.com/angularJs-protractor/BankingProject"); // ������ URL �� �������� URL ������ ���-�����
        }

        [When(@"I select ""Login as Bank Manager"" option")]
        public void WhenISelectLoginAsBankManagerOption()
        {
            loginPage.ClickLoginAsBankManager();
        }

        [Then(@"I click ""Customers"" to see a list of customers")]
        public void ClickCustomers() {
            loginPage.ClickCustomers();
        }

        [When(@"I click the ""First Name""")]
        public void ClickFirstName()
        {
            loginPage.ClickFirstName();
        }

        [Then(@"I should see the sorted list by DESC")]
        public void SortByDESC()
        {
            bool res = loginPage.SortCustomersReverse(true);
            Assert.IsTrue(res, "The sorting by desc doesn't work.");
        }

        [Then(@"I should see the sorted list by ASC")]
        public void SortByASC()
        {
            bool res = loginPage.SortCustomersReverse(false);
            Assert.IsTrue(res, "The sorting by asc doesn't work.");
        }

        [Then(@"I should close Chrome")]
        public void CloseChrome()
        {
            loginPage.CloseDriver();
        }
    }
}
