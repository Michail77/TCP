using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Horak_MailKit.Services
{
    public interface IEmail
    {
        void EstablishIMAPConnection(string email, string heslo);
        Task<List<MimeMessage>> FetchEmails();
        Task<int> GetEmailCount();
        Task SendEmail(string subject, string to, string body);
    }
}
