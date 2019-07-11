namespace RegistrationPage
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using RegistrationPage.Models;
    using RegistrationPage.Pages;
    using RegistrationPage.Pages.AccountPage;
    using RegistrationPage.Pages.RegistrationPage;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    public class RegistrationPageProblem
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private HomePage homePage;
        private LoginPage loginPage;
        private RegistrationPage regPage;
        private AccountPage accountPage;

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
            accountPage = new AccountPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void NavigateToRegistrationPage()
        {
            homePage.NavigateTo();

            homePage.SignInButton.Click();

            string authenticationText = homePage.AuthenticationTitle.Text;
            string expectedText = "AUTHENTICATION";
            Assert.AreEqual(expectedText, authenticationText);

            Assert.AreEqual("input", loginPage.EmailInput.TagName);

            string emailInputId = "email_create";
            string elementId = loginPage.EmailInput.GetAttribute("id");
            Assert.AreEqual(emailInputId, elementId);

            string buttonText = loginPage.SubmitButtonText.GetAttribute("value");
            Assert.AreEqual("Create an account", buttonText);
        }

        [Test]
        public void PositiveScenario_RegistrationForm()
        {

            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../JSONs/ValidRegistrationUser.json");
            var user = RegistrationUser.FromJson(File.ReadAllText(path));

            loginPage.NavigateTo();

            loginPage.EmailInput.Clear();
            loginPage.EmailInput.SendKeys("desi20@abv.bg");
            loginPage.SubmitButton.Click();

            regPage.FillForm(user);

            Assert.IsTrue(accountPage.WelcomeMessage.Displayed);
            StringAssert.Contains("Welcome to your account", accountPage.WelcomeMessage.Text);
        }


        [Test]
        public void NegativeScenario_EmptyForm()
        {
            loginPage.NavigateTo();

            loginPage.EmailInput.SendKeys("dessi1@abv.bg");

            loginPage.SubmitButton.Click();

            regPage.RegisterButton.Click();
        }

        [Test]
        public void NegativeScenario_InvalidEmail()
        {
            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../JSONs/InvalidEmail.json");
            var user = RegistrationUser.FromJson(File.ReadAllText(path));

            loginPage.NavigateTo();

            loginPage.EmailInput.Clear();
            loginPage.EmailInput.SendKeys("des4@abv.bg");
            loginPage.SubmitButton.Click();

            regPage.FillForm(user);

            regPage.Email.Click();
            regPage.FirstName.Click();
            StringAssert.Contains("form-error", regPage.EmailParent.GetAttribute("class"));
        }

        [Test]
        public void NegativeScenario_InvalidFirstName()
        {

            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../JSONs/InvalidFirstName.json");
            var user = RegistrationUser.FromJson(File.ReadAllText(path));

            loginPage.NavigateTo();

            loginPage.EmailInput.Clear();
            loginPage.EmailInput.SendKeys("fes1@abv.bg");
            loginPage.SubmitButton.Click();

            regPage.FillForm(user);

            Assert.IsTrue(regPage.ErrorMessage.Displayed);
            StringAssert.Contains("firstname is invalid", regPage.ErrorMessage.Text);
        }

        [Test]
        public void NegativeScenario_InvalidPassword()
        {

            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../JSONs/InvalidPassword.json");
            var user = RegistrationUser.FromJson(File.ReadAllText(path));

            loginPage.NavigateTo();

            loginPage.EmailInput.Clear();
            loginPage.EmailInput.SendKeys("pes1@abv.bg");
            loginPage.SubmitButton.Click();

            regPage.FillForm(user);

            Assert.IsTrue(regPage.ErrorMessage.Displayed);
            StringAssert.Contains("passwd is required", regPage.ErrorMessage.Text);
        }

        [Test]
        public void NegativeScenario_InvalidZip()
        {

            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + "/../../../JSONs/InvalidZip.json");
            var user = RegistrationUser.FromJson(File.ReadAllText(path));

            loginPage.NavigateTo();

            loginPage.EmailInput.Clear();
            loginPage.EmailInput.SendKeys("zes1@abv.bg");
            loginPage.SubmitButton.Click();

            regPage.FillForm(user);

            Assert.IsTrue(regPage.ErrorMessage.Displayed);
            StringAssert.Contains("The Zip/Postal code you've entered is invalid. It must follow this format: 00000", regPage.ErrorMessage.Text);
        }
    }
}