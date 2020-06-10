using OpenQA.Selenium;

namespace PageObjectModelTests.Pages.DemoQAPages
{
    public class DemoQAInteractionsPage : BasePage
    {
        public DemoQAInteractionsPage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement MenuSortableButton => Driver.FindElement(By.XPath("//span[text()='Sortable']//ancestor::li[@class='btn btn-light ']"));

        public IWebElement MenuSelectableButton => Driver.FindElement(By.XPath("//span[text()='Selectable']//ancestor::li[@class='btn btn-light ']"));

        public IWebElement MenuResizableButton => Driver.FindElement(By.XPath("//span[text()='Resizable']//ancestor::li[@class='btn btn-light ']"));

        public IWebElement MenuDroppableButton => ScrollToElement(Driver.FindElement(By.XPath("//span[text()='Droppable']//ancestor::li[@class='btn btn-light ']")));

        public IWebElement MenuDraggableButton => ScrollToElement(Driver.FindElement(By.XPath("//span[text()='Dragabble']//ancestor::li[@class='btn btn-light ']")));



        public DemoQASortablePage GoToSortablePage()
        {
            MenuSortableButton.Click();

            return (new DemoQASortablePage(Driver));
        }

        public DemoQASelectablePage GoToSelectablePage()
        {
            MenuSelectableButton.Click();

            return (new DemoQASelectablePage(Driver));
        }

        public DemoQAResizablePage GoToResizablePage()
        {
            MenuResizableButton.Click();

            return new DemoQAResizablePage(Driver);
        }

        public DemoQADroppablePage GoToDroppablePage()
        {
            MenuDroppableButton.Click();

            return new DemoQADroppablePage(Driver);
        }

        public DemoQADraggablePage GoToDraggablePage()
        {
            MenuDraggableButton.Click();

            return new DemoQADraggablePage(Driver);
        }

    }
}
