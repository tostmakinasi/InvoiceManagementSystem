using Microsoft.AspNetCore.Razor.TagHelpers;

namespace InvoiceManagement.Web.TagHelpers
{
    public class UserPictureThumbnailTagHelper:TagHelper
    {
        public string? UserPictureThumbnailUrl { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            if(string.IsNullOrEmpty(UserPictureThumbnailUrl) || UserPictureThumbnailUrl == "-")
            {
                output.Attributes.SetAttribute("src", "/userpictures/defaultUserPicture.png");
            }
            else
            {
                output.Attributes.SetAttribute("src", $"/userpictures/{UserPictureThumbnailUrl}");

            }
            base.Process(context, output);
        }
    }
}
