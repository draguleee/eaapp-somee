using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pages
{
    public class RegisterPage
    {
        private readonly IWebDriver driver;
        private readonly HomePage homePage;

        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            homePage = new HomePage(driver);
        }

        public void Register(string username, string password, string confirmPassword, string email)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            ConfirmPassword.SendKeys(confirmPassword);
            Email.SendKeys(email);
            RegisterButton.Click();
            Thread.Sleep(2000);
        }

        IWebElement UserName => driver.FindElement(By.Id("UserName"));  
        IWebElement Password => driver.FindElement(By.Id("Password"));
        IWebElement ConfirmPassword => driver.FindElement(By.Id("ConfirmPassword"));
        IWebElement Email => driver.FindElement(By.Id("Email"));
        IWebElement RegisterButton => driver.FindElement(By.XPath("//input[@value='Register']"));
    }
}
