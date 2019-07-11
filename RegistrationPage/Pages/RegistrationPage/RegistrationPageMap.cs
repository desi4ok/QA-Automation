namespace RegistrationPage.Pages.RegistrationPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class RegistrationPage
    {
        public IWebElement RadioButton => Wait.Until((d) => { return d.FindElement(By.XPath("//*[@id='id_gender2']")); });

        public IWebElement FirstName => Wait.Until((d) => { return d.FindElement(By.Id("customer_firstname")); });

        public IWebElement LastName => Wait.Until((d) => { return d.FindElement(By.Id("customer_lastname")); });

        public IWebElement Email => Wait.Until((d) => { return d.FindElement(By.Id("email")); });

        public IWebElement Password => Wait.Until((d) => { return d.FindElement(By.Id("passwd")); });

        public IWebElement Days => Wait.Until((d) => { return d.FindElement(By.Id("days")); });
        public SelectElement DaysOption => new SelectElement(this.Days);

        public IWebElement Months => Wait.Until((d) => { return d.FindElement(By.Id("months")); });
        public SelectElement MonthsOption => new SelectElement(this.Months);

        public IWebElement Years => Wait.Until((d) => { return d.FindElement(By.Id("years")); });
        public SelectElement YearsOption => new SelectElement(this.Years);

        public IWebElement SignUpNewsletter => Wait.Until((d) => { return d.FindElement(By.Id("newsletter")); });

        public IWebElement Address_FirstName => Wait.Until((d) => { return d.FindElement(By.Id("firstname")); });

        public IWebElement Address_LastName => Wait.Until((d) => { return d.FindElement(By.Id("lastname")); });

        public IWebElement Address_Address1 => Wait.Until((d) => { return d.FindElement(By.Id("address1")); });

        public IWebElement Address_City => Wait.Until((d) => { return d.FindElement(By.Id("city")); });

        public IWebElement Address_State => Wait.Until((d) => { return d.FindElement(By.Id("id_state")); });
        public SelectElement StateOption => new SelectElement(this.Address_State);

        public IWebElement Address_ZipCode => Wait.Until((d) => { return d.FindElement(By.Id("postcode")); });

        public IWebElement Address_Country => Wait.Until((d) => { return d.FindElement(By.Id("id_country")); });
        public SelectElement CountryOption => new SelectElement(this.Address_Country);

        public IWebElement Address_Info => Wait.Until((d) => { return d.FindElement(By.Id("other")); });

        public IWebElement Address_MobPhone => Wait.Until((d) => { return d.FindElement(By.Id("phone_mobile")); });

        public IWebElement RegisterButton => Wait.Until((d) => { return d.FindElement(By.Id("submitAccount")); });

        public IWebElement ErrorMessage => Wait.Until((d) => { return d.FindElement(By.ClassName("alert alert-danger")); });
        
        public IWebElement EmailParent => Wait.Until((d) => { return d.FindElement(By.XPath("//*[@id='account-creation_form']/div[1]/div[4]")); });

       
    }
}
