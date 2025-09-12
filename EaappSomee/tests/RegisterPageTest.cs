namespace EaappSomee.tests
{
    [TestFixture]
    public class RegisterPageTest
    {
        private IWebDriver _driver;
        private RegisterPage _registerPage;
        private HomePage _homePage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
            _homePage = new HomePage(_driver);
            _registerPage = new RegisterPage(_driver);
        }

        [Test]
        [Category("register")]
        [TestCaseSource(nameof(RegisterJson))]
        public void RegisterTest(RegisterModel register)
        {
            _homePage.ClickRegister();
            _registerPage.Register(register.UserName, register.Password, register.ConfirmPassword, register.Email);

            var (helloUser, logOff) = _registerPage.isRegisteredAndLoggedIn();

            if (helloUser && logOff)
            {
                TestContext.Out.WriteLine("User registered and logged in as: " + register.UserName);
                Assert.That(helloUser && logOff, Is.True);
            }
            else
            {
                TestContext.Out.WriteLine("Registration failed. Error message: \n" + _registerPage.HasValidationErrors());
                Assert.That(!helloUser && !logOff, Is.True);
            }
        }

        public static IEnumerable<TestCaseData> RegisterJson()
        {
            var jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "register.json");
            var jsonString = File.ReadAllText(jsonFilePath);
            var registerModel = JsonSerializer.Deserialize<List<RegisterModel>>(jsonString);
            foreach (var registerData in registerModel)
            {
                yield return new TestCaseData(registerData).SetName(registerData.TestName);
            }
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}
