﻿using System.ComponentModel.DataAnnotations;

namespace InvoiceManagement.Core.Enums
{
    public enum BillingPeriod
    {
        [Display(Name = "Ocak")]
        January = 1,

        [Display(Name = "Şubat")]
        February,

        [Display(Name = "Mart")]
        March,

        [Display(Name = "Nisan")]
        April,

        [Display(Name = "Mayıs")]
        May,

        [Display(Name = "Haziran")]
        June,

        [Display(Name = "Temmuz")]
        July,

        [Display(Name = "Ağustos")]
        August,

        [Display(Name = "Eylül")]
        September,

        [Display(Name = "Ekim")]
        October,

        [Display(Name = "Kasım")]
        November,

        [Display(Name = "Aralık")]
        December
    }

}
