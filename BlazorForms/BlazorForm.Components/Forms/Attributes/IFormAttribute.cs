using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms.Attributes
{
    public interface IFormAttribute
    {
        public string ErrorMessage { get; set; }
        public string? GetErrorMessage(object? value);
    }
}
