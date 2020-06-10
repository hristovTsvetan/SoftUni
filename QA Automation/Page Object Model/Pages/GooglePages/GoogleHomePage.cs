using OpenQA.Selenium;

namespace PageObjectModelTests.Pages.GooglePages
{
    public class GoogleHomePage : BasePage
    {
        public GoogleHomePage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement SearchField => Driver.FindElement(By.XPath("//input[@name='q']"));

        public GoogleSearchResultsPage PerformSearch(string searchFor)
        {
            SearchField.SendKeys("Selenium");
            SearchField.SendKeys(Keys.Return);

            return new GoogleSearchResultsPage(Driver);
        }

    }
}
