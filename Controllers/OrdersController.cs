using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PianoStoreProject.Repositories;
using System;

namespace PianoStoreProject.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class OrdersController : Controller
    {
        private ICheckOutRepository _checkout { get; set; }
        public OrdersController(ICheckOutRepository checkout)
        {
            _checkout = checkout;
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult Delivered()
        {
            return View(_checkout.GetCompletedOrders());
        }


        [HttpGet]
        public IActionResult NewOrdersListing()
        {
            return PartialView("_OrdersListing", _checkout.GetNewUserOrders());
        }

        public IActionResult OrderItems(int Id)
        {
            return View(_checkout.GetOrderedItemsListing(Id));
        }

        [HttpPost]
        public ActionResult ConfirmShippedOrder(int id, int statusId)
        {
            try
            {
                bool Result = _checkout.ConfirmDeliverOrder(id, statusId);
                if (Result)
                {
                    return Json(new { key = true, value = "Order status changed successfully" });
                }
                else
                {
                    return Json(new { key = false, value = "Unable to find the Order" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { key = false, value = "Unable to process your request please contact to your admin" });
            }

        }

    }
}
