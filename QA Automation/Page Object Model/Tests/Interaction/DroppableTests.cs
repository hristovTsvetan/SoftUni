using NUnit.Framework;
using PageObjectModelTests.Pages.DemoQAPages;

namespace PageObjectModelTests.Tests.Interaction
{
    [TestFixture]
    public class DroppableTests : BaseInteractionTest
    {
        private DemoQAHomePage _demoQaHomePage;
        private DemoQAInteractionsPage _demoQaInteractionsPage;
        private DemoQADroppablePage _demoQaDroppablePage;

        [SetUp]
        public void SetUp()
        {
            Initialization();

            _demoQaHomePage = new DemoQAHomePage(Driver);
            _demoQaInteractionsPage = _demoQaHomePage.GoToInteractionPage();
            _demoQaDroppablePage = _demoQaInteractionsPage.GoToDroppablePage();
        }

        [Test]
        public void CheckColorOnTargetElement_When_DragAndDrop()
        {
            var backgroundColorTargetElementBefore = _demoQaDroppablePage.GetBackgroundColorOnTargetElement();

            _demoQaDroppablePage.DragAndDropElement();

            Assert.IsFalse(backgroundColorTargetElementBefore == _demoQaDroppablePage.GetBackgroundColorOnTargetElement());
        }

        [Test]
        public void CheckTextInTargetElement_When_DragAndDrop()
        {
            _demoQaDroppablePage.DragAndDropElement();

            Assert.AreEqual("Dropped!", _demoQaDroppablePage.GetTextInTargetElement());
        }

        [Test]
        public void CheckTextInSourceElement_When_DragAndDrop()
        {
            _demoQaDroppablePage.DragAndDropElement();

            Assert.AreEqual("Drag me", _demoQaDroppablePage.GetTextInSourceElement());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
