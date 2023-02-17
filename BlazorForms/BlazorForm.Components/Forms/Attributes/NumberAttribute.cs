using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NumberAttribute : Attribute, IFormAttribute
    {
        public string ErrorMessage { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }

        public NumberAttribute(double max = 0, double min = 0) : this("Invalid range.", max, min)
        { }
        public NumberAttribute(string errorMessage, double max = 0, double min = 0)
        {
            if (min > Max)
                throw new ArgumentOutOfRangeException("Min cannot be bigger than Max.");

            ErrorMessage = errorMessage;
            Max = max;
            Min = min;
        }

        public string? GetErrorMessage(object? value)
        {
            if (value is null)
                return null;

            var isNumeric = double.TryParse(value.ToString(), out var numericValue);

            if (isNumeric)
            {
                if (numericValue > Max)
                    return ErrorMessage;
                if (numericValue < Min) 
                    return ErrorMessage;
            }

            return null;
        }
    }
}
