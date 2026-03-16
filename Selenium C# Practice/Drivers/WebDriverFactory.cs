using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

public class WebDriverFactory
{
    public static IWebDriver CreateDriver()
    {
        return new ChromeDriver();
    }
}