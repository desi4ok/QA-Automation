using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrationPage.Pages.AccountPage
{
    public class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver) { }

        public IWebElement WelcomeMessage => Wait.Until((d) => { return d.FindElement(By.ClassName("info-account")); });
    }
}
