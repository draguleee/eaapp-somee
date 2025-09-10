using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using pages;

namespace tests
{
    [TestFixture]
    public class LoginPageTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;

        [SetUp]
        public void SetUp() 
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
            homePage = new HomePage(driver);
            loginPage = new LoginPage(driver);
        }

        [TestCase("admin", "password", false, TestName = "LoginSuccessNotRemembered")]
        [TestCase("admin", "password", true, TestName = "LoginSuccessRemembered")]
        [TestCase("admin", "wrongpassword", false, TestName = "LoginIncorrectPassword")]
        [TestCase("wronguser", "password", false, TestName = "LoginIncorrectUsername")]
        [TestCase("wronguser", "wrongpassword", false, TestName = "LoginIncorrectCredentials")]
        [TestCase("", "password", false, TestName = "LoginEmptyUsername")]
        [TestCase("admin", "", false, TestName = "LoginEmptyPassword")]
        [TestCase("", "", false, TestName = "LoginEmptyCredentials")]
        public void LoginTest(string username, string password, bool rememberMe)
        {
            homePage.ClickLogin();
            loginPage.Login(username, password, rememberMe);
        }

        [Test]
        public void RegisterFromLoginTest()
        {
            homePage.ClickLogin();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
