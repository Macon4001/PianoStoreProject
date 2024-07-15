using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class UsersDetailDto
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "Password must include a Uppercase and Lowercase letter, a Symbol and a Digit")]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Role")]
        [Required]
        public string RoleId { get; set; }
        public List<RolesDto> Roles { get; set; }
        //Listings

        [Display(Name = "Role")]
        public string RoleName { get; set; }
        [Display(Name = "Action")]
        public string Action { get; set; }
        public string EmailConfirmed { get; set; }
        public string status { get; set; }
        public bool blocked { get; set; }
        [Display(Name = "Contact No.")]
        public string Contact { get; set; }
        [Display(Name = "Created Date")]
        public string CreatedDate { get; set; }
    }
}
