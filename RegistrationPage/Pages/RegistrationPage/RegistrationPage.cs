using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RegistrationPage.Models;

namespace RegistrationPage.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
            Url = "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
        }

        public void FillForm(RegistrationUser user)
        {
            RadioButton.Click();
            FirstName.SendKeys(user.FirstName);
            LastName.SendKeys(user.LastName);
            Email.Click();
            Password.SendKeys(user.Password);

            SelectElement days = new SelectElement(DaysHelp);
            days.SelectByIndex(user.DateOfBirth.Day);

            SelectElement months = new SelectElement(MonthsHelp);
            months.SelectByIndex(user.DateOfBirth.Month);

            SelectElement years = new SelectElement(YearsHelp);
            years.SelectByValue(user.DateOfBirth.Year.ToString());

            SignUpNewsletter.Click();
            Address.SendKeys("Vitosha 10");
            City.SendKeys("Sofia");

            SelectElement state = new SelectElement(StateHelp);
            state.SelectByText("Colorado");

            Zip.SendKeys("12345");

            SelectElement country = new SelectElement(CountryHelp);
            country.SelectByText("United States");

            MobilePhone.SendKeys("555-555");
            RegisterButton.Click();
        }
    }
}
