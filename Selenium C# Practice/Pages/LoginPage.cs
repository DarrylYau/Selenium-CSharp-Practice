using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

public class LoginPage
{
    private IWebDriver driver;

    private By username = By.Id("user-name");
    private By password = By.Id("password");
    private By loginButton = By.Id("login-button");

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Login (string user, string pass)
    {
        driver.FindElement(username).SendKeys(user);
        driver.FindElement(password).SendKeys(pass);
        driver.FindElement(loginButton).Click();
    }
}