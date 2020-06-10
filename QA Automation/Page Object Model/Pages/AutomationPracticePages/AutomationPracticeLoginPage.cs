using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModelTests.Pages.AutomationPracticePages
{
    public class AutomationPracticeLoginPage :BasePage
    {
        public AutomationPracticeLoginPage(IWebDriver driver)
            :base(driver)
        {

        }

        public IWebElement EmailTextBox => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='email_create']")));

        public IWebElement CreateAccountButton => Driver.FindElement(By.XPath("//button[@id='SubmitCreate']"));

        public AutomationPracticeRegFormPage NavigateToRegistrationForm(string mail)
        {
            EmailTextBox.SendKeys(mail);
            CreateAccountButton.Click();

            return new AutomationPracticeRegFormPage(Driver);
        }
    }
}
