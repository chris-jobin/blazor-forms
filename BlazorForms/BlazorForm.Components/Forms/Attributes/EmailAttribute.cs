using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute : Attribute, IFormAttribute
    {
        public string ErrorMessage { get; set; }
        public string Pattern { get; set; } = "[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}"; // super basic email regex to keep it short.

        public EmailAttribute() : this("Invalid email format.") 
        { }
        public EmailAttribute(string errorMessage)
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
