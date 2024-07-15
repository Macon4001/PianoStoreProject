using PianoStoreProject.Data;
using PianoStoreProject.Models;
using PianoStoreProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PianoStoreProject.Providers
{
    public class NotificationProvider : INotificationRepository
    {
        private PSPDBContext _context { get; }
        public NotificationProvider(PSPDBContext context)
        {
            _context = context;
        }

        public void AddNotification(NotificationViewModel notification)
        {
            bool _status = notification.Status == "Active" ? true : false;
            Notifications _notification = new Notifications()
            {
                NotificationDate = DateTime.Now,
                NotificationMessage = notification.NotificationMessage,
                url = notification.NotificationUrl,
                Status = _status
            };
            _context.Notifications.Add(_notification);
            _context.SaveChanges();
        }

        public void UpdateNotification(NotificationViewModel notification)
        {
            var _notification = _context.Notifications.Find(notification.Id);
            if (_notification != null)
            {
                _notification.NotificationMessage = notification.NotificationMessage;
                _notification.url = notification.NotificationUrl;
                _notification.Status = notification.Status == "Active" ? true : false;
                _context.SaveChanges();
            }
        }

        public bool DeleteNotification(int id)
        {
            var item = _context.Notifications.Find(id);
            if (item != null)
            {
                _context.Notifications.Remove(item);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<NotificationViewModel> GetAllNotification()
        {
            var _data = _context.Notifications.AsEnumerable().Select(x => new NotificationViewModel
            {
                NotificationUrl = x.url,
                NotificationMessage = x.NotificationMessage,
                Status = x.Status ? "Active" : "Inactive",
                Id = x.Id
            }).ToList();
            return _data;
        }

        public List<NotificationViewModel> GetActiveNotifications()
        {
            return _context.Notifications.AsEnumerable().Where(a => a.Status == true).Select(x => new NotificationViewModel
            {
                NotificationMessage = x.NotificationMessage + (!String.IsNullOrEmpty(x.url) ? " — <a href='" + x.url + "' target='_blank'>check it out!</a>" : String.Empty),
            }).ToList();

        }

        public NotificationViewModel EditNotification(int Id)
        {
            NotificationViewModel notification = new NotificationViewModel();
            var _notification = _context.Notifications.Find(Id);
            if (_notification != null)
            {
                notification.Id = _notification.Id;
                notification.NotificationMessage = _notification.NotificationMessage;
                notification.NotificationUrl = _notification.url;
                notification.Status = _notification.Status ? "Active" : "In active";
            }
            return notification;
        }
    }
}
