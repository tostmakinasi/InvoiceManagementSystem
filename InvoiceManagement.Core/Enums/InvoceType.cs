using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManagement.Core.Enums
{
    public enum InvoceType
    {
        [Display(Name="Aidat")]
        Dues,

        [Display(Name = "Doğal Gaz")]
        Gas,

        [Display(Name = "Elektirik")]
        Electric,

        [Display(Name = "Su")]
        Water
    }
}
