using System.ComponentModel.DataAnnotations;

namespace InvoiceManagement.Core.Enums
{
    public enum HouseType
    {
        [Display(Name = "Studio")]
        Studio = 0,

        [Display(Name = "One Bedroom")]
        OneBedroom = 1,

        [Display(Name = "Two Bedroom")]
        TwoBedroom = 2,

        [Display(Name = "Three Bedroom")]
        ThreeBedroom = 3,

        [Display(Name = "Four Bedroom")]
        FourBedroom = 4,

        [Display(Name = "Five Bedroom")]
        FiveBedroom = 5,

        [Display(Name = "Six Bedroom")]
        SixBedroom = 6,

        [Display(Name = "Seven Bedroom")]
        SevenBedroom = 7,

        [Display(Name = "Eight Bedroom")]
        EightBedroom = 8,

        [Display(Name = "Nine Bedroom")]
        NineBedroom = 9,

        [Display(Name = "Ten Bedroom")]
        TenBedroom = 10
    }
}
