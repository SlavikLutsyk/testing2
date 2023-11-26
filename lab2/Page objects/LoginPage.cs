using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Linq.Expressions;
using System.Threading;

public class LoginPage
{
    private IWebDriver driver;
    private WebDriverWait wait;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
        this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
    }

    // Метод для відкриття сторінки в браузері
    public void OpenLoginPage(string url)
    {
        driver.Navigate().GoToUrl(url);
    }

    // Метод для вибору опції "Login as Bank Manager"
    public void ClickLoginAsBankManager()
    {
        // Знайдіть елемент кнопки "Bank Manager Login" за допомогою селектора і натисніть на неї
        IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[text()='Bank Manager Login']")));
        loginButton.Click();
    }

    public void ClickCustomers()
    {
        IWebElement customers = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[contains(text(),'Customers')]")));
        customers.Click();
    }

    public void ClickFirstName()
    {
        Thread.Sleep(TimeSpan.FromSeconds(5));
        IWebElement firstNameButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//a[contains(text(),'First Name')]")));
        firstNameButton.Click();
    }

    public bool SortCustomersReverse(bool flag)
    {
        IOrderedEnumerable<IWebElement> orderedList;
        IList<IWebElement> customers = driver.FindElements(By.TagName("tr"));
        customers = customers.Skip(1).ToList<IWebElement>();
        if (flag)
            orderedList = customers.OrderByDescending(c => c.FindElement(By.TagName("td")).Text);
        else orderedList = customers.OrderBy(c => c.FindElement(By.TagName("td")).Text);
        var orderedCustomers = orderedList.ToArray();
        flag = true;
        for(int i = 0; i < customers.Count; i++)
        {
           //Assert.Warn($"{orderedCustomers[i].FindElement(By.TagName("td")).Text} — {customers[i].FindElement(By.TagName("td")).Text}");
            if (orderedCustomers[i].FindElement(By.TagName("td")).Text != customers[i].FindElement(By.TagName("td")).Text)
                flag = false;
        }
        return flag;
    }

    public void CloseDriver()
    {
        driver.Quit();
    }

}
