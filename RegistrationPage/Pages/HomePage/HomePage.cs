namespace RegistrationPage.Pages
{
    using OpenQA.Selenium;

    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            Url = "http://automationpractice.com/index.php";
        }

        public IWebElement SignInButton => Wait.Until((d) => { return d.FindElement(By.CssSelector("#header>div.nav>div>div>nav>div.header_user_info")); });
    }
}
