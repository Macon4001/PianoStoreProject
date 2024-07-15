using Microsoft.AspNetCore.Identity.UI.Services;
using PianoStoreProject.Data;
using PianoStoreProject.Models;
using PianoStoreProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PianoStoreProject.Providers
{
    public class ContactProvider : IContactRepository
    {
        private PSPDBContext _context { get; }
        private readonly IEmailSender _emailSender;
        public ContactProvider(PSPDBContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        public async Task SendAndAddMessagesAsync(ContactViewModel contact)
        {
            ContactMessages _contact = new ContactMessages()
            {
                Name = contact.Name,
                Email = contact.Email,
                Phone = contact.PhoneNo,
                IsRead = false,
                Message = contact.Message,
                Subject = contact.Subject,
                Datetime = DateTime.Now
            };
            _context.ContactMessages.Add(_contact);
            _context.SaveChanges();
            // Sending Emails
            string ContactEmail = GetContactEmail();

            string message = "Subject: " + contact.Subject + ".<br>" + contact.Message + "<br><br>Name: " + contact.Name + "<br>Email: " + contact.Email + "<br>";

            if (!String.IsNullOrEmpty(ContactEmail))
            {
                await _emailSender.SendEmailAsync(ContactEmail, "MFBS PRESS STUDIO - Contact Us Email", message);
            }

            await _emailSender.SendEmailAsync(contact.Email, "MFBS PRESS STUDIO  - Thanks for contacting us", $"Hello {contact.Name }! <br>Thanks for contacting us.  Our team will contact you soon.");
        }

        public List<ContactViewModel> GetEmails()
        {
            return _context.ContactMessages.OrderByDescending(x => x.Id).Select(x => new ContactViewModel
            {
                Id = x.Id,
                IsRead = x.IsRead,
                Message = x.Message,
                Name = x.Name,
                PhoneNo = x.Phone,
                Subject = x.Subject,
                Email = x.Email,
                Datetime = x.Datetime.ToString("MMM, dd yyyy hh:mm tt")
            }).ToList();
        }

        public ContactViewModel GetMessage(int EmailId)
        {
            var _data = _context.ContactMessages.Find(EmailId);
            if (_data != null)
            {
                _data.IsRead = true;
                _context.SaveChanges();
            }
            return _context.ContactMessages.Where(a => a.Id == EmailId).Select(x => new ContactViewModel
            {
                Id = x.Id,
                IsRead = x.IsRead,
                Message = x.Message,
                PhoneNo = x.Phone,
                Name = x.Name,
                Subject = x.Subject,
                Email = x.Email,
                Datetime = x.Datetime.ToString("MMM, dd yyyy hh:mm tt")
            }).FirstOrDefault();
        }

        public int TotalUnreadEmails()
        {
            return _context.ContactMessages.Where(x => x.IsRead == false).AsEnumerable().Count();
        }

        public ManagedEmailViewModel GetManagedEmails()
        {
            return _context.ManagedEmails.AsEnumerable().Select(x => new ManagedEmailViewModel
            {
                ContactEmailAddress = x.ContactEmailAddress,
                Id = x.Id,
                NotificationEmailAddress = x.NotificationEmailAddress
            }).FirstOrDefault();
        }

        public void AddOrUpdateEmails(ManagedEmailViewModel contacts)
        {
            var _emailData = _context.ManagedEmails.FirstOrDefault();
            if (_emailData != null)
            {
                _emailData.ContactEmailAddress = contacts.ContactEmailAddress;
                _emailData.NotificationEmailAddress = contacts.NotificationEmailAddress;
                _context.SaveChanges();
            }
            else
            {
                ManagedEmails emails = new ManagedEmails()
                {
                    ContactEmailAddress = contacts.ContactEmailAddress,
                    NotificationEmailAddress = contacts.NotificationEmailAddress
                };
                _context.ManagedEmails.Add(emails);
                _context.SaveChanges();
            }
        }

        public string GetContactEmail()
        {
            var _contact = _context.ManagedEmails.Select(x => x.ContactEmailAddress).FirstOrDefault();
            if (String.IsNullOrEmpty(_contact))
            {
                return string.Empty;
            }
            else
            {
                return _contact;
            }
        }

        public string GetNotificationEmail()
        {
            var _contact = _context.ManagedEmails.Select(x => x.NotificationEmailAddress).FirstOrDefault();
            if (String.IsNullOrEmpty(_contact))
            {
                return string.Empty;
            }
            else
            {
                return _contact;
            }
        }


    }
}
