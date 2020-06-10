using NUnit.Framework;
using PageObjectModelTests.Pages.GooglePages;
using PageObjectModelTests.Pages.SeleniumPages;

namespace PageObjectModelTests.Tests.Google
{
    [TestFixture]
    public class GoogleSearchTests : BaseTest
    {
        private SeleniumHomePage _seleniumHomePage;

        [SetUp]
        public void Setup()
        {
            Initiate();
            Driver.Navigate().GoToUrl("https://Google.bg");

            var googleHomePage = new GoogleHomePage(Driver);
            var resultsAfterSearch = googleHomePage.PerformSearch("Selenium");
            _seleniumHomePage = resultsAfterSearch.ClickOnFirstResult();
        }

        [Test]
        public void FirstUrlAddress_When_SearchForSelenium()
        {
            Assert.AreEqual("https://www.selenium.dev/", _seleniumHomePage.CurrentUrl);   
        }

        [Test]
        public void SeleniumHomePageTitle_When_OpenFromGoogleSearch()
        {
            Assert.AreEqual("Selenium - Web Browser Automation", _seleniumHomePage.Title);
        }

        [TearDown]
        public void TearDown()
        {
           Driver.Quit();
        }
    }
}
