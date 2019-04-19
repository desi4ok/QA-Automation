namespace RegistrationPage.Pages.RegistrationPage
{
    using OpenQA.Selenium;

    public partial class RegistrationPage
    {
        public IWebElement RadioButton => Wait.Until((d) => { return d.FindElement(By.Id("id_gender2")); });

        public IWebElement FirstName => Wait.Until((d) => { return d.FindElement(By.Id("customer_firstname")); });

        public IWebElement LastName => Wait.Until((d) => { return d.FindElement(By.Id("customer_lastname")); });

        public IWebElement Email => Wait.Until((d) => { return d.FindElement(By.Id("email")); });

        public IWebElement Password => Wait.Until((d) => { return d.FindElement(By.Id("passwd")); });

        public IWebElement DaysHelp => Wait.Until((d) => { return d.FindElement(By.Id("days")); });

        public IWebElement MonthsHelp => Wait.Until((d) => { return d.FindElement(By.Id("months")); });

        public IWebElement YearsHelp => Wait.Until((d) => { return d.FindElement(By.Id("years")); });

        public IWebElement SignUpNewsletter => Wait.Until((d) => { return d.FindElement(By.Id("newsletter")); });

        public IWebElement Address => Wait.Until((d) => { return d.FindElement(By.Id("address1")); });

        public IWebElement City => Wait.Until((d) => { return d.FindElement(By.Id("city")); });

        public IWebElement StateHelp => Wait.Until((d) => { return d.FindElement(By.Id("id_state")); });

        public IWebElement Zip => Wait.Until((d) => { return d.FindElement(By.Id("postcode")); });

        public IWebElement CountryHelp => Wait.Until((d) => { return d.FindElement(By.Id("id_country")); });

        public IWebElement MobilePhone => Wait.Until((d) => { return d.FindElement(By.Id("phone_mobile")); });

        public IWebElement RegisterButton => Wait.Until((d) => { return d.FindElement(By.Id("submitAccount")); });
    }
}
