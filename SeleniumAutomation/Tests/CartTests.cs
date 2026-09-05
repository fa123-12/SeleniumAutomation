using NUnit.Framework;
using SauceDemo.Pages;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SeleniumAutomation.Tests;

[TestFixture]
public class CartTests
{
    private IWebDriver driver = null;
    private LoginPage loginPage = null;
    private CartPage cartPage = null;
    private ProductPage productPage = null;


    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage = new LoginPage(driver);
        cartPage = new CartPage(driver);
        string username = "standard_user";
        string password = "secret_sauce";

        // Act
        loginPage.EnterUsername(username);
        loginPage.EnterPassword(password);
        loginPage.ClickLogin();
        productPage=new ProductPage(driver);
        productPage.Add_item_1();
        productPage.Cart_page();

    }
    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }
    [Test]
    public void Check_title()
    {
        cartPage.Checkout_btn_click();
        if (cartPage.Title_page_exists())
        {
            Assert.That(cartPage.Title_page(), Is.EqualTo("Checkout: Your Information"));
        }
    }
    [Test]
    public void Check_btns()
    {
        Assert.Multiple(() =>
        {
            Assert.That(cartPage.Next_btn_exists(), Is.True);
            Assert.That(cartPage.Checkout_btn_exists(),Is.True);
        });
    }
    [Test]
    public void Check_url_next()
    {
        cartPage.Next_btn_click();
        Assert.That(driver.Url, Does.Contain("cart.html"));
    }
    [Test]
    public void Check_url_checkout()
    {
        cartPage.Checkout_btn_click();
        Assert.That(driver.Url, Does.Contain("checkout-step-one"));
    }
}