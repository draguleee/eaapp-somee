namespace EaappSomee.pages
{
    public class HomePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickHome() => HomeLink.ClickElement();

        public void ClickAbout() => AboutLink.ClickElement();

        public void ClickEmployeeList() => EmployeeListLink.ClickElement();

        public void ClickRegister() => RegisterLink.ClickElement();

        public void ClickLogin() => LoginLink.ClickElement();

        public void ClickEmployeeDetails() => EmployeeDetailsLink.ClickElement();

        public void ClickManageUsers() => ManageUsersLink.ClickElement();

        public void ClickHello() => HelloLink.ClickElement();

        public void ClickLogoff() => LogoffLink.ClickElement();

        public void ClickVisitNow()
        {
            VisitNow.ClickElement();
            driver.Navigate().Back();
        }

        public void ClickLearnMore()
        {
            LearnMore.ClickElement();
            driver.Navigate().Back();
        }

        public void ClickUdemy()
        {
            Udemy.ClickElement();
            driver.Navigate().Back();
        }

        public void ClickYouTube()
        {
            YouTube.ClickElement();
            driver.Navigate().Back();
        }

        public void ClickSourceCode()
        {
            SourceCode.ClickElement();
            driver.Navigate().Back();
        }

        // Elements from the Home Page (not logged in)
        IWebElement HomeLink => driver.FindElement(By.XPath("//a[text()='Home']"));
        IWebElement AboutLink => driver.FindElement(By.XPath("//a[text()='About']"));
        IWebElement EmployeeListLink => driver.FindElement(By.XPath("//a[contains(text(), 'List')]"));
        IWebElement RegisterLink => driver.FindElement(By.Id("registerLink"));
        IWebElement LoginLink => driver.FindElement(By.Id("loginLink"));

        // Elements from the Home Page (admin logged in)
        IWebElement EmployeeDetailsLink => driver.FindElement(By.XPath("//a[contains(text(), 'Details')]"));
        IWebElement ManageUsersLink => driver.FindElement(By.XPath("//a[contains(text(), 'Manage')]"));

        // Elements from the Home Page (user logged in, regardless of role)
        IWebElement HelloLink => driver.FindElement(By.XPath("//a[contains(text(), 'Hello')]"));    
        IWebElement LogoffLink => driver.FindElement(By.XPath("//a[text()='Log off')]"));

        // Elements from the Home Page (buttons)
        IWebElement VisitNow => driver.FindElement(By.XPath("//a[contains(text(), 'Visit')]"));
        IWebElement LearnMore => driver.FindElement(By.XPath("//a[contains(text(), 'Learn')]"));
        IWebElement Udemy => driver.FindElement(By.XPath("//a[text()='Udemy']"));
        IWebElement YouTube => driver.FindElement(By.XPath("//a[text()='YouTube']"));
        IWebElement SourceCode => driver.FindElement(By.XPath("//a[contains(text()='Source code')]"));

    }
}
