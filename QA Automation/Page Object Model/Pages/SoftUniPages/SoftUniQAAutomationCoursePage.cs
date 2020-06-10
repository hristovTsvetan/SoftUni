using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModelTests.Pages.SoftUniPages
{
    public class SoftUniQAAutomationCoursePage : BasePage
    {
        public SoftUniQAAutomationCoursePage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement QACourseHeading => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//header[@class='lead-header image-background']//h1")));
    }
}
