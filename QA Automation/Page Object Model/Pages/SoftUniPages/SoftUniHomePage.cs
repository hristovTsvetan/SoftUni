using OpenQA.Selenium;

namespace PageObjectModelTests.Pages.SoftUniPages
{
    public class SoftUniHomePage : BasePage
    {
        public SoftUniHomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement MenuTrainingButton => Driver.FindElement(By.XPath("//span[text()='Обучения']"));

        public IWebElement MenuQACourseButton => Driver.FindElement(By.LinkText("QA Automation - май 2020"));

        public SoftUniQAAutomationCoursePage NavigateToQaCoursePage()
        {
            MenuTrainingButton.Click();
            MenuQACourseButton.Click();
            return new SoftUniQAAutomationCoursePage(Driver);
        }
    }
}
