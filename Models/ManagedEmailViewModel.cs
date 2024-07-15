using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class ManagedEmailViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Contact Email")]
        public string ContactEmailAddress { get; set; }
        [Required]
        [Display(Name = "Notifications Email")]
        public string NotificationEmailAddress { get; set; }
    }
}
