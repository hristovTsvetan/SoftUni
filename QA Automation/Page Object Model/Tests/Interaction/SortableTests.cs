using NUnit.Framework;
using PageObjectModelTests.Pages.DemoQAPages;

namespace PageObjectModelTests.Tests.Interaction
{
    [TestFixture]
    public class SortableTests : BaseInteractionTest
    {
        private DemoQAHomePage _demoQaHomePage;
        private DemoQAInteractionsPage _demoQaInteractionsPage;
        private DemoQASortablePage _demoQaSortablePage;

        [SetUp]
        public void SetUp()
        {
            Initialization();

            _demoQaHomePage = new DemoQAHomePage(Driver);
            _demoQaInteractionsPage = _demoQaHomePage.GoToInteractionPage();
            _demoQaSortablePage = _demoQaInteractionsPage.GoToSortablePage();
            _demoQaSortablePage.MoveFirstElementUnderSecondElement();
        }

        [Test]
        public void CheckNameOnFirstElement_When_Sorting()
        {
            Assert.AreEqual("Two", _demoQaSortablePage.GetTextOnFirstElement());
        }

        [Test]
        public void CheckNameOnMovedElement_When_Sorting()
        {
            Assert.AreEqual("One", _demoQaSortablePage.GetTextOnSecondElement());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
