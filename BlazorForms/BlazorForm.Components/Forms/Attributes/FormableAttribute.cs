using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FormableAttribute : Attribute
    {
        public Type FieldType { get; set; }

        public FormableAttribute(Type fieldType) 
        {
            FieldType = fieldType;
        }

        public RenderFragment? GetFormComponent(PropertyInfo binding)
        {
            RenderFragment? result = null;
            if (FieldType == typeof(string))
            {
                result = builder =>
                {
                    builder.OpenElement(0, "input");
                    builder.AddAttribute(1, "class", "form-control");
                    builder.AddAttribute(2, "bind-value", binding);
                    builder.CloseComponent();
                };
            }
            return result;
        }
    }
}
