using System;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Data
{
    public class Notifications
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public string NotificationMessage { get; set; }
        public string url { get; set; }
        [Required]
        public bool Status { get; set; }
        [Required]
        public DateTime NotificationDate { get; set; }
    }
}
