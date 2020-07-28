using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int minValue;
        private readonly int maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            CheckRange(minValue, maxValue);
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if(obj is Int32)
            {
                int curValue = (int)obj;
                if(curValue < minValue || curValue > maxValue)
                {
                    return false;
                }
                return true;
            }
            else
            {
                throw new ArgumentException("Invalid type!");
            }
        }

        public void CheckRange(int minValue, int maxValue)
        {
            if(minValue > maxValue)
            {
                throw new ArgumentException("Range is not valid!");
            }
        }
    }
}
