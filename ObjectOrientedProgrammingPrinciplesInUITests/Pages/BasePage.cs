using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ObjectOrientedProgrammingPrinciplesInUITests.Pages
{
    public class BasePage
    {
        private WebDriver driver;

        public BasePage(WebDriver driver)
        {
            this.driver = driver;
        }

        protected void SendKeys(By locator, string textToType)
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

        protected void Click(By locator)
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

        protected void Select(By locator, string valueToSelect)
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

        protected string GetElementText(By locator)
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

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public virtual void SelectMenuItem(string menuItem)
        {
            Click(By.LinkText(menuItem));
        }
    }
}
