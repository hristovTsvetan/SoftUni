using OpenQA.Selenium;

namespace PageObjectModelTests.Pages.DemoQAPages
{
    public class DemoQASortablePage : BasePage
    {
        public DemoQASortablePage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement FirstElement => Driver.FindElements(By.XPath("//div[@class='vertical-list-container mt-4']//div[@class='list-group-item list-group-item-action']"))[0];

        public IWebElement SecondElement => Driver.FindElements(By.XPath("//div[@class='vertical-list-container mt-4']//div[@class='list-group-item list-group-item-action']"))[1];

        public void MoveFirstElementUnderSecondElement()
        {
            Builder.ClickAndHold(FirstElement).MoveToElement(SecondElement).MoveByOffset(0, 10).Release().Perform();
        }

        public string GetTextOnFirstElement()
        {
            return FirstElement.Text;
        }

        public string GetTextOnSecondElement()
        {
            return SecondElement.Text;
        }
    }
}
