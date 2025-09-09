using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace tests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void ClickLinks()
        {
            CustomMethods.Click(driver, By.XPath("//a[text()='Home']"));
            CustomMethods.Click(driver, By.XPath("//a[text()='About']"));
            driver.Navigate().Back();
            CustomMethods.Click(driver, By.XPath("//a[contains(text(), 'Employee')]"));
            driver.Navigate().Back();
            CustomMethods.Click(driver, By.XPath("//a[text()='Register']"));
            driver.Navigate().Back();
            CustomMethods.Click(driver, By.XPath("//a[text()='Login']"));
            driver.Navigate().Back();
        }

        [Test]
        public void Login()
        {
            CustomMethods.Click(driver, By.Id("loginLink"));
            CustomMethods.SendKeys(driver, By.Name("UserName"), "admin");
            CustomMethods.SendKeys(driver, By.Name("Password"), "password");
            CustomMethods.Click(driver, By.Id("RememberMe"));
            CustomMethods.Submit(driver, By.Id("loginIn"));            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}