using BlazorForm.Components.Forms;
using BlazorForm.Components.Forms.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForms.Shared.Models
{
    public class ContactInformationModel : IFormable
    {
        [PhoneNumber]
        public string? CellPhone { get; set; }
        [PhoneNumber]
        public string? WorkPhone { get; set; }

        [Required("Cell or Work phone is required.")]
        public bool _PhoneNumber => !string.IsNullOrEmpty(CellPhone) || !string.IsNullOrEmpty(WorkPhone);

        [Email]
        public string? Email { get; set; }
    }
}
