using OpenQA.Selenium;

namespace ObjectOrientedProgrammingPrinciplesInUITests.Pages
{
    public class RequestLoanPage : BasePage
    {
        private readonly By textfieldLoanAmount = By.Id("amount");
        private readonly By textfieldDownPayment = By.Id("downPayment");
        private readonly By dropdownFromAccountId = By.Id("fromAccountId");
        private readonly By buttonSubmitApplication = By.XPath("//input[@value='Apply Now']");

        private readonly By textlabelApplicationResult = By.Id("loanStatus");

        public RequestLoanPage(WebDriver driver) : base(driver)
        {
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
    }
}
