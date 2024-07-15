using PianoStoreProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PianoStoreProject.Repositories
{
    public interface ICheckOutRepository
    {
        OrderViewModel InitCheckOut();
        OrderViewModel OrderSuccess();
        void UpdateShippingAddress(OrderViewModel order);
        List<OrderViewModel> GetUserOrders();
        OrderViewModel GetOrderedItemsListing(int OrderId);
        List<OrderViewModel> GetNewUserOrders();
        bool ConfirmDeliverOrder(int id,int statusId);
        List<OrderViewModel> GetCompletedOrders();
    }
}
