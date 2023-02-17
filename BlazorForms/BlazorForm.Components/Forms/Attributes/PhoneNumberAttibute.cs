using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumberAttibute : Attribute, IFormAttribute
    {
        public string ErrorMessage { get; set; }
        public string Pattern { get; set; } = "^(\\(\\d{3}\\)|\\d{3})-?\\d{3}-?\\d{4}$"; // super basic phone number regex to keep it short.

        public PhoneNumberAttibute() : this("Invalid phone number format.") 
        { }
        public PhoneNumberAttibute(string errorMessage)
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
