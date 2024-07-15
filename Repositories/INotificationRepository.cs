using PianoStoreProject.Models;
using System.Collections.Generic;

namespace PianoStoreProject.Repositories
{
    public interface INotificationRepository
    {
        void AddNotification(NotificationViewModel notification);
        void UpdateNotification(NotificationViewModel notification);
        bool DeleteNotification(int id);
        List<NotificationViewModel> GetAllNotification();
        NotificationViewModel EditNotification(int Id);
        List<NotificationViewModel> GetActiveNotifications();
    }
}
