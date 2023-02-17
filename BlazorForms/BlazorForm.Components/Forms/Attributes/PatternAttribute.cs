using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PatternAttribute : Attribute, IFormAttribute
    {
        public string ErrorMessage { get; set; }
        public string Pattern { get; set; }

        public PatternAttribute(string pattern) : this("Invalid format.", pattern) 
        { }
        public PatternAttribute(string errorMessage, string pattern) 
        { 
            ErrorMessage = errorMessage;
            Pattern = pattern;
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
