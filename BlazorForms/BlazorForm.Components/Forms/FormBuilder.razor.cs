using BlazorForm.Components.Forms.Attributes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms
{
    public partial class FormBuilder
    {
        [Parameter, EditorRequired]
        public IFormable Model { get; set; } = default!;
        private ICollection<PropertyInfo> Properties;

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
            if (Model != null)
            {
                Properties = GetProperties();
            }
        }

        protected ICollection<PropertyInfo> GetProperties()
        {
            var properties = Model.GetType().GetProperties();
            var formableProperties = properties.Where(x => x.GetCustomAttributes<FormableAttribute>().Any());
            return formableProperties.ToList();
        }

        protected static string GetDisplayName(PropertyInfo propertyInfo)
        {
            var displayNameAttribute = propertyInfo.GetCustomAttribute<DisplayNameAttribute>();
            return displayNameAttribute?.DisplayName ?? propertyInfo.Name;
        }

        protected static RenderFragment GetFormComponent(PropertyInfo propertyInfo)
        {
            var formableAttibute = propertyInfo.GetCustomAttribute<FormableAttribute>();
            return formableAttibute.GetFormComponent(propertyInfo);
        }
    }
}
