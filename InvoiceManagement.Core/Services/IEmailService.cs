using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.Services
{
    public interface IEmailService
    {
        Task SendAccountCompletionEmail(string link, string email,string userFullName, string username, string password);
    }
}
