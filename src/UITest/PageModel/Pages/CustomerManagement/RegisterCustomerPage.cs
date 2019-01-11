using OpenQA.Selenium;

namespace Pitstop.UITest.PageModel.Pages.CustomerManagement
{
    /// <summary>
    /// Represents the RegisterCustomer page.
    /// </summary>
    public class RegisterCustomerPage : PitstopPage
    {   
        public RegisterCustomerPage(PitstopApp pitstop) : base("Customer Management - register customer", pitstop)
        {
        }

        public RegisterCustomerPage FillCustomerDetails(string name, string address,
            string city, string postalCode, string telephoneNumber, string emailAddress)
        {
            WebDriver.FindElement(By.Name("Customer.Nombre")).SendKeys(name);
            WebDriver.FindElement(By.Name("Customer.Direccion")).SendKeys(address);
            WebDriver.FindElement(By.Name("Customer.CodigoPostal")).SendKeys(postalCode);
            WebDriver.FindElement(By.Name("Customer.Poblacion")).SendKeys(city);
            WebDriver.FindElement(By.Name("Customer.Telefono")).SendKeys(telephoneNumber);
            WebDriver.FindElement(By.Name("Customer.Email")).SendKeys(emailAddress);
            return this;
        }

        public CustomerManagementPage Submit()
        {
            WebDriver.FindElement(By.Id("SubmitButton")).Click();
            return new CustomerManagementPage(Pitstop);
        }

        public CustomerManagementPage Cancel()
        {
            WebDriver.FindElement(By.Id("CancelButton")).Click();
            return new CustomerManagementPage(Pitstop);
        }
    }
}