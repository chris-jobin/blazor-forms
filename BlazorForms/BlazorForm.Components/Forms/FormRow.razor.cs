using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForm.Components.Forms
{
    public partial class FormRow
    {
        [CascadingParameter]
        public Form Form { get; set; } = default!;
        [Parameter] 
        public RenderFragment ChildContent { get; set; } = default!;
        [Parameter]
        public Expression<Func<object>> For { get; set; } = default!;
        [Parameter]
        public string Label { get; set; } = default!;
        [Parameter]
        public int LabelWidth { get; set; } = 4;

        protected override async Task OnInitializedAsync()
        {
            if (Form is null)
                throw new NullReferenceException("Cannot initialize FormRow outside of Form");

            Form.AddRow(this);

            await Task.Yield();
        }
    }
}
