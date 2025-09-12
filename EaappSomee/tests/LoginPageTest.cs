namespace EaappSomee.tests
{
    [TestFixture]
    public class LoginPageTest
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;

        [SetUp]
        public void SetUp() 
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
            _homePage = new HomePage(_driver);
            _loginPage = new LoginPage(_driver);
        }

        // Assert messages only show when assertions fail.
        // To always see info in Visual Studio's Test Explorer (Output/Standard Output),
        // write to TestContext.* streams.
        [Test]
        [Category("login")]
        [TestCaseSource(nameof(LoginJson))]
        public void LoginTest(LoginModel login)
        {
            _homePage.ClickLogin();
            _loginPage.Login(login.UserName, login.Password, login.RememberMe);

            var adminState = _loginPage.IsLoggedInAsAdmin();
            var userState = _loginPage.IsLoggedIn();

            if (adminState.employeeDetails && adminState.manageUsers)
            {
                TestContext.Out.WriteLine("User is logged in as: " + login.UserName);
                Assert.That((adminState.employeeDetails && adminState.manageUsers) && (userState.helloUser && userState.logOff), Is.True);
            }
            else if (userState.helloUser && userState.logOff)
            {
                TestContext.Out.WriteLine("User is logged in as: " + login.UserName);
                Assert.That(userState.helloUser && userState.logOff && (!adminState.employeeDetails && !adminState.manageUsers), Is.True);
            }
            else if (!userState.helloUser && !userState.logOff && !adminState.employeeDetails && !adminState.manageUsers)
            {
                TestContext.Out.WriteLine("Login failed. Error message: \n" + _loginPage.HasValidationErrors());
            }
        }

        /// <summary>
        ///  Gets the path to the JSON file, reads the file, and deserializes it into a collection of LoginModel objects.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<TestCaseData> LoginJson()
        {
            var jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "login.json");
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
            _homePage.ClickLogin();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
