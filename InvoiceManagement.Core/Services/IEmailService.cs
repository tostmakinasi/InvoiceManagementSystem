using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.Services
{
    public interface IEmailService
    {
        Task SendAccountCompletionEmail(string link, string email);
    }
}
