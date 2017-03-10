using System.ComponentModel.DataAnnotations;

namespace adamtarling.web.ViewModels.Components
{
    public class ContactFormViewModel : ComponentBaseViewModel
    {
        public string Title { get; set; }
        public string Copy { get; set; }
        public string NameLabel { get; set; }
        public string EmailLabel { get; set; }
        public string PhoneLabel { get; set; }
        public string MessageLabel { get; set; }
        public string SubmitButtonLabel { get; set; }
        public string LocationParameterString { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }
    }
}