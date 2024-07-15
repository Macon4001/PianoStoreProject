using PianoStoreProject.Models;
using System.Collections.Generic;

namespace PianoStoreProject.Repositories
{
    public interface ICartRepository
    {
		void AddToCart(ShoppingCartItemsViewModel cart);
		int GetCartItemsCount();
		List<ShoppingCartItemsViewModel> GetCartItemsListing();
		bool DeleteCartItem(int Id);
		void UpdateCartSessionID(string CartSessionKey, string UserId);
		string GetCartOrUserId();
		decimal GetCartTotal();
	}
}
