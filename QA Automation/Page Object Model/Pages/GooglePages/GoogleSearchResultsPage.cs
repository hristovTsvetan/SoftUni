using OpenQA.Selenium;
using PageObjectModelTests.Pages.SeleniumPages;
using System.Collections.Generic;
using System.Linq;

namespace PageObjectModelTests.Pages.GooglePages
{
    public class GoogleSearchResultsPage : BasePage
    {
        public GoogleSearchResultsPage(IWebDriver driver)
            :base(driver)
        {

        }

        public List<IWebElement> Results => Driver.FindElements(By.XPath("//div[@id='search']//h3")).ToList();

        public SeleniumHomePage ClickOnFirstResult()
        {
            Results[0].Click();
            return new SeleniumHomePage(Driver);
        }

    }
}
