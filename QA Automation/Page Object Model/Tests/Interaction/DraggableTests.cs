using NUnit.Framework;
using PageObjectModelTests.Pages.DemoQAPages;

namespace PageObjectModelTests.Tests.Interaction
{
    public class DraggableTests : BaseInteractionTest
    {
        private DemoQAHomePage _demoQaHomePage;
        private DemoQAInteractionsPage _demoQaInteractionsPage;
        private DemoQADraggablePage _demoQaDraggablePage;

        [SetUp]
        public void SetUp()
        {
            Initialization();

            _demoQaHomePage = new DemoQAHomePage(Driver);
            _demoQaInteractionsPage = _demoQaHomePage.GoToInteractionPage();
            _demoQaDraggablePage = _demoQaInteractionsPage.GoToDraggablePage();
        }

        [Test]
        public void CheckSourceElementVerticalPosition_When_DraggingHorizontal()
        {
            var draggableElementVerticalPositionBefore = _demoQaDraggablePage.GetDraggableElementVerticalPosition();

            _demoQaDraggablePage.MoveElementHorizontal();

            Assert.IsFalse(draggableElementVerticalPositionBefore == _demoQaDraggablePage.GetDraggableElementVerticalPosition());
        }

        [Test]
        public void CheckSourceElementHorizontalPosition_When_DraggingVertical()
        {
            var draggableElementHorizontalPositionBefore = _demoQaDraggablePage.GetDraggableElementHorizontalPosition();

            _demoQaDraggablePage.MoveElementVertical();

            Assert.IsFalse(draggableElementHorizontalPositionBefore == _demoQaDraggablePage.GetDraggableElementHorizontalPosition());
        }

        [Test]
        public void CheckSourceElementVerticalAndHorizontalPosition_When_DraggingDiagonal()
        {
            var draggableElementVerticalPositionBefore = _demoQaDraggablePage.GetDraggableElementVerticalPosition();
            var draggableElementHorizontalPositionBefore = _demoQaDraggablePage.GetDraggableElementHorizontalPosition();

            _demoQaDraggablePage.MoveElementDiagonal();

            Assert.IsTrue(draggableElementVerticalPositionBefore != _demoQaDraggablePage.GetDraggableElementVerticalPosition() &&
                draggableElementHorizontalPositionBefore != _demoQaDraggablePage.GetDraggableElementHorizontalPosition());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
