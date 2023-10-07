using Microsoft.AspNetCore.Mvc;

namespace InvoiceManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("/admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
