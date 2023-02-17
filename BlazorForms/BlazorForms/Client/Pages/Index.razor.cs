using BlazorForms.Client.Components;
using BlazorForms.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorForms.Client.Pages
{
    public partial class Index
    {
        [Inject]
        public HttpClient Http { get; set; }

        public ContactForm? ContactFormRef { get; set; }
        public ContactModel? ContactModel { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ContactModel = await Http.GetFromJsonAsync<ContactModel>("api/Form/GetContactModel");
        }
    }
}
