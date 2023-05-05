using NUnit.Framework;
using ObjectOrientedProgrammingPrinciplesInUITests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ObjectOrientedProgrammingPrinciplesInUITests
{
    public class RequestLoanTests
    {
        private WebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void RequestLoan_InsufficientFunds_ShouldBeDenied()
        {
            new LoginPage(driver)
                .LoginAs("john", "demo");

            new AccountsOverviewPage(driver)
                .SelectMenuItem("Request Loan");

            RequestLoanPage rlp = new RequestLoanPage(driver);

            rlp.SubmitLoanApplication("10000", "1000", "12345");

            Assert.That(rlp.GetLoanApplicationResult(), Is.EqualTo("Denied"));            
        }

        [TearDown]
        public void StopBrowser()
        {
            driver.Quit();
        }
    }
}
