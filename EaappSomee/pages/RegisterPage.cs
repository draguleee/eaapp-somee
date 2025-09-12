namespace EaappSomee.pages
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

        public RegisterPage(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(driver);
        }

        public void Register(string username, string password, string confirmPassword, string email)
        {
            UserName.SendKeys(username);
            Password.SendKeys(password);
            ConfirmPassword.SendKeys(confirmPassword);
            Email.SendKeys(email);
            RegisterButton.Click();
        }

        public (bool helloUser, bool logOff) isRegisteredAndLoggedIn()
        {
            return (CustomMethods.Exists(() => HelloUser), CustomMethods.Exists(() => LogOff));
        }

        public string HasValidationErrors()
        {
            return ValidationErrors.Text;
        }

        IWebElement UserName => _driver.FindElement(By.Id("UserName"));  
        IWebElement Password => _driver.FindElement(By.Id("Password"));
        IWebElement ConfirmPassword => _driver.FindElement(By.Id("ConfirmPassword"));
        IWebElement Email => _driver.FindElement(By.Id("Email"));
        IWebElement RegisterButton => _driver.FindElement(By.XPath("//input[@value='Register']"));
        IWebElement HelloUser => _driver.FindElement(By.XPath("//a[contains(text(), 'Hello')]"));
        IWebElement LogOff => _driver.FindElement(By.LinkText("Log off"));

        IWebElement ValidationErrors => _driver.FindElement(By.CssSelector(".validation-summary-errors"));
    }
}
