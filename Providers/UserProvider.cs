using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PianoStoreProject.Data;
using PianoStoreProject.Models;
using PianoStoreProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PianoStoreProject.Providers
{
    public class UserProvider : IUsersRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private PSPDBContext _context { get; }
        public UserProvider(UserManager<AppUser> userManager, PSPDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUserId()
        {
            string Email = _httpContextAccessor.HttpContext.User.Identity.Name;
            var user = _userManager.Users.FirstOrDefault(x => x.Email == Email);
            return user != null ? user.Id : string.Empty;
        }

        public string GetCurrentUserFullName()
        {
            string Email = _httpContextAccessor.HttpContext.User.Identity.Name;
            var _user = _context.Users.Where(x => x.Email == Email).FirstOrDefault();
            return _user != null ? (_user.FirstName + " " + _user.LastName) : string.Empty;
        }

        public List<UsersDto> UserListing(string type)
        {
            var users = _userManager.Users.Select(x => new UsersDto
            {
                UserId = x.Id,
                Name = x.FirstName + " " + x.LastName,
                Email = x.Email
            }).ToList();

            return users;
        }

        public bool DeleteUser(string Id)
        {
            var _userData = _context.Users.Find(Id);
            if (_userData != null)
            {
                _context.Users.Remove(_userData);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetDecoratedRoleName(string name)
        {
            if (name == "Administrator")
            {
                return "<span class='badge badge-danger'>" + name + "</span>";
            }
            else if (name == "User")
            {
                return "<span class='badge badge-primary'>" + name + "</span>";
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetUserFullName(string email)
        {

            var user = _userManager.Users.FirstOrDefault(x => x.Email == email);
            if (user != null)
            {
                return user.FirstName + " " + user.LastName;
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetUserId(string email)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Email == email);

            return user != null ? user.Id : string.Empty;
        }

        public string GetUserProfileImage(string email)
        {

            var user = _userManager.FindByEmailAsync(email).Result;
            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.ImagePath))
                {
                    return user.ImagePath;
                }
                else
                {
                    return "/ProfileImages/user-no-image.png";
                }
            }
            else
            {
                return "/ProfileImages/user-no-image.png";
            }
        }

        public string GetUserProfileImages(string id, string email)
        {
            var user = _userManager.FindByIdAsync(id).Result;
            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.ImagePath))
                {
                    return user.ImagePath;
                }
                else
                {
                    return "/ProfileImages/user-no-image.png";
                }
            }
            else
            {
                return "/ProfileImages/user-no-image.png";
            }
        }

        public ProfileDto GetProfile(string email)
        {
            var profile = new ProfileDto();
            var user = _userManager.FindByEmailAsync(email).Result;
            if (user != null)
            {
                profile.ProfileId = user.Id;
                profile.FirstName = user.FirstName;
                profile.LastName = user.LastName;
                profile.Email = user.Email;
                profile.Contact = user.PhoneNumber;
            }
            return profile;
        }

        public ProfileDto GetProfile(string id, string email)
        {
            var profile = new ProfileDto();
            var user = _userManager.FindByIdAsync(id).Result;

            if (user != null)
            {
                profile.ProfileId = user.Id;
                profile.FirstName = user.FirstName;
                profile.LastName = user.LastName;
                profile.Email = user.Email;
                profile.Contact = user.PhoneNumber;
            }

            return profile;
        }


        public void UpdateProfile(ProfileDto dto)
        {
            var user = _context.Users.Find(dto.ProfileId);
            if (user != null)
            {
                user.FirstName = dto.FirstName;
                user.LastName = dto.LastName;
                user.PhoneNumber = dto.Contact;
                _context.SaveChanges();
            }
        }

        public UsersDetailDto InitUser()
        {
            UsersDetailDto dto = new UsersDetailDto();
            dto.Roles = _context.Roles.AsEnumerable().Select(x => new RolesDto
            {
                RoleId = x.Id,
                Role = x.Name
            }).ToList();

            return dto;
        }

        public void UpdateProfilePicture(ProfileDto dto)
        {
            var user = _context.Users.Where(x => x.Email == dto.Email).FirstOrDefault();// _userManager.FindByIdAsync(dto.Email).Result;
            if (user != null)
            {
                user.ImagePath = dto.ImagePath;
                _context.SaveChanges();
            }
        }

        public List<UsersDetailDto> ListingUsers()
        {
            return _context.Users.AsEnumerable().Select(x => new UsersDetailDto
            {
                Id = x.Id.ToString(),
                FirstName = x.FirstName + " " + x.LastName,
                Email = x.Email,
                RoleName = GetUserRole(x.Id.ToString()),
                Contact = x.PhoneNumber,
                CreatedDate = x.RegistrationDate.ToString("MMM dd, yyyy hh:mm tt"),
                EmailConfirmed = x.EmailConfirmed ? "<span class='badge badge-success'> YES </span>" : "<span class='badge badge-danger'> NO </span>",
                status = x.LockoutEnd != null ? "<span class='badge badge-danger'> Blocked </span>" : "<span class='badge badge-success'> Active </span>"
            }).ToList();
        }

        private string GetUserRole(string userId)
        {
            var _userRoles = _context.UserRoles.Where(x => x.UserId == userId).FirstOrDefault();
            if (_userRoles != null)
            {
                var _role = _context.Roles.Find(_userRoles.RoleId);
                return GetDecoratedRoleName(_role.Name);
            }
            else
            { return string.Empty; }
        }

        public int BlockOrUnblockUser(string userId)
        {
            // 1 for blocked,  2 for unblocked , 0 for user not found
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                if (user.LockoutEnd == null)
                {
                    user.LockoutEnd = DateTime.Now.AddYears(100);
                    _context.SaveChanges();
                    return 1;

                }
                else
                {
                    user.LockoutEnd = null;
                    _context.SaveChanges();
                    return 2;
                }
            }
            else
            {
                return 0;
            }

        }
        public ManageUserDto EditUserRole(string id)
        {
            ManageUserDto dto = new ManageUserDto();
            dto.UserId = id;
            var userRole = _context.UserRoles.Where(x => x.UserId == id).FirstOrDefault();
            if (userRole != null)
            {
                dto.RoleType = _context.Roles.Find(userRole.RoleId).Name;
            }

            dto.Roles = _context.Roles.AsEnumerable().Select(x => new RolesDto
            {
                RoleId = x.Id,
                Role = x.Name
            }).ToList();
            return dto;
        }

        public async System.Threading.Tasks.Task UpdateRoleAsync(ManageUserDto dto)
        {
            IdentityResult result;
            var _userrole = _context.UserRoles.Where(x => x.UserId == dto.UserId).FirstOrDefault();
            string _roleName = _userrole != null ? _context.Roles.Where(x => x.Id == _userrole.RoleId).FirstOrDefault()?.Name ?? string.Empty : string.Empty;
            var _user = await _userManager.FindByIdAsync(dto.UserId);
            if (!(await _userManager.IsInRoleAsync(_user, dto.RoleType)))
            {
                if (_roleName != null && _roleName != dto.RoleType && _roleName.Trim() != string.Empty)
                {
                    result = await _userManager.RemoveFromRoleAsync(_user, _roleName);
                }
                result = await _userManager.AddToRoleAsync(_user, dto.RoleType);
            }
            else
            {
                result = await _userManager.AddToRoleAsync(_user, dto.RoleType);
            }
        }

        public string GenerateUniqueCustomerID()
        {
            Random randomObj = new Random();
            string generatedId = string.Empty;
            do
            {
                generatedId = "C" + (randomObj.Next(1000, 100000000).ToString());
            } while (_context.Users.Where(x => x.CustomerID == generatedId).FirstOrDefault() != null);

            return generatedId;
        }


        public string GetCustomerID()
        {
            var userData = _context.Users.Where(x => x.Id == GetCurrentUserId()).FirstOrDefault();
            if (userData != null)
            {
                return userData.CustomerID;
            }
            else
            {
                return string.Empty;
            }
        }


        public void SetUsersCustomerID()
        {
            var _UserList = _context.Users.ToList();
            foreach (var usr in _UserList)
            {
                if (String.IsNullOrEmpty(usr.CustomerID))
                {
                    usr.CustomerID = GenerateUniqueCustomerID();
                }
            }
            _context.SaveChanges();
        }

    }
}
