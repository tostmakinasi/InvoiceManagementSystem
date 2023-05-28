using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Services.Validations
{
    internal abstract class DefaultValidationMessages
    {
        public static string RequiredMessage = "{PropertyName} is required!";
        public static string NotNullMessage = "{PropertyName} can't be null!";
        public static string NotEmptyMessage = "{PropertyName} can't be empty!";
        public static string MustGreaterMessage = "{PropertyName} must greater then 0";
    }
}
