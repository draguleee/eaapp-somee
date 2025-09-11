namespace EaappSomee.tests
{
    [TestFixture]   
    public class HomePageTest
    {
        private IWebDriver _driver;
        HomePage homePage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            _driver.Manage().Window.Maximize();
            homePage = new HomePage(_driver);
        }

        [Test]
        [Category("home")]
        public void ClickLinksLoggedOut()
        {
            homePage.ClickHome();
            homePage.ClickAbout();
            homePage.ClickEmployeeList();
            homePage.ClickRegister();
            homePage.ClickLogin();
            
        }

        [Test]
        [Category("home")]
        public void ClickHomeButtons()
        {
            homePage.ClickVisitNow();
            homePage.ClickLearnMore();
            homePage.ClickUdemy();  
            homePage.ClickYouTube();
            homePage.ClickSourceCode();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }
    }
}