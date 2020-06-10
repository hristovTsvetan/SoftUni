using OpenQA.Selenium;

namespace PageObjectModelTests.Pages.AutomationPracticePages
{
    public class AutomationPracticeHomePage : BasePage
    {
        public AutomationPracticeHomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement SignInButton => Driver.FindElement(By.XPath("//a[@class='login']"));

        public AutomationPracticeLoginPage NavigateToLoginPage()
        {
            SignInButton.Click();

            return new AutomationPracticeLoginPage(Driver);
        }
    }
}
