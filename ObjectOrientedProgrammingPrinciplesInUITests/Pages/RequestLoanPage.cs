using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ObjectOrientedProgrammingPrinciplesInUITests.Pages
{
    public class RequestLoanPage
    {
        private WebDriver driver;

        private readonly By textfieldLoanAmount = By.Id("amount");
        private readonly By textfieldDownPayment = By.Id("downPayment");
        private readonly By dropdownFromAccountId = By.Id("fromAccountId");
        private readonly By buttonSubmitApplication = By.XPath("//input[@value='Apply Now']");

        private readonly By textlabelApplicationResult = By.Id("loanStatus");

        public RequestLoanPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public void SubmitLoanApplication(string amount, string downPayment, string fromAccountId)
        {
            SendKeys(textfieldLoanAmount, amount);
            SendKeys(textfieldDownPayment, downPayment);
            Select(dropdownFromAccountId, fromAccountId);
            Click(buttonSubmitApplication);
        }

        public string GetLoanApplicationResult()
        {
            return GetElementText(textlabelApplicationResult);
        }

        private void SendKeys(By locator, string textToType)
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
                myElement.Clear();
                myElement.SendKeys(textToType);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in SendKeys(): element located by {locator} not visible and enabled within 10 seconds.");
            }
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

        private void Select(By locator, string valueToSelect)
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
                SelectElement dropdown = new SelectElement(myElement);
                dropdown.SelectByText(valueToSelect);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in Select(): element located by {locator} not visible and enabled within 10 seconds.");
            }
        }

        private string GetElementText(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = driver.FindElement(locator);
                    return tempElement.Displayed ? tempElement : null;
                }
                );
                return myElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in GetElementText(): element located by {locator} not visible and enabled within 10 seconds.");
            }

            return string.Empty;
        }

    }
}
