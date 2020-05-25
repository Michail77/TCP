using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horak_MailKit.Services
{
    public class Email : IEmail
    {
        private ImapClient _imapClient;

        private string prihlaseny_uzivatel;
        private string prihlaseny_uzivatel_heslo;

        public Email()
        {
            _imapClient = new ImapClient();
        }

        public void EstablishIMAPConnection(string email, string heslo)
        {
            _imapClient.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

            _imapClient.Authenticate(email, heslo);
            prihlaseny_uzivatel = email;
            prihlaseny_uzivatel_heslo = heslo;
        }

        public Task<List<MimeMessage>> FetchEmails()
        {
            return Task.Run(() =>
            {
                var schranka = _imapClient.Inbox;
                schranka.Open(FolderAccess.ReadOnly);

                var list = new List<MimeMessage>();

                for (int i = 0; i < 15; i++)
                {
                    list.Add(schranka.GetMessage(i));
                }

                return list;
            });
        }

        public Task<int> GetEmailCount()
        {
            return Task.Run(() =>
            {
                return _imapClient.Inbox.Count;
            });
        }

        public Task SendEmail(string subject, string to, string body)
        {
            return Task.Run(() =>
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(prihlaseny_uzivatel, prihlaseny_uzivatel));
                message.To.Add(new MailboxAddress(to, to));
                message.Subject = subject;
                message.Body = new TextPart(body);
                message.Date = DateTime.Now;

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, true);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(prihlaseny_uzivatel, prihlaseny_uzivatel_heslo);

                    client.Send(message);
                    client.Disconnect(true);
                }
            });
        }
    }
}
