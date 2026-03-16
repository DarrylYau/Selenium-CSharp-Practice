using NUnit.Framework;
public class LoginTests : BaseTest
{
    [Test]
    public void ValidUserCanLogin()
    {
        Console.WriteLine("Test started");
        Console.WriteLine(driver.Url);
        LoginPage loginPage = new LoginPage(driver);
        loginPage.Login("standard_user", "secret_sauce");
        Assert.That(driver.Url.Contains("inventory"), "After login the browser should be on the inventory page ");
    }
}

