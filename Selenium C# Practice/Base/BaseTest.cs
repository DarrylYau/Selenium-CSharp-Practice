using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

public class BaseTest
{
    protected IWebDriver driver;
    protected ExtentReports extent;
    protected ExtentTest test;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        extent = ExtentManager.GetInstance();
    }


    [SetUp]
    public void Setup()
    {
        TestContext.Out.WriteLine("Setup executed");

        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);

        driver = new ChromeDriver();
        Console.WriteLine("Driver created");
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        Console.WriteLine("Navigation completed");
        
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        test = extent.CreateTest("Report Flush Check");
        test.Info("Flushing report now");
        extent.Flush();
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string projectDir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                Console.WriteLine(projectDir);
                string reportDir = Path.Combine(projectDir, "Reports");
                string screenshotDir = Path.Combine(reportDir, "Screenshots");

                if (!Directory.Exists(screenshotDir))
                {
                    Directory.CreateDirectory(screenshotDir);
                }

                string fileName = $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string fullPath = Path.Combine(screenshotDir, fileName);
                //Check driver is still alive
                if (driver != null)
                {
                    try
                    {
                        //Take screenshot and save to file
                        var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                        string base64 = screenshot.AsBase64EncodedString;
                        screenshot.SaveAsFile(fullPath);

                        //Attach Base64 (for report)
                        test.AddScreenCaptureFromBase64String(base64, "Failure Screenshot");
                    }
                    catch
                    {
                        Console.WriteLine("Driver not available for screenshot");
                    }

                }
                test.Fail(TestContext.CurrentContext.Result.Message);

            }
            else
            {
                test.Pass("Test passed");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error in TearDown:" + ex.Message);
        }
        
        driver?.Quit();
        driver?.Dispose();
    }

}
