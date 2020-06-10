using NUnit.Framework;
using PageObjectModelTests.Factories;
using PageObjectModelTests.Models;
using PageObjectModelTests.Pages.AutomationPracticePages;

namespace PageObjectModelTests.Tests.AutomationPractice
{
    [TestFixture]
    public class AutomationPracticeTests : BaseTest
    {
        private AutomationPracticeHomePage _automationPracticeHomePage;
        private AutomationPracticeLoginPage _automationPracticeLoginPage;
        private string _regMail;
        private AutomationPracticeRegFormPage _automationPracticeRegFormPage;
        private AutomationPracticeUserRegModel _user;

        [SetUp]
        public void SetUp()
        {
            Initiate();
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            _automationPracticeHomePage = new AutomationPracticeHomePage(Driver);
            _automationPracticeLoginPage = _automationPracticeHomePage.NavigateToLoginPage();
            _regMail = "dev123@abv.bg";
            _automationPracticeRegFormPage = _automationPracticeLoginPage.NavigateToRegistrationForm(_regMail);
            _user = AutomationPracticeUserRegFactory.Create();
        }

        [Test]
        public void ValidateEmailInRegistrationForm_When_GoToRegister()
        {
            var regMailValue = _automationPracticeRegFormPage.ValidateMailInRegForm(_regMail);

            Assert.AreEqual(_regMail, regMailValue);   
        }

        [Test]
        public void InvalidZipCode_When_RegisterUser()
        {
            _user.ZipCode = "432";

            _automationPracticeRegFormPage.FillRegForm(_user);

            Assert.AreEqual("The Zip/Postal code you've entered is invalid. It must follow this format: 00000",
                _automationPracticeRegFormPage.GetErrorMessage());
        }

        [Test]
        public void EmptyFirstName_When_RegisterUser()
        {
            _user.FirstName = string.Empty;

            _automationPracticeRegFormPage.FillRegForm(_user);

            Assert.AreEqual("firstname is required.", _automationPracticeRegFormPage.GetErrorMessage());
        }

        [Test]
        public void EmptyLastName_When_RegisterUser()
        {
            _user.LastName = string.Empty;

            _automationPracticeRegFormPage.FillRegForm(_user);

            Assert.AreEqual("lastname is required.", _automationPracticeRegFormPage.GetErrorMessage());
        }

        [Test]
        public void EmptyAddress_When_RegisterUser()
        {
            _user.Address = string.Empty;

            _automationPracticeRegFormPage.FillRegForm(_user);

            Assert.AreEqual("address1 is required.", _automationPracticeRegFormPage.GetErrorMessage());
        }

        [Test]
        public void EmptyMobilePhone_When_RegisterUser()
        {
            _user.MobilePhone = string.Empty;

            _automationPracticeRegFormPage.FillRegForm(_user);

            Assert.AreEqual("You must register at least one phone number.", _automationPracticeRegFormPage.GetErrorMessage());
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
        }
    }
}
