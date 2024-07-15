using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Notification Message")]
        public string NotificationMessage { get; set; }
        [Display(Name = "Url")]
        public string NotificationUrl { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
