using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModelTests.Tests
{
    public class BaseInteractionTest : BaseTest
    {
        public void Initialization()
        {
            Initiate();
            Driver.Navigate().GoToUrl("http://demoqa.com/");
        }
    }
}
