using NUnit.Framework;
//using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Pages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SeleniumAutomation.Tests;

[TestFixture]
public class CheckoutTests
{
    private IWebDriver? driver = null;
    private LoginPage? loginPage = null;
    private CartPage? cartPage = null;
    private ProductPage? productPage = null;
    private CheckoutPage? checkoutPage = null;


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
        productPage = new ProductPage(driver);
        productPage.Add_item_1();
        productPage.Cart_page();
        cartPage.Checkout_btn_click();
        checkoutPage = new CheckoutPage(driver);

    }
    [TearDown]
    public void TearDown()
    {
        driver.Dispose();
    }
    [Test]
    public void Elements_exists()
    {
        Assert.Multiple(() =>
        {
            Assert.That(checkoutPage.Postal_Code_Exists(), Is.True);
            Assert.That(checkoutPage.First_Name_Exists(), Is.True);
            Assert.That(checkoutPage.Last_Name_Exists(),Is.True);
        });
    }
    [Test]
    public void Enter_info()
    {
        string firstname = "fatima zahra";
        string lastname = "el arbaoui";
        string  code = 23400.ToString();
        checkoutPage.Enter_Last_name(lastname);
        checkoutPage.Enter_Code(code);
        checkoutPage.Enter_First_name(firstname);
        checkoutPage.Continue_btn();
        Assert.That(driver.Url,Does.Contain("checkout-step-two"));
    }
    [Test]
    public void Finish_Back_Check()
    {
        string firstname = "fatima zahra";
        string lastname = "el arbaoui";
        string code = 23400.ToString();
        checkoutPage.Enter_Last_name(lastname);
        checkoutPage.Enter_Code(code);
        checkoutPage.Enter_First_name(firstname);
        checkoutPage.Continue_btn();
        checkoutPage.Finish_btn();
        
            Assert.That(driver.Url, Does.Contain("checkout-complete"));
        checkoutPage.Print_btn();
        checkoutPage.Back_product_btn();
            Assert.That(driver.Url, Does.Contain("inventory"));
       
        
    }
}
