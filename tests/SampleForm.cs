using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tests
{
    [TestFixture]
    class SampleForm
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("file:///C:/Users/ADragu/source/repos/udemy/Selenium%20with%20C%23/eaapp-somee/tests/index.html");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Form()
        {
            CustomMethods.SendKeys(driver, By.Id("textbox"), "Andre");

            CustomMethods.SelectDropdown(driver, By.Name("dropdown"), "Blue", "value");
            CustomMethods.MultiSelect(driver, By.Name("multiselect"), ["Gaming", "Sports"], "value");

            var getSelectedOptions = CustomMethods.GetSelectedOptions(driver, By.Name("multiselect"));
            getSelectedOptions.ForEach(Console.WriteLine);

            var skills = driver.FindElements(By.Name("skills"));
            for (int i = 0; i < skills.Count; i++)
            {
                skills[i].Click();      
            }

            CustomMethods.Click(driver, By.XPath("//input[@value='Female']")); 

            CustomMethods.Submit(driver, By.XPath("//button[@type='submit']"));
        }

        [TearDown]
        public void TearDown()
        {
            // driver.Dispose();
        }   
    }
}
