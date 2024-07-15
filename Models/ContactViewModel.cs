using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Phone No.")]
        public string PhoneNo { get; set; }
        [Required]
        public string Message { get; set; }
        // Binded Items 
        public bool IsRead { get; set; }
        public string Datetime { get; set; }
    }
}
