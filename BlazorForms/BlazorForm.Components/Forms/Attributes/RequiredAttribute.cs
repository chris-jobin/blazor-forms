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

        public RequiredAttribute(string errorMessage) 
        {
            ErrorMessage = errorMessage;
        }

        public string? GetErrorMessage(object? value)
        {
            throw new NotImplementedException();
        }
    }
}
