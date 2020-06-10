using NUnit.Framework;
using PageObjectModelTests.Pages.SoftUniPages;

namespace PageObjectModelTests.Tests.SoftUni
{
    [TestFixture]
    public class SoftUniQaAutomationTest : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Initiate();
            Driver.Navigate().GoToUrl("https://softuni.bg/");
        }

        [Test]
        public void QACourseHeaderText_When_CoursePageLoaded()
        {
            var softuniHomePage = new SoftUniHomePage(Driver);
            var softUniQaCoursePage = softuniHomePage.NavigateToQaCoursePage();

            Assert.AreEqual(softUniQaCoursePage.QACourseHeading.Text, "QA Automation - май 2020");
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }

    }
}
