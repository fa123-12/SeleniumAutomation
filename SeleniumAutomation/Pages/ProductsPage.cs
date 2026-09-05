using OpenQA.Selenium;

namespace SauceDemo.Pages;

public class ProductPage
{
private IWebDriver driver;
    private By cart_cont = By.Id("cart_contents_container");
    private By cartbtn = By.CssSelector(".shopping_cart_link");
    //private By filter = By.CssSelector(".product_sort_container");
    private By items_name = By.CssSelector(".inventory_item_name ");
    private By add_item1 = By.Id("add-to-cart-sauce-labs-bike-light");
    private By add_item2 = By.Id("add-to-cart-sauce-labs-backpack");

    private By add_item3 = By.Id("add-to-cart-sauce-labs-bolt-t-shirt");

    private By add_item4 = By.Id("add-to-cart-sauce-labs-fleece-jacket");
    private By add_item5 = By.Id("add-to-cart-sauce-labs-onesie");
    private By add_item6 = By.Id("add-to-cart-test.allthethings()-t-shirt-(red)");
    private By remove_item2 = By.Id("remove-sauce-labs-backpack");
    private By remove_item1 = By.Id("remove-sauce-labs-bike-light");

    private By remove_item3 = By.Id("remove-sauce-labs-bolt-t-shirt");

    private By remove_item4 = By.Id("remove-sauce-sauce-labs-fleece-jacket");
    private By remove_item5 = By.Id("remove-sauce-sauce-labs-onesie");
    private By remove_item6 = By.Id("remove-sauce-test.allthethings()-t-shirt-(red)");
    private By nb_items = By.CssSelector(".shopping_cart_badge");

    public ProductPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Add_item_1()
    {
        driver.FindElement(add_item1).Click();
    }
    public void Remove_item_1()
    {
        driver.FindElement(remove_item1).Click();
    }
    public void Add_item_2()
    {
        driver.FindElement(add_item2).Click();
    }
    public void Add_item_3()
    {
        driver.FindElement(add_item3).Click();
    }

    public void Add_item_4()
    {
        driver.FindElement(add_item4).Click();
    }

    public void Add_item_5()
    {
        driver.FindElement(add_item5).Click();
    }
    public void Add_item_6()
    {
        driver.FindElement(add_item6).Click();
    }
    public int Get_nb_items()
    {
        return int.Parse(driver.FindElement(nb_items).Text);
    }
    public bool IsCartBadgePresent()
    {
        return driver.FindElements(nb_items).Count > 0;
    }
    public IReadOnlyCollection<IWebElement> Items_List()
    {
        return driver.FindElements(items_name);
    }
    public void Cart_page()
    {
        driver.FindElement(cartbtn).Click();
    }
    public bool Cart_items()
    {
        return driver.FindElement(cart_cont).Displayed == true;
    }






}