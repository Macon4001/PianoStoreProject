using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class ManageUserDto
    {
        [Display(Name = "Id")]
        public string UserId { get; set; }

        [Display(Name = "FullName")]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Role Type")]
        [Required]
        public string RoleType { get; set; }
        [Display(Name = "RoleName")]
        public string RoleName { get; set; }
        [Required]
        [Display(Name = "RoleId")]
        public string RoleId { get; set; }
        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }
        public List<RolesDto> Roles { get; set; }
    }
}
