using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tests;

namespace pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        private readonly HomePage homePage;
        private readonly RegisterPage registerPage;

        public LoginPage(IWebDriver driver) 
        { 
            this.driver = driver;
            homePage = new HomePage(driver);
            registerPage = new RegisterPage(driver);
        }

        public void Login(string username, string password, bool isSelected)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            if(RememberMe.Selected != isSelected) RememberMe.ClickElement();
            LoginButton.ClickElement();
            Thread.Sleep(2000);
        }

        public void RegisterFromLogin()
        {
            RegisterLink.ClickElement();            
        }

        IWebElement UserName => driver.FindElement(By.Id("UserName"));
        IWebElement Password => driver.FindElement(By.Id("Password"));
        IWebElement RememberMe => driver.FindElement(By.Name("RememberMe"));
        IWebElement LoginButton => driver.FindElement(By.Id("loginIn"));
        IWebElement RegisterLink => driver.FindElement(By.XPath("//a[contains(text(),'Register')]"));   
    }
}
