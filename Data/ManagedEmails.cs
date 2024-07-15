using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Data
{
    public class ManagedEmails
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string ContactEmailAddress { get; set; }
        [Required]
        public string NotificationEmailAddress { get; set; }
    }
}
