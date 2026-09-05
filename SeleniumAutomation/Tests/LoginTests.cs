using NUnit.Framework;
using SauceDemo.Pages;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SeleniumAutomation.Tests;

[TestFixture]
public class SwagTests
{
    private IWebDriver? driver = null;
    private LoginPage? loginPage = null;

    [SetUp]
    public void SetUp()
    {
        driver=new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        loginPage = new LoginPage(driver);
    }
    [Test]
    public void  OpenChrome()
    {
        driver.Navigate().GoToUrl("https://www.google.com");

        Assert.That(driver.Title, Is.Not.Empty);
        Console.WriteLine("the title of this page is "+driver.Title);
    }
    [Test]
    public void Title_Check()
    {
        Assert.Multiple(() =>
        {

            Assert.That(loginPage.LoginTitle(), Is.EqualTo("Swag Labs"));
            Assert.That(loginPage.LoginTitle(), Is.EqualTo("swag labs"));
            Assert.That(loginPage.CheckElements1().Text, Is.EqualTo("locked_out_user"));
            Assert.That(loginPage.CheckElements2().Text, Does.Contain("error"));
        }
        );
        
    }

    [Test]
    public void Login_WithValidCredentials_ShouldSucceed()
    {
        // Arrange
        string username = "standard_user";
        string password = "secret_sauce";

        // Act
        loginPage.EnterUsername(username);
        loginPage.EnterPassword(password);
        loginPage.ClickLogin();

        // Assert
        Assert.That(driver.Url, Does.Contain("inventory"));
    }

    [TearDown]
    public void TearDown()
    {
        driver?.Dispose();
    }
}
