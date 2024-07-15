using Microsoft.EntityFrameworkCore;
using PianoStoreProject.Data;
using PianoStoreProject.Models;
using PianoStoreProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PianoStoreProject.Providers
{
    public class CheckoutProvider : ICheckOutRepository
    {
        private ICartRepository _cart { get; set; }
        private IUsersRepository _user { get; set; }
        private PSPDBContext _context { get; set; }
        public CheckoutProvider(ICartRepository cart, PSPDBContext context, IUsersRepository user)
        {
            _cart = cart;
            _context = context;
            _user = user;
        }
        public OrderViewModel InitCheckOut()
        {
            return new OrderViewModel() { TotalAmount = _cart.GetCartTotal().ToString() };
        }

        public OrderViewModel OrderSuccess()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            string userId = _user.GetCurrentUserId();
            var userData = _context.Users.Find(userId);
            if (userData != null)
            {
                Orders _order = new Orders()
                {

                    Address = String.Empty,
                    City = String.Empty,
                    Country = String.Empty,
                    FirstName = userData.FirstName,
                    statusID = 1,
                    LastName = userData.LastName,
                    Phone = userData.PhoneNumber != null ? userData.PhoneNumber : String.Empty,
                    PostalCode = String.Empty,
                    State = String.Empty,
                    Total = _cart.GetCartTotal(),
                    OrderDate = DateTime.Now,
                    UserId = userId,
                    SubTotal = _cart.GetCartTotal(),
                    ShippingCharges = 0
                };
                _context.Orders.Add(_order);
                _context.SaveChanges();

                orderViewModel = new OrderViewModel()
                {
                    Address = String.Empty,
                    City = String.Empty,
                    Country = String.Empty,
                    FirstName = userData.FirstName,
                    LastName = userData.LastName,
                    Phone = userData.PhoneNumber,
                    PostalCode = String.Empty,
                    State = String.Empty,
                    TotalAmount = _cart.GetCartTotal().ToString(),
                    UserId = userId,
                    OrderId = _order.Id,
                };

                // Update cart with order id
                string ShoppingCartId = _cart.GetCartOrUserId();
                var _cartItems = _context.ShoppingCartItems.Where(x => x.CartOrUserId == ShoppingCartId).ToList();
                //if (_cartItems != null)
                //if (_cartItems.Any())
                //{
                //    foreach (var CartItem in _cartItems)
                //    {
                //        CartItem.OrderId = _order.Id;
                //        CartItem.ItemPurchased = true;
                //        _context.SaveChanges();
                //    }
                //}

            }
            return orderViewModel;
        }

        public void UpdateShippingAddress(OrderViewModel order)
        {
            string userId = _user.GetCurrentUserId();
            Orders _order = new Orders()
            {
                Address = order.Address,
                City = order.City,
                Country = order.Country,
                FirstName = order.FirstName,
                LastName = order.LastName,
                Phone = order.Phone,
                PostalCode = order.PostalCode,
                State = order.State,
                OrderDate = DateTime.Now,
                Total = _cart.GetCartTotal(),
                SubTotal = _cart.GetCartTotal(),
                ShippingCharges = 0,
                UserId = userId,
                statusID = 1
            };
            _context.Orders.Add(_order);
            _context.SaveChanges();
            string ShoppingCartId = _cart.GetCartOrUserId();
            var _cartItems = _context.ShoppingCartItems.Where(x => x.CartOrUserId == ShoppingCartId).ToList();
            if (_cartItems != null)
                if (_cartItems.Any())
                {
                    foreach (var CartItem in _cartItems)
                    {
                        OrderItems oitem = new OrderItems()
                        {
                            OrderId = _order.Id,
                            ProductId = CartItem.ProductId,
                            Quantity = CartItem.Quantity
                        };
                        _context.OrderItems.Add(oitem);
                        _context.SaveChanges();

                        _context.ShoppingCartItems.Remove(CartItem);
                        _context.SaveChanges();
                    }
                }
        }

        public List<OrderViewModel> GetUserOrders()
        {
            string userId = _user.GetCurrentUserId();
            return _context.Orders.Where(x => x.UserId == userId).OrderByDescending(x => x.Id).AsEnumerable().Select(x => new OrderViewModel
            {
                OrderId = x.Id,
                TotalAmount = x.Total.ToString(),
                Datetime = x.OrderDate.ToString("MMM dd, yyyy hh:mm tt"),
                SubTotal = x.SubTotal.ToString(),
                ShippingCharges = x.ShippingCharges.ToString(),
                status = GetUserOrderStatus(x.statusID)
            }).ToList();
        }
        private string GetUserOrderStatus(int Id)
        {
            // 1. Pending 2. Confirmed 3. Shipped 4. Completed 5. Cancelled
            if (Id == 1)
            {
                return "In Process";
            }
            else
             if (Id == 2)
            {
                return "Confirmed";
            }
            else
             if (Id == 3)
            {
                return "Shipped";
            }
            else
             if (Id == 4)
            {
                return "Shipped";
            }
            else
            {
                return "Cancelled";
            }
        }

        public OrderViewModel GetOrderedItemsListing(int OrderId)
        {
            string userId = _user.GetCurrentUserId();
            return _context.Orders.Include(x => x).Where(x => x.Id == OrderId).OrderByDescending(x => x.Id).AsEnumerable().Select(x => new OrderViewModel
            {
                OrderId = x.Id,
                TotalAmount = x.Total.ToString(),
                Datetime = x.OrderDate.ToString("MMM dd, yyyy hh:mm tt"),
                SubTotal = x.SubTotal.ToString(),
                ShippingCharges = x.ShippingCharges.ToString(),
                status = GetUserOrderStatus(x.statusID),
                OrderItems = _context.OrderItems.Where(c => c.OrderId == OrderId).Include(x => x.Products).ThenInclude(x => x.Category).
                  Include(x => x.Products).ThenInclude(x => x.ProductImages).AsEnumerable().Select(x => new OrderProductViewModel
                  {
                      Id = x.ProductId,
                      ProductId = x.ProductId,
                      OrderId = x.OrderId,
                      ProductName = x.Products.ProductName,
                      Price = x.Products.Price.ToString(),
                      ProductImage = x.Products.DefaultImageUrl,
                      Category = x.Products.Category.CategoryName,
                      Quantity = x.Quantity,
                      SubTotal = (x.Quantity * x.Products.Price).ToString()
                  }).ToList(),
                Address = x.Address,
                City = x.City,
                Country = x.Country,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Phone = x.Phone,
                PostalCode = x.Phone
            }).FirstOrDefault();

        }
        public List<OrderViewModel> GetNewUserOrders()
        {
            return _context.Orders.Where(x => x.statusID == 1).OrderByDescending(x => x.Id).AsEnumerable().Select(x => new OrderViewModel
            {
                OrderId = x.Id,
                TotalAmount = x.Total.ToString(),
                Datetime = x.OrderDate.ToString("MMM dd, yyyy hh:mm tt"),
                status = GetUserOrderStatus(x.statusID),
                FirstName = x.FirstName + " " + x.LastName
            }).ToList();
        }

        public List<OrderViewModel> GetCompletedOrders()
        {
            return _context.Orders.Where(x => x.statusID != 1).OrderByDescending(x => x.Id).AsEnumerable().Select(x => new OrderViewModel
            {
                OrderId = x.Id,
                TotalAmount = x.Total.ToString(),
                Datetime = x.OrderDate.ToString("MMM dd, yyyy hh:mm tt"),
                status = GetUserOrderStatus(x.statusID),
                FirstName = x.FirstName + " " + x.LastName
            }).ToList();
        }

        public bool ConfirmDeliverOrder(int id, int statusid)
        {
            var _order = _context.Orders.Find(id);
            if (_order != null)
            {
                _order.statusID = statusid;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
