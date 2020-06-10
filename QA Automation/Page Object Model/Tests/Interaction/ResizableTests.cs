using NUnit.Framework;
using PageObjectModelTests.Pages.DemoQAPages;

namespace PageObjectModelTests.Tests.Interaction
{
    [TestFixture]
    public class ResizableTests : BaseInteractionTest
    {
        private DemoQAHomePage _demoQaHomePage;
        private DemoQAInteractionsPage _demoQaInteractionsPage;
        private DemoQAResizablePage _demoQaResizebalePage;

        [SetUp]
        public void SetUp()
        {
            Initialization();

            _demoQaHomePage = new DemoQAHomePage(Driver);
            _demoQaInteractionsPage = _demoQaHomePage.GoToInteractionPage();
            _demoQaResizebalePage = _demoQaInteractionsPage.GoToResizablePage();
        }

        [Test]
        public void CheckElementHeight_When_Resize()
        {
            var heightOnElementBefore = _demoQaResizebalePage.GetHeightOnResizableElement();

            _demoQaResizebalePage.ResizeElementVertical();

            Assert.IsFalse(heightOnElementBefore == _demoQaResizebalePage.GetHeightOnResizableElement());
        }

        [Test]
        public void CheckElementWidth_When_Resize()
        {
            var widthOnElementBefore = _demoQaResizebalePage.GetWidthOnResizableElement();

            _demoQaResizebalePage.ResizeElementHorizontal();

            Assert.IsFalse(widthOnElementBefore == _demoQaResizebalePage.GetWidthOnResizableElement());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
