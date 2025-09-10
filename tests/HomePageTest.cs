using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using pages;

namespace tests
{
    public class HomePageTest
    {
        private IWebDriver driver;
        private Actions actions;
        HomePage homePage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
            actions = new Actions(driver);
            homePage = new HomePage(driver);
        }

        [Test]
        public void ClickLinksLoggedOut()
        {
            homePage.ClickHome();
            homePage.ClickAbout();
            homePage.ClickEmployeeList();
            homePage.ClickRegister();
            homePage.ClickLogin();
            
        }

        [Test]
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
            driver.Dispose();
        }
    }
}