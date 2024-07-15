using System.ComponentModel.DataAnnotations;

namespace PianoStoreProject.Models
{
    public class ProfilePictureDto
    {
        [Display(Name = "Image URL")]
        public string PhotoURL { get; set; }

        public string avatarCropped { get; set; }
    }
}
