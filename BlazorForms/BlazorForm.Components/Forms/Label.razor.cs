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
    public partial class Label
    {
        [Parameter]
        public Expression<Func<object>> For { get; set; } = default!;
        [Parameter]
        public string CSSClass { get; set; } = default!;
        protected string Text { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if (For is null)
                return;

            var info = For.GetPropertyInfoFromExpression();
            var displayNameAttribute = info.GetCustomAttribute<DisplayNameAttribute>();
            Text = displayNameAttribute?.DisplayName ?? info.Name;

            var requiredAttribute = info.GetCustomAttribute<RequiredAttribute>();
            if (requiredAttribute is not null)
                Text += "<span class=\"validation-message\">*</span>";

            await Task.Yield();
        }
    }
}
