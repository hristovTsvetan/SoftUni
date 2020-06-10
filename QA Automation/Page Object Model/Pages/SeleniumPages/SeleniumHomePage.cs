using OpenQA.Selenium;

namespace PageObjectModelTests.Pages.SeleniumPages
{
    public class SeleniumHomePage : BasePage
    {
        public SeleniumHomePage(IWebDriver driver)
            :base(driver)
        {

        }

        public string CurrentUrl => Driver.Url;

        public string Title => Driver.Title;
    }
}
