using BlazorForms.Client.Components;
using BlazorForms.Shared.Models;

namespace BlazorForms.Client.Pages
{
    public partial class Index
    {
        public ContactForm? ContactFormRef { get; set; }
        public ContactModel ContactModel { get; set; } = new ContactModel();
    }
}
