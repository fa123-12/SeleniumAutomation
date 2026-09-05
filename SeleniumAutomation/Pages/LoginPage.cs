using OpenQA.Selenium;

namespace SauceDemo.Pages;
public class LoginPage
{
    private IWebDriver driver;

    private By username = By.Id("user-name");
    private By password = By.Id("password");
    private By loginButton = By.Id("login-button");
    private By titleValue = By.ClassName("login_logo");
    private By name1 = By.LinkText("locked_out_user");
    private By name2 = By.PartialLinkText("error");

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public string LoginTitle()
    {
        return driver.FindElement(titleValue).Text;
       
    }
    public void EnterUsername(string usernameValue)
    {
        driver.FindElement(username).SendKeys(usernameValue);
    }

    public void EnterPassword(string passwordValue)
    {
        driver.FindElement(password).SendKeys(passwordValue);
    }

    public void ClickLogin()
    {
        driver.FindElement(loginButton).Click();
    }
    public IWebElement CheckElements1()
    {
        return driver.FindElement(name1);
        
    }
    public IWebElement CheckElements2()
    {
        return driver.FindElement(name2);
    }
}
