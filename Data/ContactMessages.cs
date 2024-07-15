using System;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Data
{
    public class ContactMessages
    {
        [Required, Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime Datetime { get; set; }
    }
}
