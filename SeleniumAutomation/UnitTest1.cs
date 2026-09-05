using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SeleniumAutomationtest.Tests;

public class GoogleTests
{
    private IWebDriver driver;

    //[SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
    }

    //[Test]
    [Order(1)]
    public void SearchWikipedia()
    {
        driver.Navigate().GoToUrl("https://www.wikipedia.org");

        // Vérifier la page
        Assert.That(driver.Title, Does.Contain("Wikipedia"));
        IWebElement language = driver.FindElement(By.Id("searchLanguage"));

        //SelectElement select = new SelectElement(language);

        //select.SelectByValue("fr");

        // Entrer la recherche
        driver.FindElement(By.Id("searchInput"))
              .SendKeys("maroc" + Keys.Enter);

        // Attendre que le titre du résultat apparaisse
        WebDriverWait wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(10)
        );

        IWebElement result = wait.Until(
            d => d.FindElement(By.ClassName("mw-page-title-main"))
        );

        // Vérifier le résultat
        Assert.That(result.Text, Is.EqualTo("Maroc"));
    }
    //[Test]
    [Order(2)]
    public void Check_language()
    {
        driver.Navigate().GoToUrl("https://www.wikipedia.org");
        IWebElement language =
        driver.FindElement(By.Id("searchLanguage"));
       
        SelectElement select=new SelectElement(language);
        select.SelectByValue("ar");
        IWebElement selected = select.SelectedOption;
        Assert.That(selected.Text, Is.EqualTo("العربية"));
        driver.FindElement(By.Id("searchInput"))
              .SendKeys("فاطمة الزهراء" + Keys.Enter);
       
        WebDriverWait wait = new WebDriverWait(
            driver,
            TimeSpan.FromSeconds(10)
        );



        // Vérifier le résultat
        //wait.Until(d => d.Title.Contains("فاطمة الزهراء"));

        Assert.That(driver.Title, Does.Contain("فاطمة الزهراء"));

    }

    //[TearDown]
    public void TearDown()
    {
        if (driver != null)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}