using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class UsersDto
    {
        [Display(Name = "Id")]
        public string UserId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "User Type")]
        public string Type { get; set; }
    }
}
