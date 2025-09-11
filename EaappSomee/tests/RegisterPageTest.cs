namespace EaappSomee.tests
{
    [TestFixture]
    public class RegisterPageTest
    {
        private IWebDriver _driver;
        private RegisterPage registerPage;
        private HomePage homePage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
            homePage = new HomePage(_driver);
            registerPage = new RegisterPage(_driver);
        }

        [Test]
        [Category("register")]
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
            _driver.Dispose();
        }
    }
}
