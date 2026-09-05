using OpenQA.Selenium;

namespace SauceDemo.Pages;

public class CartPage
{
    private IWebDriver driver;
    private By next_btn = By.Id("continue-shopping");
    private By checkout_btn = By.Id("checkout");
    private By title_page = By.ClassName("checkout-step-one");

    public CartPage(IWebDriver driver)
    {
        this.driver = driver;
    }
    public bool Next_btn_exists()
    {
        return driver.FindElement(next_btn).Displayed;
    }
    public bool Checkout_btn_exists()
    {
        return driver.FindElement(checkout_btn).Displayed;
    }
    public void Next_btn_click()
    {
        driver.FindElement(next_btn).Click();
    }
    public void Checkout_btn_click()
    {
        driver.FindElement(checkout_btn).Click();
    }
    public string Title_page()
    {
        return driver.FindElement(title_page).Text;
    }
    public bool Title_page_exists()
    {
        return driver.FindElement(title_page).Displayed;
    }
}
