using NUnit.Framework;
using PageObjectModelTests.Pages.DemoQAPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModelTests.Tests.Interaction
{
    [TestFixture]
    class SelectableTests : BaseInteractionTest
    {
        private DemoQAHomePage _demoQaHomePage;
        private DemoQAInteractionsPage _demoQaInteractionsPage;
        private DemoQASelectablePage _demoQaSelectablePage;

        [SetUp]
        public void SetUp()
        {
            Initialization();

            _demoQaHomePage = new DemoQAHomePage(Driver);
            _demoQaInteractionsPage = _demoQaHomePage.GoToInteractionPage();
            _demoQaSelectablePage = _demoQaInteractionsPage.GoToSelectablePage();
        }

        [Test]
        public void CheckColorOnFirstElement_When_Selected()
        {
            string colorOnFirstElementBefore = _demoQaSelectablePage.GetBackgroundColorOnFirstElement();

            _demoQaSelectablePage.SelectFirstElement();

            string colorOnFirstElementAfter = _demoQaSelectablePage.GetBackgroundColorOnFirstElement();
            Assert.IsTrue(colorOnFirstElementBefore != colorOnFirstElementAfter);
        }

        [Test]
        public void CheckColorOnFirstAndSecondElement_When_SelectedFirst()
        {
            _demoQaSelectablePage.SelectFirstElement();

            Assert.IsFalse(_demoQaSelectablePage.GetBackgroundColorOnFirstElement() == _demoQaSelectablePage.GetBackgroundColorOnSecondElement());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
