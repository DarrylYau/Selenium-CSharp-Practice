

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


public class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;

    public BasePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait (driver, TimeSpan.FromSeconds(10));
    }

    protected IWebElement WaitForElement(By locator)
    {
        return wait.Until(d=> d.FindElement(locator));
    }
    
    protected void Click(By locator)
    {
        WaitForElement(locator).Click();
    }

    protected void Type(By locator, string text)
    {
        WaitForElement(locator).SendKeys(text);
    }
}