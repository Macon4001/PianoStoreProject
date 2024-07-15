using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PianoStoreProject.Models;
using PianoStoreProject.Repositories;
using System;
using System.Linq;

namespace PianoStoreProject.Controllers
{
    public class CartController : Controller
    {
        private ICartRepository _cart { get; set; }
        private ICheckOutRepository _checkout { get; set; }
        private IWebHostEnvironment _hostingEnviroment { get; set; }
        public CartController(ICartRepository cart, ICheckOutRepository checkout, IWebHostEnvironment hostingEnviroment)
        {
            _cart = cart;
            _checkout = checkout;
            _hostingEnviroment = hostingEnviroment;
        }


        #region Cart Products

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CartListing()
        {
            var data = _cart.GetCartItemsListing();
            ViewBag.Total = _cart.GetCartItemsListing().Select(x => Convert.ToDecimal(x.SubTotal)).Sum().ToString();
            return PartialView("_CartListing", data);
        }

        [Authorize]
        public IActionResult Checkout()
        {
            var data = _checkout.InitCheckOut();
            return View(data);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Checkout(OrderViewModel order)
        {
            _checkout.UpdateShippingAddress(order);
            return RedirectToAction("Orders");
        }

        public IActionResult Orders()
        {
            return View(_checkout.GetUserOrders());
        }

        [HttpGet]
        public IActionResult OrderDetail(int OrderId)
        {
            var data = _checkout.GetOrderedItemsListing(OrderId);
            return View(data);
        }

        #endregion

        #region Add to Cart

        [HttpPost]
        public IActionResult AddToCart(IFormCollection formData)
        {
            try
            {
                ShoppingCartItemsViewModel cart = new ShoppingCartItemsViewModel();
                foreach (var key in formData.Keys)
                {
                    if (key.Contains("ProductId"))
                    {
                        cart.ProductId = Convert.ToInt32(formData["ProductId"].ToString());
                    }
                    else
                    {
                        cart.ProductId = Convert.ToInt32(formData["Id"].ToString());
                    }
                }
                _cart.AddToCart(cart);
                return Json(new { key = true, value = "Product added to the cart successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { key = false, value = "Unable to process your request please contact to your admin" });
            }
        }

        [HttpPost]
        public IActionResult DeleteCartItem(int Id)
        {
            try
            {
                bool Result = _cart.DeleteCartItem(Id);
                if (Result)
                {
                    return Json(new { key = true, value = "Item deleted successfully" });
                }
                else
                {
                    return Json(new { key = false, value = "Unable to find the Item, it may be already deleted" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { key = false, value = "Unable to process your request please contact to your admin" });
            }
        }

        #endregion
    }
}
