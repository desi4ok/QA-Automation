using OpenQA.Selenium;

namespace RegistrationPage.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        }
         
        public IWebElement EmailInput => Wait.Until((d) => { return d.FindElement(By.Id("email_create")); });

        public IWebElement SubmitButton => Wait.Until((d) => { return d.FindElement(By.Id("SubmitCreate")); });

        public IWebElement SubmitButtonText => Wait.Until((d) => { return d.FindElement(By.XPath(@"//*[@id=""create-account_form""]/div/div[3]/input[2]")); });
    }
}
