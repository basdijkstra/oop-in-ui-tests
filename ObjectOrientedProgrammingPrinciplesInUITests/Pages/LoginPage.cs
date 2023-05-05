﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ObjectOrientedProgrammingPrinciplesInUITests.Pages
{
    public class LoginPage
    {
        private WebDriver driver;

        private readonly By textfieldUsername = By.Name("username");
        private readonly By textfieldPassword = By.Name("password");
        private readonly By buttonDoLogin = By.XPath("//input[@value='Log In']");

        public LoginPage(WebDriver driver)
        {
            this.driver = driver;

            driver.Navigate().GoToUrl("http://localhost:8080/parabank");
        }

        public void LoginAs(string username, string password)
        {
            SendKeys(textfieldUsername, username);
            SendKeys(textfieldPassword, password);
            Click(buttonDoLogin);
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
    }
}