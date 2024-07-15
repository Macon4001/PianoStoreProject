using PianoStoreProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PianoStoreProject.Repositories
{
    public interface IContactRepository
    {
        Task SendAndAddMessagesAsync(ContactViewModel contact);
        ContactViewModel GetMessage(int EmailId);
        List<ContactViewModel> GetEmails();
        int TotalUnreadEmails();
        void AddOrUpdateEmails(ManagedEmailViewModel contacts);
        ManagedEmailViewModel GetManagedEmails();
        string GetContactEmail();
        string GetNotificationEmail();
    }
}
