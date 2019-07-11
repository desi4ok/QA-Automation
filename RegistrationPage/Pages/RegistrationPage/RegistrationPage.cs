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
            Email.Clear();
            Email.SendKeys(user.Email);
            Password.SendKeys(user.Password);
            DaysOption.SelectByIndex(user.DateOfBirth.Day);
            MonthsOption.SelectByIndex(user.DateOfBirth.Month);
            YearsOption.SelectByValue(user.DateOfBirth.Year.ToString());
            SignUpNewsletter.Click();
            Address_FirstName.SendKeys(user.Address.FirstName);
            Address_LastName.SendKeys(user.Address.LastName);
            Address_Address1.SendKeys(user.Address.Address1);
            Address_City.SendKeys(user.Address.City);
            StateOption.SelectByText(user.Address.State);
            Address_ZipCode.SendKeys(user.Address.ZipCode.ToString());
            CountryOption.SelectByText(user.Address.Country);
            Address_Info.SendKeys(user.Address.Info);
            Address_MobPhone.SendKeys(user.Address.MobPhone);
            RegisterButton.Click();
        }
    }
}
