using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

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
            // Go to ParaBank home page
            driver.Navigate().GoToUrl("http://localhost:8080/parabank");

            // Log in as John
            SendKeys(By.Name("username"), "john");
            SendKeys(By.Name("password"), "demo");
            Click(By.XPath("//input[@value='Log In']"));

            // Go to Request Loan page
            Click(By.LinkText("Request Loan"));

            // Fill in loan application form
            SendKeys(By.Id("amount"), "10000");
            SendKeys(By.Id("downPayment"), "1000");
            Select(By.Id("fromAccountId"), "12345");
            Click(By.XPath("//input[@value='Apply Now']"));

            // Check that loan application is denied
            Assert.That(GetElementText(By.Id("loanStatus")), Is.EqualTo("Denied"));            
        }

        [TearDown]
        public void StopBrowser()
        {
            driver.Quit();
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
