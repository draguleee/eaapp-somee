public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly HomePage _homePage;
    private readonly RegisterPage _registerPage;

    public LoginPage(IWebDriver driver) 
    { 
        _driver = driver;
        _homePage = new HomePage(driver);
        _registerPage = new RegisterPage(driver);
    }

    public void Login(string username, string password, bool isSelected)
    {
        UserName.SendKeys(username);
        Password.SendKeys(password);
        if(RememberMe.Selected != isSelected) RememberMe.ClickElement();
        LoginButton.ClickElement();
    }

    public (bool employeeDetails, bool manageUsers) IsLoggedInAsAdmin()
    {
        return (CustomMethods.Exists(() => EmployeeDetails), CustomMethods.Exists(() => ManageUsers));
    }

    public (bool helloUser, bool logOff) IsLoggedIn()
    {
        return (CustomMethods.Exists(() => HelloUser), CustomMethods.Exists(() => LogoffButton));
    }

    public void RegisterFromLogin()
    {
        RegisterLink.ClickElement();            
    }

    public string HasValidationErrors()
    {
        if (UsernameError.Text != "") return UsernameError.Text;
        else if (PasswordError.Text != "") return PasswordError.Text;
        else if (UsernameError.Text != "" && PasswordError.Text != "") return UsernameError.Text + " " + PasswordError.Text;
        else return InvalidLogin.Text;
    }

    IWebElement UserName => _driver.FindElement(By.Id("UserName"));
    IWebElement Password => _driver.FindElement(By.Id("Password"));
    IWebElement RememberMe => _driver.FindElement(By.Name("RememberMe"));
    IWebElement LoginButton => _driver.FindElement(By.Id("loginIn"));
    IWebElement RegisterLink => _driver.FindElement(By.XPath("//a[contains(text(),'Register')]"));
    IWebElement EmployeeDetails => _driver.FindElement(By.LinkText("Employee Details"));
    IWebElement ManageUsers => _driver.FindElement(By.LinkText("Manage Users"));
    IWebElement HelloUser => _driver.FindElement(By.XPath("//a[contains(text(), 'Hello')]"));
    IWebElement LogoffButton => _driver.FindElement(By.LinkText("Log off"));
    IWebElement UsernameError => _driver.FindElement(By.XPath("//span[@data-valmsg-for='UserName']"));
    IWebElement PasswordError => _driver.FindElement(By.XPath("//span[@data-valmsg-for='Password']"));
    IWebElement InvalidLogin => _driver.FindElement(By.CssSelector(".validation-summary-errors > ul > li"));
    
}