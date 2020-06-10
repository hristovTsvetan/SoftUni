using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModelTests.Pages.DemoQAPages
{
    public class DemoQASelectablePage : BasePage
    {
        public DemoQASelectablePage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement FirstElement => Driver.FindElements(By.XPath("//ul[@id='verticalListContainer']//li"))[0];

        public IWebElement SecondElement => Driver.FindElements(By.XPath("//ul[@id='verticalListContainer']//li"))[1];

        public void SelectFirstElement()
        {
            Builder.Click(FirstElement).Perform();
        }

        public string GetBackgroundColorOnFirstElement()
        {
            return FirstElement.GetCssValue("background-color");
        }

        public string GetBackgroundColorOnSecondElement()
        {
            return SecondElement.GetCssValue("background-color");
        }
    }
}
