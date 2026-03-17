

using OpenQA.Selenium;

public class InventoryPage: BasePage
{
    public InventoryPage(IWebDriver driver): base(driver) { }

    private By inventoryContainer = By.Id("inventory_container");
    
    public bool IsInventoryPageDisplayed()
    {
        return WaitForElement(inventoryContainer).Displayed;
    }
}