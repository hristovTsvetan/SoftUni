using OpenQA.Selenium;

namespace PageObjectModelTests.Pages.DemoQAPages
{
    public class DemoQAResizablePage : BasePage
    {
        public DemoQAResizablePage(IWebDriver driver)
            :base(driver)
        {

        }

        public IWebElement ResizableElement => Driver.FindElement(By.Id("resizable"));

        public IWebElement ResizableHandler => Driver.FindElement(By.XPath("//div[@id='resizable']//span"));

        public void ResizeElementVertical()
        {
            Builder.ClickAndHold(ResizableHandler).MoveByOffset(0, 100).Release().Perform();
        }

        public void ResizeElementHorizontal()
        {
            Builder.ClickAndHold(ResizableHandler).MoveByOffset(100, 0).Release().Perform();
        }

        public string GetHeightOnResizableElement()
        {
            return ResizableElement.GetCssValue("height");
        }

        public string GetWidthOnResizableElement()
        {
            return ResizableElement.GetCssValue("width");
        }
    }
}
