using NUnit.Framework;
public class LoginTests : BaseTest
{
    [Test, TestCaseSource(typeof(TestDataReader), nameof(TestDataReader.GetLoginData))]
    public void ValidUserCanLogin(LoginData data)
    {
        TestContext.Out.WriteLine("Test started");
        TestContext.Out.WriteLine($"Running test for user: {data.username}");

        LoginPage loginPage = new LoginPage(driver);
        loginPage.Login(data.username, data.password);

        InventoryPage inventoryPage = new InventoryPage(driver);

        if (data.isValid)
        {
            Assert.That(inventoryPage.IsInventoryPageDisplayed(), 
                "Expected successful login but failed");
        }
        else
        {
            Assert.That(loginPage.IsErrorDisplayed,
                "Expected login failure but user was logged in");
        }
        

    }
}

