using PageObjectModelTests.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModelTests.Factories
{
    public static class AutomationPracticeUserRegFactory
    {
        public static AutomationPracticeUserRegModel Create()
        {
            return new AutomationPracticeUserRegModel
            {
                FirstName = "John",
                LastName = "Cage",
                Password = "test12344321",
                Address = "Po Box 101",
                City = "Concord",
                State = "California",
                ZipCode = "21032",
                MobilePhone = "3423275321"
            };
        }
    }
}
