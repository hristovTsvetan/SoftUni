using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PageObjectModelTests.Pages.DemoQAPages
{
    public class DemoQADroppablePage : BasePage
    {
        public DemoQADroppablePage(IWebDriver driver)
            :base(driver)
        {

        }

        public IWebElement DragElement
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@classname='Top-Ad']")));
                var dragElement = Wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("draggable")));
                ScrollToElement(dragElement);
                return dragElement;
            }
        }

        public IWebElement DropElement => Wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("droppable")));

        public void DragAndDropElement()
        {
            Builder.DragAndDrop(DragElement, DropElement).Perform();
        }

        public string GetBackgroundColorOnTargetElement()
        {
            return DropElement.GetCssValue("background-color");
        }

        public string GetTextInTargetElement()
        {
            return DropElement.FindElement(By.XPath("//p[1]")).Text;
        }

        public string GetTextInSourceElement()
        {
            return DragElement.Text;
        }


    }
}
