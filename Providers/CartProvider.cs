using Microsoft.AspNetCore.Http;
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
    public class CartProvider : ICartRepository
    {
        private IUsersRepository _user { get; set; }
        private PSPDBContext _context { get; }
        private IHttpContextAccessor _httpContextAccessor { get; set; }
        public string ShoppingCartId { get; set; }
        public CartProvider(PSPDBContext context, IUsersRepository user, IHttpContextAccessor httpContextAccessor)
        {
            _user = user;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }
        public const string CartSessionKey = "CartId";

        public void AddToCart(ShoppingCartItemsViewModel cart)
        {
            ShoppingCartId = GetCartOrUserId();
            var cartItem = _context.ShoppingCartItems.SingleOrDefault(c => c.CartOrUserId == ShoppingCartId && c.ProductId == cart.ProductId);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new ShoppingCartItems
                {
                    ProductId = cart.ProductId,
                    CartOrUserId = ShoppingCartId, // Gets user id if user is authenticated otherwise store random values
                    CreatedDate = DateTime.Now,
                    Quantity = 1
                };
                _context.ShoppingCartItems.Add(cartItem);
                _context.SaveChanges();
            }
            else
            {
                cartItem.Quantity = cartItem.Quantity + 1;
                _context.SaveChanges();
            }
        }

        public string GetCartOrUserId()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                _httpContextAccessor.HttpContext.Session.SetString("CartSessionKey", _user.GetCurrentUserId());
            }
            else
            {
                if (_httpContextAccessor.HttpContext.Session.GetString("CartSessionKey") == null)
                {
                    _httpContextAccessor.HttpContext.Session.SetString("CartSessionKey", Guid.NewGuid().ToString());
                }
            }
            return _httpContextAccessor.HttpContext.Session.GetString("CartSessionKey").ToString();
        }

        public void UpdateCartSessionID(string CartSessionKey, string UserId)
        {
            var CartItems = _context.ShoppingCartItems.Where(x => x.CartOrUserId == CartSessionKey).AsEnumerable().ToList();
            if (CartItems != null)
                if (CartItems.Any())
                {
                    foreach (var cartItem in CartItems)
                    {
                        cartItem.CartOrUserId = UserId;
                    }
                    _context.SaveChanges();
                }
        }

        public int GetCartItemsCount()
        {
            ShoppingCartId = GetCartOrUserId();
            return _context.ShoppingCartItems.Where(c => c.CartOrUserId == ShoppingCartId).Count();
        }

        public List<ShoppingCartItemsViewModel> GetCartItemsListing()
        {
            ShoppingCartId = GetCartOrUserId();
            return _context.ShoppingCartItems.Where(c => c.CartOrUserId == ShoppingCartId).Include(x => x.Products).ThenInclude(x => x.Category).
                Include(x => x.Products).ThenInclude(x => x.ProductImages).AsEnumerable().Select(x => new ShoppingCartItemsViewModel
                {
                    Id = x.Id,
                    CartId = x.CartOrUserId,
                    Category = x.Products.Category.CategoryName,
                    ProductName = x.Products.ProductName,
                    Price = x.Products.Price.ToString(),
                    Quantity = x.Quantity,
                    SubTotal = (x.Products.Price * x.Quantity).ToString(),
                    CreatedDate = x.CreatedDate.ToString("MMM dd, yyyy"),
                    ProductId = x.ProductId,
                    ProductImage = x.Products.DefaultImageUrl != null ? x.Products.DefaultImageUrl : "/ProfileImages/user-no-image.png",
                }).ToList();
        }

        public decimal GetCartTotal()
        {
            ShoppingCartId = GetCartOrUserId();
            decimal total = decimal.Zero;
            var _cartItems = _context.ShoppingCartItems.Include(x=>x.Products).Where(x => x.CartOrUserId == ShoppingCartId).ToList();
            if (_cartItems != null)
                if (_cartItems.Any())
                {
                    foreach (var CartItem in _cartItems)
                    {
                        total = total + CartItem.Products.Price;
                    }
                }
            return total;
        }

        public bool DeleteCartItem(int Id)
        {
            var item = _context.ShoppingCartItems.Find(Id);
            if (item != null)
            {
                _context.ShoppingCartItems.Remove(item);
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
