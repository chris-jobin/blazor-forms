using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms
{
    public partial class Form
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; } = default!;
        [Parameter]
        public object Model { get; set; } = default!;
        protected List<FormRow> Rows { get; set; } = new List<FormRow>();
        protected List<FormValidationMessage> ValidationMessages { get; set; } = new List<FormValidationMessage>();

        protected override async Task OnInitializedAsync()
        {
            if (Model is null)
                throw new NullReferenceException("Cannot initialize Form without Model");

            await Task.Yield();
        }

        public void AddRow(FormRow row) => Rows.Add(row);

        public void AddValidationMessage(FormValidationMessage message) => ValidationMessages.Add(message);

        public bool Validate()
        {
            var isvalid = true;
            foreach (var message in ValidationMessages)
                isvalid = message.Validate(Model) && isvalid;
            return isvalid;
        }
    }
}
