using NUnit.Framework;
using SauceDemo.Pages;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SeleniumAutomation.Tests;

[TestFixture]
public class ProductsTests
{
    private IWebDriver? driver = null;
    private ProductPage? product_page = null;
    private LoginPage? loginPage = null;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage = new LoginPage(driver);
        product_page = new ProductPage(driver);
        string username = "standard_user";
        string password = "secret_sauce";

        // Act
        loginPage.EnterUsername(username);
        loginPage.EnterPassword(password);
        loginPage.ClickLogin();
    }
    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }
    [Test]
    public void AddItem_1()
    {
        product_page.Add_item_1();
        int nbItems = product_page.Get_nb_items();

        Assert.That(nbItems, Is.EqualTo(1));
    }
    [Test]
    public void RemoveItem_1()
    {
        product_page.Add_item_1();
        product_page.Remove_item_1();
        Assert.That(product_page.IsCartBadgePresent(), Is.False);
    }
    [Test]
    public void Check_Items()
    {
        var items = product_page.Items_List();

        Assert.That(items.Count, Is.EqualTo(6));
    }
    [Test]
    public void Cart_page()
    {
        product_page.Cart_page();
        Assert.Multiple(
            () =>
            {
                Assert.That(product_page.Cart_items(), Is.True);
                Assert.That(driver.Url, Does.Contain("cart.html"));
            });
        
    }



}
