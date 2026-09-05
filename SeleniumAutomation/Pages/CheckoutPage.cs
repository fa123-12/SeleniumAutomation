using OpenQA.Selenium;

namespace SauceDemo.Pages;

public class CheckoutPage
{
    private IWebDriver driver;
    
    private By first_name = By.Id("first-name");
    private By last_name = By.Id("last-name");
    private By postal_code = By.Id("postal-code");
    private By next_btn = By.Id("continue");
    private By back_btn = By.Id("cancel");
    private By move_print_btn = By.Id("finish");
    private By back_products = By.Id("back-to-products");
    private By print_btn = By.Id("generate-pdf-order");
    public CheckoutPage(IWebDriver driver)
    {
        this.driver = driver;
    }
    public bool First_Name_Exists()
    {
        return driver.FindElement(first_name).Displayed;
    }
    public bool Last_Name_Exists()
    {
        return driver.FindElement(last_name).Displayed;
    }
    public bool Postal_Code_Exists()
    {
        return driver.FindElement(postal_code).Displayed;
    }
    public void Enter_First_name(string firstname)
    {
        driver.FindElement(first_name).SendKeys(firstname);
    }
    public void Enter_Last_name(string lastname)
    {
        driver.FindElement(last_name).SendKeys(lastname);
    }
    public void Enter_Code(string  code)
    {
        driver.FindElement(postal_code).SendKeys(code);
    }
    public void Continue_btn()
    {
        driver.FindElement(next_btn).Click();
    }
    public void Cancel_btn()
    {
        driver.FindElement(back_btn).Click();
    }
    public void Finish_btn()
    {
        driver.FindElement(move_print_btn).Click();
    }
    public void Print_btn()
    {
        driver.FindElement(print_btn).Click();
    }
    public void Back_product_btn()
    {
        driver.FindElement(back_products).Click();
    }
}
