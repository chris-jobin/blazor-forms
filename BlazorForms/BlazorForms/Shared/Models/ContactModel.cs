using BlazorForm.Components.Forms;
using BlazorForm.Components.Forms.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorForms.Shared.Models
{
    public class ContactModel : IFormable
    {
        [Formable(typeof(string))]
        [DisplayName("Last Name")]
        [Required("Last name is required.")]
        [StringLength("Last name cannot be longer than 15 characters", max: 15)]
        public string? LastName { get; set; }

        [Formable(typeof(string))]
        [DisplayName("First Name")]
        [Required("First name is required.")]
        [StringLength("First name must be longer than 3 characters", min: 3)]
        public string? FirstName { get; set; }

        [Formable(typeof(int))]
        [DisplayName("Age")]
        [Required]
        [Number("Must be 18 years old or older.", min: 18)]
        public int Age { get; set; }

        [Formable(typeof(double))]
        [DisplayName("Net Worth")]
        [Number(min: 9.99, max: 999_999.00)]
        public double NetWorth { get; set; }

        [Required]
        public string? Address { get; set; }

        [Formable(typeof(ContactInformationModel))]
        public ContactInformationModel ContactInformation { get; set; } = new ContactInformationModel();
    }
}
