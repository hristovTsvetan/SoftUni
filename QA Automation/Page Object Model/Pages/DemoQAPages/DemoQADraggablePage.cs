using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModelTests.Pages.DemoQAPages
{
    public class DemoQADraggablePage : BasePage
    {
        public DemoQADraggablePage(IWebDriver driver)
            :base(driver)
        {

        }

        public IWebElement DragElement
        {
            get
            {
                Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@classname='Top-Ad']")));
                var dragElement = Wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.Id("dragBox")));
                ScrollToElement(dragElement);
                return dragElement;
            }
        }

        public void MoveElementHorizontal()
        {
            Builder.DragAndDropToOffset(DragElement, 300, 0).Perform();
        }

        public void MoveElementVertical()
        {
            Builder.DragAndDropToOffset(DragElement, 0, 300).Perform();
        }

        public void MoveElementDiagonal()
        {
            Builder.DragAndDropToOffset(DragElement, 300, 300).Perform();
        }

        public string GetDraggableElementVerticalPosition()
        {
            return DragElement.GetCssValue("Left");
        }

        public string GetDraggableElementHorizontalPosition()
        {
            return DragElement.GetCssValue("Top");
        }
    }
}
