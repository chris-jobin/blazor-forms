using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : Attribute, IFormAttribute
    {
        public string ErrorMessage { get; set; }

        public RequiredAttribute() : this("This field is required.")
        { }
        public RequiredAttribute(string errorMessage) 
        {
            ErrorMessage = errorMessage;
        }

        public string? GetErrorMessage(object? value)
        {
            if (value is null)
                return ErrorMessage;

            if (value is string && string.IsNullOrEmpty((string)value)) 
                return ErrorMessage;

            if (double.TryParse(value.ToString(), out var numericValue) && numericValue == 0)
                return ErrorMessage;

            if (value is bool && !(bool)value)
                return ErrorMessage;

            return null;
        }
    }
}
