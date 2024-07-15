using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PianoStoreProject.Models;
using PianoStoreProject.Repositories;
using System;
using System.Threading.Tasks;

namespace PianoStoreProject.Controllers
{
    public class ManageController : Controller
    {
        private IUsersRepository _users { get; set; }
        private IContactRepository _contact { get; set; }
        private ICategoryRepository _category { get; set; }
        private INotificationRepository _notification { get; set; }
        public ManageController(IUsersRepository users, IContactRepository contact, ICategoryRepository category, INotificationRepository notification)
        {
            _users = users;
            _contact = contact;
            _category = category;
            _notification = notification;
        }


        #region Dashboard
        [Authorize(Roles = "Administrator")]
        public IActionResult Dashboard()
        {
            return View();
        }

        #endregion


        #region User Management

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult Users()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserListing()
        {
            var List = _users.ListingUsers();
            return PartialView("_UserListing", List);
        }

        [HttpPost]
        public ActionResult DeleteUser(string id)
        {
            try
            {
                bool Result = _users.DeleteUser(id);
                if (Result)
                {
                    return Json(new { key = true, value = "User deleted successfully" });
                }
                else
                {
                    return Json(new { key = false, value = "Unable to find the User, it may be already deleted" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { key = false, value = "Unable to process your request please contact to your admin" });
            }

        }

        [HttpPost]
        public ActionResult UpdateProfile(ProfileDto dto)
        {

            try
            {
                if (dto.ProfileId != null && dto.ProfileId != string.Empty)
                {
                    _users.UpdateProfile(dto);
                    return Json(new { key = true, value = "Update Profile Successfully" });

                }
                return Json(new { key = false, value = "Profile not found" });
            }
            catch (Exception ex)
            {

                return Json(new { key = false, value = "Unable to process your request please contact to your admin" });
            }
        }


        [HttpPost]
        public IActionResult BlockUser(string UserId)
        {
            int result = _users.BlockOrUnblockUser(UserId);
            if (result == 1)
            {
                return Json(new { key = true, value = "User blocked successfully." });
            }
            else if (result == 2)
            {
                return Json(new { key = true, value = "User unblocked successfully." });
            }
            else
            {
                return Json(new { key = false, value = "User not found" });
            }
        }

        [HttpGet]
        public ActionResult Role(string id)
        {
            ViewBag.Title = "Update User Role";
            ManageUserDto dto = _users.EditUserRole(id);
            return View("Role", dto);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(ManageUserDto dto)
        {
            try
            {
                await _users.UpdateRoleAsync(dto);
                return Json(new { key = true, value = "User role updated successfully" });

            }
            catch (Exception ex)
            {

                return Json(new { key = false, value = "Unable to Process your Request please contact with your Admin " });
            }
        }



        #endregion

        #region Managed Emails

        [Authorize(Roles = "Administrator")]
        public IActionResult Emails()
        {
            return View(_contact.GetEmails());
        }
        public IActionResult Message(int Id)
        {
            return View(_contact.GetMessage(Id));
        }

        #endregion

        #region Email Addresses

        [Authorize(Roles = "Administrator")]
        public IActionResult Mails()
        {
            return View(_contact.GetManagedEmails());
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public IActionResult AddOrUpdateEmail(ManagedEmailViewModel contact)
        {
            try
            {
                _contact.AddOrUpdateEmails(contact);
                return Json(new { key = true, value = "Emails updated successfully" });
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin." });
            }
        }

        #endregion

        #region Categories

        [Authorize(Roles = "Administrator")]
        public IActionResult Categories()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult EditCategory(int Id)
        {
            ViewBag.PageTitle = "Edit Category";
            var _data = _category.EditCategory(Id);
            return View("AddCategories", _data);

        }

        public IActionResult AddCategories()
        {
            ViewBag.PageTitle = "Add New Category";
            return View(new CategoriesViewModel());
        }

        public IActionResult CategoryListing()
        {
            return PartialView("_CategoryListing", _category.GetAllCategories());
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCategories()
        {
            return Json(new { categories = _category.GetAllCategories() });
        }


        [HttpPost]
        public IActionResult AddOrUpdateCategory(CategoriesViewModel dto)
        {
            try
            {
                if (dto.Id != 0)
                {
                    _category.UpdateCategory(dto);
                    return Json(new { key = true, value = "Category updated successfully" });
                }
                else
                {
                    _category.AddCategory(dto);
                    return Json(new { key = true, value = "Category added Successfully" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin." });
            }
        }

        public IActionResult DeleteCategory(int Id)
        {
            try
            {
                bool result = _category.DeleteCategory(Id);
                if (result)
                {
                    return Json(new { key = true, value = "Category deleted successfully" });
                }
                else
                {
                    return Json(new { key = false, value = "Unable to find Category Record or Category already deleted" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin" });
            }
        }

        #endregion
        #region Notification

        [Authorize(Roles = "Administrator")]
        public IActionResult Notifications()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AddNotification()
        {
            ViewBag.PageTitle = "Add New Notification";
            return View(new NotificationViewModel());
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult EditNotification(int Id)
        {
            ViewBag.PageTitle = "Edit Notification";
            return View("AddNotification", _notification.EditNotification(Id));
        }

        [HttpPost]
        public IActionResult AddOrUpdateNotification(NotificationViewModel dto)
        {
            try
            {
                if (dto.Id != 0)
                {
                    _notification.UpdateNotification(dto);
                    return Json(new { key = true, value = "Notification updated successfully" });
                }
                else
                {
                    _notification.AddNotification(dto);
                    return Json(new { key = true, value = "Notification added Successfully" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin." });
            }
        }

        public IActionResult DeleteNotification(int Id)
        {
            try
            {
                bool result = _notification.DeleteNotification(Id);
                if (result)
                {
                    return Json(new { key = true, value = "Notification deleted successfully" });
                }
                else
                {
                    return Json(new { key = false, value = "Unable to find Notification Record or Notification already deleted" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin" });
            }
        }

        public IActionResult NotificationListing()
        {
            return PartialView("_NotificationListing", _notification.GetAllNotification());
        }

        #endregion
    }
}
