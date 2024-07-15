using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PianoStoreProject.Models;
using PianoStoreProject.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PianoStoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICategoryRepository _Category { get; set; }
        private IContactRepository _contact { get; }
        private IProductRepository _product { get; }
        private IHttpContextAccessor _httpContextAccessor { get; set; }
        private IUsersRepository _user { get; }

        public HomeController(ILogger<HomeController> logger, ICategoryRepository Category,
             IHttpContextAccessor httpContextAccessor, IUsersRepository user,
            IContactRepository contact, IProductRepository product)
        {
            _logger = logger;
            _Category = Category;
            _contact = contact;
            _product = product;
            _httpContextAccessor = httpContextAccessor;
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Categories 
        public IActionResult Categories()
        {
            return View();
        }

        #endregion

          #region Products

        public IActionResult Products(int Id)
        {
            ViewBag.CategoryName = _Category.GetCategoryName(Id);
            return View(new ProductsFilterViewModel() { CategoryId = Id });
        }

        [HttpPost]
        public IActionResult ProductListing(ProductsFilterViewModel data)
        {
            var _data = _product.GetProductListing(data);
            ViewBag.PageCount = _data.FirstOrDefault() != null ? _data.FirstOrDefault().PageSize : 0;
            return PartialView("_ProductListing", _data);
        }

        public IActionResult Product(int Id)
        {
            return View();
        }

        #endregion

        #region Contact Us
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel contact)
        {
            try
            {
                _contact.SendAndAddMessagesAsync(contact);
                return Json(new { key = true, value = "Message sent successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin." });
            }
        }

        #endregion


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
