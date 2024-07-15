using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Data
{
    public class AppUser : IdentityUser
    {
        [PersonalData, Required]
        public string FirstName { get; set; }
        [PersonalData, Required]
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public string CustomerID { get; set; }
    }
}
