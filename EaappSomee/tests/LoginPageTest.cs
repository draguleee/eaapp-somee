namespace EaappSomee.tests
{
    [TestFixture]
    public class LoginPageTest
    {
        private IWebDriver _driver;
        private LoginPage loginPage;
        private HomePage homePage;

        [SetUp]
        public void SetUp() 
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
            homePage = new HomePage(_driver);
            loginPage = new LoginPage(_driver);
        }

        [Test]
        [Category("login")]
        [TestCaseSource(nameof(LoginJson))]
        public void LoginTest(LoginModel login)
        {
            homePage.ClickLogin();
            loginPage.Login(login.UserName, login.Password, login.RememberMe);
            var isLoggedIn = loginPage.IsLoggedIn();
            Assert.That(isLoggedIn.employeeDetails && isLoggedIn.manageUsers);
            // isLoggedIn.employeeDetails.Should().BeTrue();        // Using FluentAssertions
            // isLoggedIn.manageUsers.Should().BeTrue();            // Using FluentAssertions
        }

        /// <summary>
        ///  Gets the path to the JSON file, reads the file, and deserializes it into a collection of LoginModel objects.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TestCaseData> LoginJson()
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "login.json");
            var jsonString = File.ReadAllText(jsonFilePath);
            var loginModel = JsonSerializer.Deserialize<List<LoginModel>>(jsonString);
            foreach (var loginData in loginModel)
            {
                yield return new TestCaseData(loginData).SetName(loginData.TestName);
            }
        }

        [Test]
        [Category("login")]
        public void RegisterFromLoginTest()
        {
            homePage.ClickLogin();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
