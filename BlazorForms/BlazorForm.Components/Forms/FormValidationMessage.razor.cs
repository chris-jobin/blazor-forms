using BlazorForm.Components.Forms.Attributes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms
{
    public partial class FormValidationMessage
    {
        [CascadingParameter]
        public Form Form { get; set; } = default!;

        public Expression<Func<object>> _for = default!;
        [Parameter]
        public Expression<Func<object>> For
        {
            get
            {
                return _for;
            }
            set
            {
                _for = value;
                if (Model != null)
                    Validate(Model);
            }
        }
        protected List<string> ErrorMessages { get; set; } = new List<string>();
        protected object? Model { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Form is null)
                throw new NullReferenceException("Cannot initialize FormValidationMessage outside of Form");

            Form.AddValidationMessage(this);

            await Task.Yield();
        }

        public bool Validate(object model)
        {
            Model ??= model;
            ErrorMessages = new List<string>();

            var info = For.GetPropertyInfoFromExpression();
            var value = info.GetValue(Model, null);
            var attributes = info.GetCustomAttributes(false);
            foreach (var attr in attributes)
            {
                if (attr is not IFormAttribute)
                    continue;

                var errorMessage = ((IFormAttribute)attr).GetErrorMessage(value);

                if (!string.IsNullOrEmpty(errorMessage))
                    ErrorMessages.Add(errorMessage);
            }
            return !ErrorMessages.Any();
        }
    }
}
