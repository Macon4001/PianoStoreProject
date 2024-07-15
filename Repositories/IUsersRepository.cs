using PianoStoreProject.Models;
using System.Collections.Generic;

namespace PianoStoreProject.Repositories
{
    public interface IUsersRepository
    {
        string GetCurrentUserId();
        string GetCurrentUserFullName();
        List<UsersDto> UserListing(string type);
        bool DeleteUser(string Id);
        string GetDecoratedRoleName(string name);
        string GetUserFullName(string email);
        string GetUserId(string email);
        string GetUserProfileImage(string email);
        string GetUserProfileImages(string id, string email);
        ProfileDto GetProfile(string email);
        ProfileDto GetProfile(string id, string email);
        void UpdateProfile(ProfileDto dto);
        void UpdateProfilePicture(ProfileDto dto);
        UsersDetailDto InitUser();
        List<UsersDetailDto> ListingUsers();
        ManageUserDto EditUserRole(string id);
        int BlockOrUnblockUser(string userId);
        System.Threading.Tasks.Task UpdateRoleAsync(ManageUserDto dto);
        string GenerateUniqueCustomerID();
        string GetCustomerID();
        void SetUsersCustomerID();
    }
}
