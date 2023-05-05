using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ObjectOrientedProgrammingPrinciplesInUITests.Pages
{
    public class AccountsOverviewPage
    {
        private WebDriver driver;

        private By linkToRequestLoanPage = By.LinkText("Request Loan");

        public AccountsOverviewPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToRequestLoanPage()
        {
            Click(linkToRequestLoanPage);
        }

        private void Click(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = driver.FindElement(locator);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in Click(): element located by {locator} not visible and enabled within 10 seconds.");
            }
        }
    }
}
