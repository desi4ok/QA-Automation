namespace RegistrationPage
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using RegistrationPage.Models;
    using RegistrationPage.Pages;
    using RegistrationPage.Pages.RegistrationPage;
    using System;
    using System.IO;
    using System.Reflection;

    public class RegistrationPageProblem
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private HomePage homePage;
        private LoginPage loginPage;
        private RegistrationPage regPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //driver = new FirefoxDriver(@"C:\TMP");
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
            regPage = new RegistrationPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
/*
        [Test]
        public void NavigateToRegistrationPage()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

          //  signInButton.Click();

            string expectedURL = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
            Assert.AreEqual(expectedURL, driver.Url);

            IWebElement authenticationTitle = driver.FindElement(By.XPath("//*[@id='center_column']/h1"));
            string authenticationText = authenticationTitle.Text;
            string expectedText = "AUTHENTICATION";
            Assert.AreEqual(expectedText, authenticationText);

          //  string emailInputId = "email_create";
         //   Assert.AreEqual("input", emailInput.TagName);
          //  string elementId = emailInput.GetAttribute("id");
          //  Assert.AreEqual(emailInputId, elementId);

           
          //  string buttonText = button.GetAttribute("value");
          //  Assert.AreEqual("Create an account", buttonText);
        }
        */
        [Test]
        public void PositiveScenario_RegistrationForm()
        {
            
            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../JSONs/ValidRegistrationUser.json");
            var user = RegistrationUser.FromJson(File.ReadAllText(path));

            loginPage.NavigateTo();

            loginPage.EmailInput.Clear();
            loginPage.EmailInput.SendKeys("desi14@abv.bg");
            loginPage.SubmitButton.Click();

            regPage.FillForm(user);
        }

        /*
        [Test]
        public void NegativeScenario_EmptyForm()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");

            IWebElement emailInput = driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys("desi2@abv.bg");

            IWebElement submitButton = driver.FindElement(By.Id("SubmitCreate"));
            submitButton.Click();

            IWebElement registerButton = wait.Until((d) => { return d.FindElement(By.Id("submitAccount")); });
            registerButton.Click();
        }

        [Test]
        public void NegativeScenario_InvalidZip()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");

            IWebElement emailInput = driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys("desi2@abv.bg");

            IWebElement submitButton = driver.FindElement(By.Id("SubmitCreate"));
            submitButton.Click();
            
            IWebElement firstName = wait.Until((d) => { return d.FindElement(By.Id("customer_firstname")); });
            firstName.SendKeys("Desisalava");

            IWebElement lastName = wait.Until((d) => { return d.FindElement(By.Id("customer_lastname")); });
            lastName.SendKeys("Goleva");

            IWebElement email = wait.Until((d) => { return d.FindElement(By.Id("email")); });
            email.Click();

            IWebElement password = wait.Until((d) => { return d.FindElement(By.Id("passwd")); });
            password.SendKeys("444444");
            
            IWebElement address = wait.Until((d) => { return d.FindElement(By.Id("address1")); });
            address.SendKeys("Vitosha 10");

            IWebElement city = wait.Until((d) => { return d.FindElement(By.Id("city")); });
            city.SendKeys("Sofia");

            IWebElement stateHelp = wait.Until((d) => { return d.FindElement(By.Id("id_state")); });
            SelectElement state = new SelectElement(stateHelp);
            state.SelectByText("Colorado");

            IWebElement zip = wait.Until((d) => { return d.FindElement(By.Id("postcode")); });
            zip.SendKeys("1234");

            IWebElement countryHelp = wait.Until((d) => { return d.FindElement(By.Id("id_country")); });
            SelectElement country = new SelectElement(countryHelp);
            country.SelectByText("United States");

            IWebElement mobilePhone = wait.Until((d) => { return d.FindElement(By.Id("phone_mobile")); });
            mobilePhone.SendKeys("555-555");

            IWebElement registerButton = wait.Until((d) => { return d.FindElement(By.Id("submitAccount")); });
            registerButton.Click();
        }

        [Test]
        public void NegativeScenario_AlreadyRegisteredEmail()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");

            IWebElement emailInput = driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys("desi4@abv.bg");

            IWebElement submitButton = driver.FindElement(By.Id("SubmitCreate"));
            submitButton.Click();
        }

        [Test]
        public void NegativeScenario_InvalidPassword()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");

            IWebElement emailInput = driver.FindElement(By.Id("email_create"));
            emailInput.SendKeys("desi3@abv.bg");

            IWebElement submitButton = driver.FindElement(By.Id("SubmitCreate"));
            submitButton.Click();

            IWebElement firstName = wait.Until((d) => { return d.FindElement(By.Id("customer_firstname")); });
            firstName.SendKeys("Desisalava");

            IWebElement lastName = wait.Until((d) => { return d.FindElement(By.Id("customer_lastname")); });
            lastName.SendKeys("Goleva");

            IWebElement email = wait.Until((d) => { return d.FindElement(By.Id("email")); });
            email.Click();

            IWebElement password = wait.Until((d) => { return d.FindElement(By.Id("passwd")); });
            password.SendKeys("444");

            IWebElement address = wait.Until((d) => { return d.FindElement(By.Id("address1")); });
            address.SendKeys("Vitosha 10");

            IWebElement city = wait.Until((d) => { return d.FindElement(By.Id("city")); });
            city.SendKeys("Sofia");

            IWebElement stateHelp = wait.Until((d) => { return d.FindElement(By.Id("id_state")); });
            SelectElement state = new SelectElement(stateHelp);
            state.SelectByText("Colorado");
            
            IWebElement countryHelp = wait.Until((d) => { return d.FindElement(By.Id("id_country")); });
            SelectElement country = new SelectElement(countryHelp);
            country.SelectByText("United States");

            IWebElement zip = wait.Until((d) => { return d.FindElement(By.Id("postcode")); });
            zip.SendKeys("12345");

            IWebElement mobilePhone = wait.Until((d) => { return d.FindElement(By.Id("phone_mobile")); });
            mobilePhone.SendKeys("555-555");

            IWebElement registerButton = wait.Until((d) => { return d.FindElement(By.Id("submitAccount")); });
            registerButton.Click();
        }
        */
        

    }
}
