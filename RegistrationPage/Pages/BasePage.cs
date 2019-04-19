namespace RegistrationPage.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;

    public abstract class BasePage
    {
        private IWebDriver _driver;
        

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string BaseUrl => "http://automationpractice.com";

        public IWebDriver Driver => _driver;

        public WebDriverWait Wait => new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

        public string Url { get; protected set; }

        public void NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
        }

    }
}
