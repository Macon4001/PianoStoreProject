using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class ProfileDto
    {
        [Display(Name = "Id")]
        public string ProfileId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Contact")]
        public string Contact { get; set; }
        public string ImagePath { get; set; }
    }
}
