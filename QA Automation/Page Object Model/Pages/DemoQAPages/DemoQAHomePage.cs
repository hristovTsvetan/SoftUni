using OpenQA.Selenium;

namespace PageObjectModelTests.Pages.DemoQAPages
{
    public class DemoQAHomePage : BasePage
    {
        public DemoQAHomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement MenuInteractionButton => Driver.FindElement(By.XPath("//h5[normalize-space(text())='Interactions']//ancestor::div[@class='card mt-4 top-card']"));

        public DemoQAInteractionsPage GoToInteractionPage()
        {
            MenuInteractionButton.Click();

            return new DemoQAInteractionsPage(Driver);
        }

    }
}
