using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumberAttribute : Attribute, IFormAttribute
    {
        public string ErrorMessage { get; set; }
        public string Pattern { get; set; } = "^(\\(\\d{3}\\)|\\d{3})-?\\d{3}-?\\d{4}$"; // super basic phone number regex to keep it short.

        public PhoneNumberAttribute() : this("Invalid phone number format.") 
        { }
        public PhoneNumberAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public string? GetErrorMessage(object? value)
        {
            if (value is null)
                return null;

            if (value is string && !Regex.IsMatch((string)value, Pattern))
                return ErrorMessage;

            return null;
        }
    }
}
