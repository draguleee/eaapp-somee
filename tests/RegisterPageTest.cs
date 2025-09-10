using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    public class RegisterPageTest
    {
        private IWebDriver driver;
        private RegisterPage registerPage;
        private HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
            registerPage = new RegisterPage(driver);
        }

        [TestCase("newuser1", "newpassword123!", "newpassword123!", "newuser1@gmail.com", TestName = "RegisterSuccessful")]
        [TestCase("newuser2", "password123!", "password321!", "newuser2@gmail.com", TestName = "RegisterPasswordMismatch")]
        [TestCase("draguleee", "password123!", "password321!", "andredragu1699@gmail.com", TestName = "RegisterPasswordMismatch")]
        [TestCase("newuser3", "password123!", "password123!", "invalidemail", TestName = "RegisterInvalidEmail")]
        [TestCase("", "password123!", "password123!", "user@gmail.com", TestName = "RegisterEmptyUsername")]
        [TestCase("newuser4", "", "", "newuser4@gmail.com", TestName = "RegisterEmptyPassword")]
        [TestCase("newuser5", "short", "short", "newuser5@gmail.com", TestName = "RegisterPasswordTooShort")]
        [TestCase("newuser6", "password123!", "password123!", "", TestName = "RegisterEmptyEmail")]
        [TestCase("", "", "", "", TestName = "RegisterAllFieldsEmpty")]
        public void RegisterTest(string username, string password, string confirmPassword, string email)
        {
            homePage.ClickRegister();
            registerPage.Register(username, password, confirmPassword, email);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
