using OpenQA.Selenium;

namespace ObjectOrientedProgrammingPrinciplesInUITests.Pages
{
    public class LoginPage : BasePage, IPage
    {
        private readonly By textfieldUsername = By.Name("username");
        private readonly By textfieldPassword = By.Name("password");
        private readonly By buttonDoLogin = By.XPath("//input[@value='Log In']");

        public LoginPage(WebDriver driver) : base(driver)
        {
            driver.Navigate().GoToUrl("http://localhost:8080/parabank");
        }

        public void LoginAs(string username, string password)
        {
            SendKeys(textfieldUsername, username);
            SendKeys(textfieldPassword, password);
            Click(buttonDoLogin);
        }

        public override void SelectMenuItem(string menuItem)
        {
            throw new NotImplementedException();
        }

        public bool IsOpened()
        {
            return this.GetPageTitle().Equals("ParaBank | Welcome | Online Banking");
        }
    }
}
