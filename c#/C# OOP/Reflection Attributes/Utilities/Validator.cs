using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Utilities
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            if(obj == null)
            {
                 throw new ArgumentException("Object can't be null!");
            }

            Type objType = obj.GetType();
            PropertyInfo[] allProperties = objType.GetProperties();

            foreach(PropertyInfo property in allProperties)
            {
                MyValidationAttribute[] allAttributes = property.GetCustomAttributes()
                    .Where(attr => attr is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (MyValidationAttribute attribute in allAttributes)
                {
                    if(!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
